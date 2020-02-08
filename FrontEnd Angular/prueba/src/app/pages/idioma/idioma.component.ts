import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IdiomasService } from 'src/app/services/service.index';

@Component({
  selector: 'app-idioma',
  templateUrl: './idioma.component.html',
  styleUrls: ['./idioma.component.css']
})
export class IdiomaComponent implements OnInit {

  @Input() idioma: any[];

  constructor( private idiomasService: IdiomasService) { }

  ngOnInit() {
  }

  optionSlect(op) {
    this.idiomasService.changeIdioma.emit(op);
  }

}
