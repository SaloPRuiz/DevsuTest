using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevsuBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosController : ControllerBase
{
    private readonly IMovimientoService _service;

    public MovimientosController(IMovimientoService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllMovimientos([FromQuery] string? search)
    {
        var request = await _service.GetAllAsync(search);
        return Ok(request);
    }
    
    [HttpGet("tipos-movimiento")]
    public async Task<IActionResult> GetAllTiposMovimiento()
    {
        var request = await _service.GetAllTiposMovimiento();
        return Ok(request);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCuenta([FromBody] MovimientoModel model)
    {
        var request = await _service.AddAsync(model);
        return Ok(request);
    }
}