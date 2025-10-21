import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClienteDto } from '../models/cliente';
import {environment} from "../../../environments/environment.development";

@Injectable({ providedIn: 'root' })
export class ClienteService {
  private baseUrl = `${environment.apiUrl}/Cliente`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<ClienteDto[]> {
    return this.http.get<ClienteDto[]>(this.baseUrl);
  }

  getById(id: number): Observable<ClienteDto> {
    return this.http.get<ClienteDto>(`${this.baseUrl}/${id}`);
  }

  create(cliente: ClienteDto): Observable<any> {
    return this.http.post(this.baseUrl, cliente);
  }

  update(id: number, cliente: ClienteDto): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, cliente);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
