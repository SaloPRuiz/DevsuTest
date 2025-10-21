using DevsuBackEnd.Domain.Models;
using DevsuBackEnd.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevsuBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
        var request = await _clienteService.GetAllAsync();
        return Ok(request);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetClientById(int id)
    {
        var request = await _clienteService.GetByIdAsync(id);
        if (request == null)
            return NotFound(new { message = $"No se encontró el cliente con ID {id}." });

        return Ok(request);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewClient([FromBody] ClienteModel cliente)
    {
        var request = await _clienteService.AddAsync(cliente);
        return Ok(request);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateClient([FromRoute] int id,  [FromBody] ClienteModel cliente)
    {
        var command = await _clienteService.UpdateAsync(id, cliente);
        return Ok(command);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var command = await _clienteService.DeleteAsync(id);
        if (!command)
            return NotFound(new { message = $"No se encontró el cliente con ID {id}." });

        return NoContent();
    }
}