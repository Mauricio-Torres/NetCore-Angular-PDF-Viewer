using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaColfuturo.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { set; get; }
        public string Nombre { set; get; }
        public int Cedula { set; get; }
        public string Profesion { set; get; }
        public string Titulo { set; get; }
        public string Universidad { set; get; }
        public string Trabajo { set; get; }
        public virtual ICollection<CartaGenerada> IdCartas { get; set; }
    }
}
