import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioService, CartasGeneradasService, IdiomasService,
  TipoCartaService,
  SidebarService} from './service.index';

import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    UsuarioService,
    CartasGeneradasService,
    IdiomasService,
    TipoCartaService,
    SidebarService
  ]
})
export class ServiceModule { }
