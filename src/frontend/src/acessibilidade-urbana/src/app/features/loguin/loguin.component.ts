import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { UpxInputTextComponent } from "../../features-components/upx-input-text/upx-input-text.component";

@Component({
  selector: 'app-loguin',
  standalone: true,
  templateUrl: './loguin.component.html',
  styleUrl: './loguin.component.scss',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    UpxInputTextComponent
],
})
export class LoginComponent {

  formGroup: FormGroup = new FormGroup({})

}
