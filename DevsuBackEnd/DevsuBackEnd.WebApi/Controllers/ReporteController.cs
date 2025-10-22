using DevsuBackEnd.Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevsuBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReporteController : ControllerBase
{
    private readonly IReporteService _reporteService;

    public ReporteController(IReporteService reporteService)
    {
        _reporteService = reporteService;
    }
    
    [HttpGet("estado-cuenta/{clienteId}")]
    public async Task<IActionResult> GetReporteEstadoCuenta(
        [FromRoute] int clienteId, 
        [FromQuery] DateTime inicio, 
        [FromQuery] DateTime fin)
    {
        var request = await _reporteService.GetReporteEstadoCuenta(clienteId, inicio, fin);
        return Ok(request);
    }
    
    [HttpGet("estado-cuenta/{clienteId}/pdf")]
    public async Task<IActionResult> GetReporteEstadoCuentaPdf(
        [FromRoute] int clienteId, 
        [FromQuery] DateTime inicio, 
        [FromQuery] DateTime fin)
    {
        var request = await _reporteService.GenerarReportePdfBase64Async(clienteId, inicio, fin);
        return Ok(request);
    }
}