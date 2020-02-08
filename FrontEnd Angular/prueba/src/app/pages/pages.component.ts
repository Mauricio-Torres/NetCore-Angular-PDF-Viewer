import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../services/service/usuario.service';

declare function init_plugin();


@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
})
export class PagesComponent implements OnInit {

  constructor(public servicioUsuario: UsuarioService) {
    this.servicioUsuario.cargueInicialUsuario().subscribe((data: any) =>  console.log(data) );

   }

  ngOnInit() {
    init_plugin();
  }

}
