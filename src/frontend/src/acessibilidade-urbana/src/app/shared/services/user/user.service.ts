import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../enviroments/enviroments.local';
import { firstValueFrom } from 'rxjs';
import SignupPayload from './models/signup-payload';
import SignupResponse from './models/signup-response';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  readonly ENDPOINT = environment.apiUrl;

  async Signup(payload: SignupPayload): Promise<SignupResponse> {
    const url = `${this.ENDPOINT}/users`;
    const res = await firstValueFrom(
      this.http.post<SignupResponse>(url, payload)
    );

    return res;
  }
}
