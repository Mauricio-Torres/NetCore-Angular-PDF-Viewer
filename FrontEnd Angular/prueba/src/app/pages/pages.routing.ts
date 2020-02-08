import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CartasGeneradasComponent } from './cartas-generadas/cartas-generadas.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent, data: { titulo: 'Dashboard' } },
  { path: 'cartasGeneradas', component: CartasGeneradasComponent, data: { titulo: 'Cartas Generadas' } },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' }
];

export const PagesRoutes = RouterModule.forChild(routes);
