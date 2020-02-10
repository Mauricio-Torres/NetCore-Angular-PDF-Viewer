export class Carta  {

  constructor(
    public id: any= 0,
    public nombre: string = '',
    public apellido: string = '',
    public titulo: string = '',
    public cargo: string = '',
    public organizacion: string = '',
    public direccion: string = '',
    public ciudad: string = '',
    public pais: string = '',
    public idUsuarios?: any,
    public idIdiomas?: any,
    public idTipo?: any,
    public namePdf: string = '',
    public urlPdf: string = '') { }
}
