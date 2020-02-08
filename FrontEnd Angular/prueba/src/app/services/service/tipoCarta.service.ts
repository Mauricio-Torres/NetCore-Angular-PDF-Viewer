import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { URL_SERVICE } from 'src/app/Config/config';
import { Carta } from '../../model/carta.model';

@Injectable({
  providedIn: 'root'
})
export class TipoCartaService {

  @Output() selectTipoCarta: EventEmitter<any> = new EventEmitter();

  constructor(public http: HttpClient) { }

  crearTipoCartas(carta: Carta) {

    const url = URL_SERVICE + '/generarPdf';
    return this.http.post(url, carta).pipe(map( (resp: any) => {
      return resp;
    }));
  }

}
