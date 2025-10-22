import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environment} from "../../../environments/environment.development";
import {MovimientoDto} from "../models/movimiento";
import {TipoMovimientoDto} from "../models/tipo-movimiento";

@Injectable({ providedIn: 'root' })
export class MovimientoService {
  private baseUrl = `${environment.apiUrl}/Movimientos`;

  constructor(private http: HttpClient) {}

  getAll(search?: string): Observable<MovimientoDto[]> {
    const url = search
      ? `${this.baseUrl}?search=${encodeURIComponent(search)}`
      : this.baseUrl;

    return this.http.get<MovimientoDto[]>(url);
  }

  getTiposMovimiento(): Observable<TipoMovimientoDto[]> {
    return this.http.get<TipoMovimientoDto[]>(`${this.baseUrl}/tipos-movimiento`);
  }

  create(cliente: MovimientoDto): Observable<any> {
    return this.http.post(this.baseUrl, cliente);
  }

  update(id: number, cliente: MovimientoDto): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, cliente);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
