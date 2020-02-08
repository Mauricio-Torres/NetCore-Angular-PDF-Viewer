using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaColfuturo.Model
{
    public class CartaGenerada
    {
        [Key]
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Titulo { set; get; }
        public string Cargo { set; get; }
        public string Organizacion { set; get; }
        public string Direccion { set; get; }
        public string Ciudad { set; get; }
        public string Pais { set; get; }
        public string urlPdf { set; get; }
        public string namePdf { set; get; }
        public virtual Usuario Usuarios { get; set; }
        public virtual Idioma Idiomas { get; set; }

    }
}
