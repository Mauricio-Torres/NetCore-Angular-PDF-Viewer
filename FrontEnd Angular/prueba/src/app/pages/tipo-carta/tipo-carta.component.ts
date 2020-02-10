import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { TipoCartaService } from 'src/app/services/service.index';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tipo-carta',
  templateUrl: './tipo-carta.component.html',
  styleUrls: ['./tipo-carta.component.css']
})
export class TipoCartaComponent implements OnInit {

  @Input() tipoCatas: any[];
  @Output() generarCart = new EventEmitter();
  @Output() verListPdf = new EventEmitter();

  cargando = false;

  constructor(private tipoCartaService: TipoCartaService, private router: Router ) { }

  ngOnInit() {
  }

  generarPdf(carta: any){

    this.generarCart.emit(carta)
  }

  verPdf(idioma: any){

    this.verListPdf.emit(idioma);
  }

}
