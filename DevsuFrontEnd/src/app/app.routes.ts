import { Routes } from '@angular/router';
import {LayoutComponent} from "./layout/layout.component";
import {ClienteListComponent} from "./features/clientes/cliente-list/cliente-list.component";

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'clientes', component: ClienteListComponent },
      { path: '', redirectTo: 'clientes', pathMatch: 'full' }
    ]
  }
];
