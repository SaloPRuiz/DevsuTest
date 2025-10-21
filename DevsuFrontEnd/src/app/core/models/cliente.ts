export interface ClienteDto {
  clienteId: number;
  personaId: number;
  nombre: string;
  genero?: boolean;
  edad?: number;
  identificacion: string;
  direccion?: string;
  telefono?: string;
  contrasena?: string;
  estado: boolean;
  fechaCreacion: string;
  fechaModificacion: string;
}
