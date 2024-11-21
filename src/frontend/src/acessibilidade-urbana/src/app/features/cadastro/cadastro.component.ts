import { Component } from '@angular/core';
import {
  FormsModule,
  ReactiveFormsModule,
  FormGroup,
  FormBuilder,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { ModalComponent } from '../../features-components/modal/modal.component';
import { CommonModule, NgIf } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { UpxInputTextComponent } from '../../features-components/upx-input-text/upx-input-text.component';
import { AuthorizationService } from '../../shared/services/authorization/authorization.service';
import { Router } from '@angular/router';
import LoginPayload from '../../shared/services/authorization/models/login-payload';
import { UserService } from '../../shared/services/user/user.service';
import SignupPayload from '../../shared/services/user/models/signup-payload';
import { guidv4 } from '../../shared/utils/utils';
import { timeout } from 'rxjs';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    UpxInputTextComponent,
    ModalComponent,
  ],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.scss',
})
export class CadastroComponent {
  form!: FormGroup;
  modalOpen: boolean = false;
  modalMessage: string = '';

  constructor(private fb: FormBuilder, private service: UserService,private router: Router) {
    this.form = this.fb.group({
      // Assign value to form property
      name: [
        '',
        [Validators.required, Validators.maxLength(this.nameMaxLength)],
      ],
      email: [
        '',
        [Validators.required, Validators.maxLength(this.emailMaxLength), Validators.email],
      ],
      password: [
        '',
        [Validators.required, Validators.maxLength(this.passwordMaxLength)],
      ],
      confirmPassword: ['', [Validators.required, Validators.maxLength(this.passwordMaxLength), this.validatePasswordMatch]
    ]
    });
  }

  readonly nameMaxLength = 80;
  readonly emailMaxLength = 100;
  readonly passwordMaxLength = 30;

  readonly email = this.form?.get('email')!;
  readonly password = this.form?.get('password')!;
  readonly name = this.form?.get('name')!;
  readonly confirmPassword = this.form?.get('confirmPassword')!;

  async onLoginFormSubmit(data: FormGroup) {
    const signupRequest:SignupPayload = { id: guidv4(), name: data.value.name, email: data.value.email, password: data.value.password };
    try {
      const res = await this.service.Signup(signupRequest);
      if (res.id) {
        this.modalMessage = "Cadastro realizado com sucesso";
        this.modalOpen = true;
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
      } 
    }
    catch {
      this.modalMessage = "Ocorreu um erro durante o cadastro";
      this.modalOpen = true;
    }
  }

  validatePasswordMatch = (control: AbstractControl): {[key: string]: any} | null => {
    const password = this.form?.get('password')?.value as string;
    const passwordConfirm = control.value as string;
  
    if (password !== passwordConfirm) {
      return {passwordMatch: true};
    }
    return null;
  };

  handleCloseModal() {
    this.modalOpen = false;
  }

  back() {
    this.router.navigate(['/']);
  }
}
export { Component };
