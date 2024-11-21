import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormsModule,
  ReactiveFormsModule,
  FormGroup,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { UpxInputTextComponent } from '../../features-components/upx-input-text/upx-input-text.component';
import { AuthorizationService } from '../../shared/services/authorization/authorization.service';
import LoginPayload from '../../shared/services/authorization/models/login-payload';
import { Router } from '@angular/router';
import { ModalComponent } from '../../features-components/modal/modal.component';
@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    UpxInputTextComponent,
    ModalComponent,
  ],
})
export class LoginComponent {
  form!: FormGroup;
  modalOpen: boolean = false;
  modalMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private service: AuthorizationService,
    private router: Router
  ) {
    this.form = this.fb.group({
      // Assign value to form property
      email: [
        '',
        [
          Validators.required,
          Validators.maxLength(this.emailMaxLength),
          Validators.email,
        ],
      ],
      password: [
        '',
        [Validators.required, Validators.maxLength(this.passwordMaxLength)],
      ],
    });
  }

  readonly emailMaxLength = 100;
  readonly passwordMaxLength = 30;

  readonly email = this.form?.get('email')!;
  readonly password = this.form?.get('password')!;

  async onLoginFormSubmit(data: FormGroup) {
    const loginRequest: LoginPayload = {
      email: data.value.email,
      password: data.value.password,
    };
    try {
      const res = await this.service.Login(loginRequest);
      if (res.authenticated) {
        this.router.navigate(['/mapa']);
      }
    } catch {
      this.modalMessage = 'Usuário ou senha inválidos';
      this.modalOpen = true;
    }
  }

  handleCloseModal() {
    this.modalOpen = false;
  }

  openModal() {
    this.modalOpen = true;
  }

  register() {
    this.router.navigate(['/cadastrar']);
  }

  forgotPassword() {
    this.router.navigate(['/redefinir-senha']);
  }
}
export { Component };
