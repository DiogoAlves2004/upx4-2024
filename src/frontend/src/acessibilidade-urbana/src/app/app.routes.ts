import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadComponent: () => import('./features/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'cadastrar',
    loadComponent: () => import('./features/cadastro/cadastro.component').then(m => m.CadastroComponent)
  },
  {
    path: 'redefinir-senha',
    loadComponent: () => import('./features/redefinir-senha/redefinir-senha.component').then(m => m.RedefinirSenhaComponent)
  },
  {
    path: 'mapa',
    loadComponent: () => import('./features/mapa/mapa.component').then(m => m.MapaComponent)
  }
];
