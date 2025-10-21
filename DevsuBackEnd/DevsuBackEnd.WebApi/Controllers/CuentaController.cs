using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevsuBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentaController : ControllerBase
{
    private readonly ICuentaService _cuentaService;

    public CuentaController(ICuentaService cuentaService)
    {
        _cuentaService = cuentaService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        var request = await _cuentaService.GetAllAsync(search);
        return Ok(request);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCuentaById(int id)
    {
        var request = await _cuentaService.GetByIdAsync(id);
        if (request == null)
            return NotFound(new { message = $"No se encontró el cliente con ID {id}." });

        return Ok(request);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCuenta([FromBody] CuentaModel cliente)
    {
        var request = await _cuentaService.AddAsync(cliente);
        return Ok(request);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateClient([FromRoute] int id,  [FromBody] CuentaModel cliente)
    {
        var command = await _cuentaService.UpdateAsync(id, cliente);
        return Ok(command);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var command = await _cuentaService.DeleteAsync(id);
        if (!command)
            return NotFound(new { message = $"No se encontró el cliente con ID {id}." });

        return NoContent();
    }
}