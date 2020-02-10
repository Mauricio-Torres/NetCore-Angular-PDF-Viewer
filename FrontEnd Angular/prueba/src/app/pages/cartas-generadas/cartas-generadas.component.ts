import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ModalComponent } from '../modal/modal.component';
import { Carta } from '../../model/carta.model';
import { TipoCartaService, CartasGeneradasService } from 'src/app/services/service.index';

@Component({
  selector: 'app-cartas-generadas',
  templateUrl: './cartas-generadas.component.html',
  styleUrls: ['./cartas-generadas.component.css']
})
export class CartasGeneradasComponent implements OnInit, OnDestroy {

  cartasGeneradas: Carta[] = [];

  constructor(public dialog: MatDialog,
    private tipoCartaService: TipoCartaService,
    private artasGeneradasService: CartasGeneradasService ) {

  }

  ngOnDestroy(): void {

  }

  openDialog(carta: Carta): void {

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '250px',
      data: {url: carta.urlPdf }
    });

    dialogRef.afterClosed().subscribe(result => {

      console.log(result);
    });
  }

  ngOnInit() {
    this.cartasGeneradas = this.artasGeneradasService.cartasGeneradas;
    this.consultarData({ idIdioma: 0,  idTipo: 0 });
}

  consultarData(objConsulta: any) {

    if (this.cartasGeneradas.length === 0 && this.artasGeneradasService.hacerCOnsulta) {

      this.artasGeneradasService.getCartas( objConsulta).subscribe((data: any) => {

        this.cartasGeneradas = data;
      });
    }

  }

}
