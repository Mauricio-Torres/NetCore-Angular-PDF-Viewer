import { Component, OnInit } from '@angular/core';
import { IdiomasService, TipoCartaService } from 'src/app/services/service.index';
import { Carta } from '../../model/carta.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  operacionSeleccionada: any;
  tipoOperaciones = [
    { name: "A quien pueda interesar", value: 1 }, { name: "A esta persona ...", value: 2 }
  ];


  carta: Carta;

  cargando = false;
  idioma: any[] = []
  tipoCartas: any[] = []
  selectOption: any;


  constructor(private idiomasService: IdiomasService, private tipoCartaService: TipoCartaService) {
    this.operacionSeleccionada = this.tipoOperaciones[0];
    // tslint:disable-next-line: new-parens
    this.carta = new Carta;
  }

  ngOnInit() {

    this.idioma = JSON.parse (localStorage.getItem('idioma'));

    this.idiomasService.changeIdioma.subscribe((dat) => {

      this.carta.idTipo = null;
      this.carta.idIdiomas = dat.id;

      this.cargando = true;
      this.idiomasService.cargarTipoCartas(dat.id).subscribe((tipoCartas => {
        this.tipoCartas = tipoCartas;
        this.cargando = false;
      }));
    });

    this.tipoCartaService.selectTipoCarta.subscribe((dat: any) => {

      this.carta.idTipo = dat.id;
      this.tipoCartaService.crearTipoCartas(this.carta)
    });
  }

  optionSlect(op: any){

    if (op.value === 1) {

      this.carta.nombre = null;
      this.carta.apellido = null;
      this.carta.titulo = null;
      this.carta.cargo = null;
      this.carta.organizacion = null;
      this.carta.direccion = null;
      this.carta.ciudad = null;
      this.carta.pais = null;
    }

  }

}
