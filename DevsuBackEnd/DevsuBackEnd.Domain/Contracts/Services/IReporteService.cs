using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Services;

public interface IReporteService
{
    Task<List<ReporteEstadoCuentaModel>> GetReporteEstadoCuenta(int clienteId, DateTime fechaInicio, DateTime fechaFin);
    Task<string> GenerarReportePdfBase64Async(int clienteId, DateTime fechaInicio, DateTime fechaFin);
}