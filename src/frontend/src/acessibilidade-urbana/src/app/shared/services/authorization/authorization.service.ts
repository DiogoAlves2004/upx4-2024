import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../enviroments/enviroments.local';
import LoginResponse from './models/login-response';
import { firstValueFrom } from 'rxjs';
import LoginPayload from './models/login-payload';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationService {
  constructor(private http: HttpClient) {}

  readonly ENDPOINT = environment.apiUrl;

  async Login(payload: LoginPayload): Promise<LoginResponse> {
    const url = `${this.ENDPOINT}/authorization`;
    const res = await firstValueFrom(
      this.http.post<LoginResponse>(url, payload)
    );

    return res;
  }
}
