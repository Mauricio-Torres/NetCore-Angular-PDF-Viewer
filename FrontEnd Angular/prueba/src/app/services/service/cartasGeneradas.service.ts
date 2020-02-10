import { Injectable } from '@angular/core';
import { Carta } from '../../model/carta.model';
import { HttpClient } from '@angular/common/http';
import { URL_SERVICE } from 'src/app/Config/config';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CartasGeneradasService {

  hacerCOnsulta = true;
  cartasGeneradas: Carta[] = [];
constructor(public http: HttpClient) { }


getCartas(carta: any) {

  const url = URL_SERVICE + '/cartasGeneradas?select=' + JSON.stringify(carta);
  return this.http.get(url).pipe(map( (resp: any) => { return resp; }));

}
}
