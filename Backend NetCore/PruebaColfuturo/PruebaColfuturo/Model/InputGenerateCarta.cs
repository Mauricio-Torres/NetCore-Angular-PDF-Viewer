using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaColfuturo.Model
{
    public class InputGenerateCarta
    {
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Titulo { set; get; }
        public string Cargo { set; get; }
        public string Organizacion { set; get; }
        public string Direccion { set; get; }
        public string Ciudad { set; get; }
        public string Pais { set; get; }
        public  int? IdUsuarios { get; set; }
        public int? IdIdiomas { get; set; }
        public int? IdTipo { get; set; }
        public string NamePdf { set; get; }

    }
}
