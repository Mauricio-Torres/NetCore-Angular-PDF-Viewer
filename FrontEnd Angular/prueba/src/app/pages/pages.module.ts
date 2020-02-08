import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { TipoCartaComponent } from './tipo-carta/tipo-carta.component';
import { CartasGeneradasComponent } from './cartas-generadas/cartas-generadas.component';
import { IdiomaComponent } from './idioma/idioma.component';
import { PersonalizarCartaComponent } from './personalizar-carta/personalizar-carta.component';
import { PagesRoutes } from './pages.routing';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MatRadioModule } from '@angular/material/radio';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    PagesRoutes,
    MatRadioModule,
    ReactiveFormsModule
  ],
  declarations: [
    TipoCartaComponent,
    DashboardComponent,
    CartasGeneradasComponent,
    IdiomaComponent,
    PersonalizarCartaComponent
  ]
})
export class PagesModule { }
