using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaColfuturo.Model
{
    public class Idioma
    {
        [Key]
        public int Id { set; get; }
        public string Nombre { set; get; }
        public virtual ICollection<TipoCarta> TipoCarta { get; set; }

    }
}
