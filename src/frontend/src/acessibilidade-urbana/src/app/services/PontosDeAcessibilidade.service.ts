import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PontosDeAcessibilidadeService {
  private apiUrl = 'https://seu-backend.com/accessibility-points';

  constructor(private http: HttpClient) {}

  getPoints(north: number, south: number, east: number, west: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}?north=${north}&south=${south}&east=${east}&west=${west}`);
  }
}
