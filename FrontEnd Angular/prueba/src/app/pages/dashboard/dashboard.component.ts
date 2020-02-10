import { Component, OnInit, EventEmitter } from '@angular/core';
import { IdiomasService, TipoCartaService, CartasGeneradasService } from 'src/app/services/service.index';
import { Carta } from '../../model/carta.model';
import { Router } from '@angular/router';

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


  carta: Carta = new Carta();

  cargando = false;
  idioma: any[] = []
  tipoCartas: any[] = []
  selectOption: any;


  constructor(private idiomasService: IdiomasService,
    private tipoCartaService: TipoCartaService,
    private router: Router ,
    private artasGeneradasService: CartasGeneradasService) {

    this.operacionSeleccionada = this.tipoOperaciones[0];
    this.artasGeneradasService.hacerCOnsulta = true;
    this.artasGeneradasService.cartasGeneradas = [];
  }

  ngOnInit() {

    this.idioma = JSON.parse (localStorage.getItem('idioma'));

    this.idiomasService.changeIdioma.subscribe((dat) => {

      this.carta.idIdiomas = dat.id;
      this.carta.idTipo = null;

      this.cargando = true;
      this.idiomasService.cargarTipoCartas(dat.id).subscribe((tipoCartas => {
        this.tipoCartas = tipoCartas;
        this.cargando = false;
      }));
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

  generarCart(data: any) {
    this.carta.idTipo = data.id;
    this.tipoCartaService.crearTipoCartas(this.carta).subscribe( data => {
      console.log(data);
    });
  }

  verListPdf(data: any) {

    let obj = { idIdioma: this.carta.idIdiomas, idTipo:  data.id };


    this.artasGeneradasService.getCartas( obj).subscribe( ( data: any) => {
      this.artasGeneradasService.cartasGeneradas = data;
      this.artasGeneradasService.hacerCOnsulta = !this.artasGeneradasService.cartasGeneradas;
      if (data) {
        this.router.navigate(['/cartasGeneradas']);
      }
    });
  }

}
