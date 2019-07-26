import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../../Models/Cliente';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private baseUrl = 'api/Cliente';
  constructor(private http: HttpClient) { }

  public getClientList(): Observable<Array<Cliente>> {
    return this.http.get<Array<Cliente>>(`${environment.apiBaseUrl}/${this.baseUrl}/List`).pipe(
      response => response
    );
  }

  public getClientById(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${environment.apiBaseUrl}/${this.baseUrl}/Get/${id}`).pipe(
      response => response
    );
  }

  public postCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(`${environment.apiBaseUrl}/${this.baseUrl}/Post`, cliente);
  }

  public putCliente(id: number, cliente: Cliente): Observable<Cliente> {
    return this.http.put<Cliente>(`${environment.apiBaseUrl}/${this.baseUrl}/Put/${id}`, cliente);
  }

  public deleteCliente(id: number): Observable<Cliente> {
    return this.http.delete<Cliente>(`${environment.apiBaseUrl}/${this.baseUrl}/Delete/${id}`);
  }
}
