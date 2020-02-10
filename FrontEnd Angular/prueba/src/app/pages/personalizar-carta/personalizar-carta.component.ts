import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormArray, FormControl, Validators, FormBuilder, AbstractControl } from '@angular/forms';
import { Carta } from 'src/app/model/carta.model';

@Component({
  selector: 'app-personalizar-carta',
  templateUrl: './personalizar-carta.component.html',
  styleUrls: ['./personalizar-carta.component.css']
})
export class PersonalizarCartaComponent implements OnInit {

  tipoOperaciones = [ 'Senor', 'Senora', 'Senores' ];
  operacionSeleccionada: any;
  public formGroup: FormGroup;
  carta: Carta = new Carta();

  @Output() usuarioRemito = new EventEmitter();


  constructor(private formBuilder: FormBuilder ) {
  }

  ngOnInit() {
    this.buildForm();
  }

  optionSlect(){


    this.carta.nombre = this.formGroup.controls.nombre.value;
    this.carta.apellido = this.formGroup.controls.apellido.value;
    this.carta.titulo = this.formGroup.controls.titulo.value;
    this.carta.cargo = this.formGroup.controls.cargo.value;
    this.carta.organizacion = this.formGroup.controls.organizacion.value;
    this.carta.direccion = this.formGroup.controls.nombre.value;
    this.carta.ciudad = this.formGroup.controls.ciudad.value;
    this.carta.pais = this.formGroup.controls.pais.value;


    this.usuarioRemito.emit(this.carta);
  };

  private buildForm() {

    this.formGroup = this.formBuilder.group({
      titulo: this.operacionSeleccionada,
      nombre: [],
      apellido: [],
      cargo: [],
      organizacion: [],
      ciudad: [],
      pais: []
    });
  }

}
