import { Injectable } from '@angular/core';
import { UsuarioService } from './usuario.service';
import { Usuario } from 'src/app/model/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  menu: any[] = [];
  constructor(public _usuarioService: UsuarioService) {
    this.cargarMenu()
   }

   cargarMenu() {
    this.menu = JSON.parse (localStorage.getItem('menu')); // this._usuarioService.menu;
    console.log('MENU ... ',this.menu)

   }

}
