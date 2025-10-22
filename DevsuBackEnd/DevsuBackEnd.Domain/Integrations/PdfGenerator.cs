using DevsuBackEnd.Domain.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace DevsuBackEnd.Domain.Integrations;

 public static class PdfGenerator
    {
        public static string GenerarReporteBase64(IEnumerable<ReporteEstadoCuentaModel> datos)
        {
            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);
                    
                    page.Header()
                        .Text("Reporte de Estado de Cuentas")
                        .FontSize(18)
                        .Bold()
                        .AlignCenter();
                    
                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("Fecha").Bold();
                                header.Cell().Text("Cliente").Bold();
                                header.Cell().Text("Cuenta").Bold();
                                header.Cell().Text("Tipo").Bold();
                                header.Cell().Text("Movimiento").Bold();
                                header.Cell().Text("Saldo Disponible").Bold();
                            });

                            foreach (var item in datos)
                            {
                                table.Cell().Text(item.Fecha.ToString("yyyy-MM-dd"));
                                table.Cell().Text(item.Cliente);
                                table.Cell().Text(item.NumeroCuenta);
                                table.Cell().Text(item.TipoCuenta);
                                table.Cell().Text(item.Movimiento.ToString("C"));
                                table.Cell().Text(item.SaldoDisponible.ToString("C"));
                            }
                        });
                });
            });

            using var ms = new MemoryStream();
            pdfDocument.GeneratePdf(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
    }