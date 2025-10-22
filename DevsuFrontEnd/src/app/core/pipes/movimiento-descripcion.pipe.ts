import { Pipe, PipeTransform } from '@angular/core';
import { CurrencyPipe } from '@angular/common';

@Pipe({
  standalone: true,
  name: 'movimientoDescripcion'
})
export class MovimientoDescripcionPipe implements PipeTransform {

  private currencyPipe = new CurrencyPipe('en-US'); // instancia manual

  transform(tipoMovimientoId: number, valor: number): string {
    const valorFormateado = this.currencyPipe.transform(valor, 'USD', 'symbol', '1.2-2');
    if (tipoMovimientoId === 1) return `Depósito de ${valorFormateado}`;
    if (tipoMovimientoId === 2) return `Retiro de ${valorFormateado}`;
    return '';
  }
}
