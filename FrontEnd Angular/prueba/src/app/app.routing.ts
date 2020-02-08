import { NopagefoundComponent } from './nopagefound/nopagefound.component';
import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './pages/pages.component';


// se disena de este modo por si se necesitan separar la pagina inicial de otros diferentes modulos que se construyan en la aplicacion
// por ejemplo un modulo de login, registro usuarios o si se necesita que el proyecto cargue otra pagina acorde a configuraciones
// que se realicen en algun setting ... en fin esto permite mas modularidad e independencia entre componentes

const routes: Routes = [
  { path: '', component: PagesComponent, loadChildren: './pages/pages.module#PagesModule'},
  { path: '**', component: NopagefoundComponent }

];

export const AppRoutes = RouterModule.forRoot (routes, {useHash: true} );
