import { Component } from '@angular/core';
import {
  FormsModule,
  ReactiveFormsModule,
  FormGroup,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { ModalComponent } from '../../features-components/modal/modal.component';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { UpxInputTextComponent } from '../../features-components/upx-input-text/upx-input-text.component';
import { AuthorizationService } from '../../shared/services/authorization/authorization.service';
import { Router } from '@angular/router';
import LoginPayload from '../../shared/services/authorization/models/login-payload';

@Component({
  selector: 'app-redefinir-senha',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    UpxInputTextComponent,
    ModalComponent,
  ],
  templateUrl: './redefinir-senha.component.html',
  styleUrl: './redefinir-senha.component.scss',
})
export class RedefinirSenhaComponent {
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
      confirmPassword: ['', [Validators.required]],
    });
  }

  readonly emailMaxLength = 100;
  readonly passwordMaxLength = 30;

  async onLoginFormSubmit(data: FormGroup) {
    const loginRequest: LoginPayload = {
      email: data.value.email,
      password: data.value.password,
    };
    try {
      const res = await this.service.Login(loginRequest);
      if (res.authenticated) {
        this.router.navigate(['/login']);
        this.modalMessage = 'Senha redefinida com sucesso';
      }
    } catch {
      this.modalMessage = 'E-mail ou senha inválidos';
      this.modalOpen = true;
    }
  }

  handleCloseModal() {
    this.modalOpen = false;
  }

  back() {
    this.router.navigate(['/']);
  }
}
export { Component };
