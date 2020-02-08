import { Injectable, Output, EventEmitter } from '@angular/core';
import { URL_SERVICE } from 'src/app/Config/config';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class IdiomasService {

  @Output() changeIdioma: EventEmitter<any> = new EventEmitter();
  constructor(public http: HttpClient) { }

  cargarTipoCartas(idIdioma: any) {


    const url = URL_SERVICE + '/api/TipoCartas/' + idIdioma + '?idIdioma=' + idIdioma;
    return this.http.get(url).pipe(map( (resp: any) => {
      return resp;
    }));
  }
}
