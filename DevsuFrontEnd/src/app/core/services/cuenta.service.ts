import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environment} from "../../../environments/environment.development";
import {CuentaDto} from "../models/cuenta";

@Injectable({ providedIn: 'root' })
export class CuentaService {
  private baseUrl = `${environment.apiUrl}/Cuenta`;

  constructor(private http: HttpClient) {}

  getAll(search?: string): Observable<CuentaDto[]> {
    const url = search
      ? `${this.baseUrl}?search=${encodeURIComponent(search)}`
      : this.baseUrl;

    return this.http.get<CuentaDto[]>(url);
  }

  create(cliente: CuentaDto): Observable<any> {
    return this.http.post(this.baseUrl, cliente);
  }

  update(id: number, cliente: CuentaDto): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, cliente);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
