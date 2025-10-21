using DevsuBackEnd.Domain.Contracts;
using DevsuBackEnd.Domain.Models;
using DevsuBackEnd.Infra.Persistence.Context;
using DevsuBackEnd.Infra.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevsuBackEnd.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClienteModel>> GetAllAsync(string? search)
    {
        var query = _context.Clientes
            .Include(c => c.Persona)
            .AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c =>
                c.Persona.Nombre.Contains(search) ||
                c.Persona.Identificacion.Contains(search) ||
                (c.Persona.Telefono != null && c.Persona.Telefono.Contains(search)));
        }
        
        var clientes = await query
            .OrderByDescending(c => c.ClienteId)
            .ToListAsync();
        
        var resultado = clientes.Select(c => new ClienteModel
        {
            ClienteId = c.ClienteId,
            PersonaId = c.PersonaId,
            Contrasena = c.Contrasena,
            Estado = c.Estado,
            Nombre = c.Persona.Nombre,
            Genero = c.Persona.Genero,
            Edad = c.Persona.Edad,
            Identificacion = c.Persona.Identificacion,
            Direccion = c.Persona.Direccion,
            Telefono = c.Persona.Telefono,
        });

        return resultado;
    }

    public async Task<ClienteModel?> GetByIdAsync(int id)
    {
        var cliente = await _context.Clientes
            .Include(x => x.Persona)
            .FirstOrDefaultAsync(x => x.ClienteId == id);

        if (cliente == null) return null;

        return new ClienteModel
        {
            ClienteId = cliente.ClienteId,
            PersonaId = cliente.PersonaId,
            Nombre = cliente.Persona.Nombre,
            Genero = cliente.Persona.Genero,
            Edad = cliente.Persona.Edad,
            Identificacion = cliente.Persona.Identificacion,
            Direccion = cliente.Persona.Direccion,
            Telefono = cliente.Persona.Telefono,
            Contrasena = cliente.Contrasena,
            Estado = cliente.Estado
        };
    }

    public async Task<ClienteModel> AddAsync(ClienteModel model)
    {
        var persona = new Persona
        {
            Nombre = model.Nombre,
            Genero = model.Genero,
            Edad = model.Edad,
            Identificacion = model.Identificacion,
            Direccion = model.Direccion,
            Telefono = model.Telefono
        };

        _context.Personas.Add(persona);
        await _context.SaveChangesAsync();

        var cliente = new Cliente
        {
            PersonaId = persona.PersonaId,
            Contrasena = model.Contrasena,
            Estado = true
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        
        model.ClienteId = cliente.ClienteId;
        model.PersonaId = persona.PersonaId;

        return model;
    }

    public async Task<ClienteModel?> UpdateAsync(int id, ClienteModel model)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Persona)
            .FirstOrDefaultAsync(c => c.ClienteId == id);

        if (cliente == null) return null;

        cliente.Persona.Nombre = model.Nombre;
        cliente.Persona.Genero = model.Genero;
        cliente.Persona.Edad = model.Edad;
        cliente.Persona.Identificacion = model.Identificacion;
        cliente.Persona.Direccion = model.Direccion;
        cliente.Persona.Telefono = model.Telefono;
        cliente.Persona.FechaModificacion = DateTime.Now;

        cliente.Contrasena = model.Contrasena;
        cliente.Estado = model.Estado ?? cliente.Estado;
        cliente.FechaModificacion = DateTime.Now;

        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Persona)
            .FirstOrDefaultAsync(c => c.ClienteId == id);

        if (cliente == null) return false;
        
        cliente.Estado = false;
        cliente.Persona.Estado = false;
        cliente.FechaModificacion = DateTime.Now;
        cliente.Persona.FechaModificacion = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }
}