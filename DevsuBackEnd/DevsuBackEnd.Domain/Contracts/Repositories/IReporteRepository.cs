using DevsuBackEnd.Domain.Models;

namespace DevsuBackEnd.Domain.Contracts.Repositories;

public interface IReporteRepository
{ 
    Task<List<ReporteEstadoCuentaModel>> GetReportePorClienteAsync(int clienteId, DateTime fechaInicio, DateTime fechaFin);
}