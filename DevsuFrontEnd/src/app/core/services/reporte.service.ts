import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { ReporteEstadoCuentaDto} from "../models/reporte-estado-cuenta.model";

@Injectable({ providedIn: 'root' })
export class ReporteService {
  private baseUrl = `${environment.apiUrl}/Reporte`;

  constructor(private http: HttpClient) {}

  getReporteEstadoCuenta(clienteId: number, inicio: string, fin: string): Observable<ReporteEstadoCuentaDto[]> {
    const params = new HttpParams()
      .set('inicio', inicio)
      .set('fin', fin);

    return this.http.get<ReporteEstadoCuentaDto[]>(`${this.baseUrl}/estado-cuenta/${clienteId}`, { params });
  }

  getReporteEstadoCuentaPdf(clienteId: number, inicio: string, fin: string): Observable<string> {
    const params = new HttpParams()
      .set('inicio', inicio)
      .set('fin', fin);

    return this.http.get<string>(`${this.baseUrl}/estado-cuenta/${clienteId}/pdf`, { params, responseType: 'text' as 'json' });
  }
}
