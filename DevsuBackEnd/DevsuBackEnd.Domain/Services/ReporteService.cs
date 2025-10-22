using DevsuBackEnd.Domain.Contracts.Repositories;
using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Integrations;
using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Services;

public class ReporteService : IReporteService
{
    private readonly IReporteRepository _reporteRepository;

    public ReporteService(IReporteRepository reporteRepository)
    {
        _reporteRepository = reporteRepository;
    }

    public async Task<List<ReporteEstadoCuentaModel>> GetReporteEstadoCuenta(int clienteId, DateTime fechaInicio, DateTime fechaFin)
    {
        return await _reporteRepository.GetReportePorClienteAsync(clienteId, fechaInicio, fechaFin);
    }

    public async Task<string> GenerarReportePdfBase64Async(int clienteId, DateTime fechaInicio, DateTime fechaFin)
    {
        var datos = await _reporteRepository.GetReportePorClienteAsync(clienteId, fechaInicio, fechaFin);
        return PdfGenerator.GenerarReporteBase64(datos);
    }
}