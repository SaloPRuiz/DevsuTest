import { Routes } from '@angular/router';
import {LayoutComponent} from "./layout/layout.component";
import {ClienteListComponent} from "./features/clientes/cliente-list/cliente-list.component";
import {CuentaListComponent} from "./features/cuentas/cuenta-list/cuenta-list.component";
import {MovimientoListComponent} from "./features/movimientos/movimiento-list/movimiento-list.component";
import {ReporteEstadoCuentaComponent} from "./features/reportes/reporte-estado-cuenta/reporte-estado-cuenta.component";

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'clientes', component: ClienteListComponent },
      { path: 'cuentas', component: CuentaListComponent },
      { path: 'movimientos', component: MovimientoListComponent },
      { path: 'reportes', component: ReporteEstadoCuentaComponent },
      { path: '', redirectTo: 'clientes', pathMatch: 'full' }
    ]
  }
];
