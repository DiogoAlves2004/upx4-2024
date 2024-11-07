import { Routes } from '@angular/router';
import { LoginComponent } from './features/loguin/loguin.component';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () => import('./features/loguin/loguin.component').then(m => m.LoginComponent)
  }
];
