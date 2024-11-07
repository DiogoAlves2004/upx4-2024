import { CommonModule } from '@angular/common';
import { Component, input } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
@Component({
  selector: 'upx-input-text',
  standalone: true,
  templateUrl: './upx-input-text.component.html',
  styleUrl: './upx-input-text.component.scss',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule
  ],
})
export class UpxInputTextComponent {

  formGroup = input.required<FormGroup>()
  formControlName = input.required<string>()

}
