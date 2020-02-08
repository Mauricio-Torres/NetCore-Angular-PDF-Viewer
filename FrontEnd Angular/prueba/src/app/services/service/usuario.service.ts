import { Injectable } from '@angular/core';
import { map, catchError } from 'rxjs/operators';

import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { URL_SERVICE } from '../../Config/config';
import { Observable } from 'rxjs';
import { Usuario } from '../../model/usuario.model';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  usuario: any;
  menu: any[] = [];
  idiomas: any[] = [];

  data: any;

  constructor( public htpp: HttpClient, public router: Router) {
  }


guardarLocalStorage( id: string, usuario: any, menu: any, idioma: any) {

  localStorage.setItem('id', id);
  localStorage.setItem('usuario', JSON.stringify(usuario) );
  localStorage.setItem('menu', JSON.stringify(menu) );
  localStorage.setItem('idioma', JSON.stringify(idioma) );

  this.usuario = usuario;
  this.menu = (menu);
  this.idiomas = idioma;

}

cargueInicialUsuario() {

    const url = URL_SERVICE + '/resultados';

    return this.htpp.get(url).pipe( map((res: any) => {

      this.guardarLocalStorage( res.usuario.id, res.usuario, res.menu, res.idioma)
      return true;
    }),
    catchError( (err: any) => {

      // tslint:disable-next-line: deprecation
      return Observable.throw(err); })

      );


    }

    cargueInicialIdioma() {

      const url = URL_SERVICE + '/api/Idiomas';
      return this.htpp.get(url).pipe( map((res: any) => {
        console.log(res)
        return true;
      }),
      catchError( (err: any) => {
        return Observable.throw(err); })

        );

      }

      catchError() {
        throw new Error("Method not implemented.");
      }
}
