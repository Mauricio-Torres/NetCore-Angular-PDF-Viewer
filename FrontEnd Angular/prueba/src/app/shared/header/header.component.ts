import { Usuario } from './../../model/usuario.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/service/usuario.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  usuario: Usuario;
  constructor(public servicioUsuario: UsuarioService, public router: Router) {

  }

  ngOnInit() {
    this.usuario = this.servicioUsuario.usuario;
  }

  buscar(termino: any) {
      this.router.navigate(['/busqueda', termino])
  }

}
