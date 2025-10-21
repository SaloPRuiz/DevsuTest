import {MovimientoDto} from "./movimiento";

export interface CuentaDto {
  cuentaId?: number;
  numeroCuenta: string;
  clienteNombre: string;
  tipoCuentaId: number;
  tipoCuenta: string;
  saldoInicial: number;
  movimientos?: MovimientoDto[];
  estado: boolean;
}
