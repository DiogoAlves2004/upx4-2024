import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { environment } from '../../enviroments/enviroments.local';

@Injectable({
  providedIn: 'root'
})
export class PontosDeAcessibilidadeService {
  private apiUrl = environment.apiUrl + '/pontosdeacessibilidade';

  // Cache usando o id do ponto como chave
  private cache = new Map<string, { data: any, expiration: number }>();

  constructor(private http: HttpClient) {}

  getPoints(north: number, south: number, east: number, west: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}?north=${north}&south=${south}&east=${east}&west=${west}`)
  }

  criarPonto(model: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, model).pipe(
      tap(() => {
        // Limpa todo o cache ao criar um novo ponto
        this.cache.clear();
      })
    );
  }


  reverseGeocode(lng: number, lat: number): Observable<any> {
    const apiKey = 'pk.3c05f89f29024dbda3ee8fc4f703d269';  // Substitua pela sua chave
    const url = `https://us1.locationiq.com/v1/reverse.php?key=${apiKey}&lat=${lat}&lon=${lng}&format=json`;
    return this.http.get<any>(url);
  }

}
