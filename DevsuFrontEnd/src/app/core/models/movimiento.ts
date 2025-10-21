export interface MovimientoDto {
  movimientoId?: number;
  fechaMovimiento: string;
  tipoMovimiento: string;
  valor: number;
  saldo: number;
  cuentaId: number;
}
