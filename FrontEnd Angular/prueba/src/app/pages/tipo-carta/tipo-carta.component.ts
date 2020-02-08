import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { TipoCartaService } from 'src/app/services/service.index';

@Component({
  selector: 'app-tipo-carta',
  templateUrl: './tipo-carta.component.html',
  styleUrls: ['./tipo-carta.component.css']
})
export class TipoCartaComponent implements OnInit {

  @Input() tipoCatas: any[];
  cargando = false;

  constructor(private tipoCartaService: TipoCartaService) { }

  ngOnInit() {
  }

  generarPdf(carta: any){

    this.tipoCartaService.selectTipoCarta.emit(carta);
  }

  verPdf(idioma: any){

  }

}
