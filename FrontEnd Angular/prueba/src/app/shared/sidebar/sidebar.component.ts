import { Component, OnInit } from '@angular/core';
import { SidebarService } from 'src/app/services/service/sidebar.service';
import { UsuarioService } from 'src/app/services/service/usuario.service';
import { Usuario } from 'src/app/model/usuario.model';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {


  usuario: Usuario;

  constructor(public _sideBarService: SidebarService, public servicioUsuario: UsuarioService) { }

  ngOnInit() {
    this.usuario = JSON.parse (localStorage.getItem('usuario')) ;
    // this._sideBarService.cargarMenu();
  }

}
