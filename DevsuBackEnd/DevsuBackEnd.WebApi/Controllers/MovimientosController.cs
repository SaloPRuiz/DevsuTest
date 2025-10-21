using DevsuBackEnd.Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevsuBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosController : ControllerBase
{
    public readonly IMovimientoService _service;

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
}