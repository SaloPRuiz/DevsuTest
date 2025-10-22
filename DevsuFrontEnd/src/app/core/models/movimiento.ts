export interface MovimientoDto {
  movimientoId?: number;
  fechaMovimiento: string;
  tipoMovimientoId: number;
  tipoMovimiento: string;
  valor: number;
  saldo: number;
  cuentaId: number;
  numeroCuenta: string;
  tipoCuenta: string;
  saldoInicial: string;
  movimientoDescripcion: string;
  estado: boolean;
}
