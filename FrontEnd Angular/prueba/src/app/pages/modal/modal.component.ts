import { Component, OnInit, Inject } from '@angular/core';
import { DialogData } from './dialog.data';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { URL_SERVICE } from 'src/app/Config/config';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { CartasGeneradasService } from 'src/app/services/service.index';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  urlPDF: any;
  constructor(public dialogRef: MatDialogRef<ModalComponent>,
    @Inject( MAT_DIALOG_DATA ) public data: DialogData,
    public http: HttpClient, private cartasGeneradasService: CartasGeneradasService) { }

  ngOnInit() {

    this.cartasGeneradasService.getCarta(this.data.url).subscribe(

      data => {

        var byteCharacters = atob(data);
        var byteNumbers = new Array(byteCharacters.length);
        for (var i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        this.urlPDF = new Uint8Array(byteNumbers);

      });


    console.log(this.data)
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
