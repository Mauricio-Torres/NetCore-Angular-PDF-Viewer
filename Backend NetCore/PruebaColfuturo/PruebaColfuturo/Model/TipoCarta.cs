using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaColfuturo.Model
{
    public class TipoCarta
    {
        [Key]
        public int Id { set; get; }
        public string Nombre { set; get; }
        public virtual Idioma Idiomas { get; set; }
    }
}
