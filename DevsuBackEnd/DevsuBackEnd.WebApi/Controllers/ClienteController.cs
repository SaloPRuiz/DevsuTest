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
    public async Task<ActionResult> GetAllAsync()
    {
        var clientes = await _clienteService.GetAllAsync();
        return Ok(clientes);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClienteModel cliente)
    {
        var clienteNuevo = await _clienteService.AddAsync(cliente);
        return Ok(clienteNuevo);
    }
}