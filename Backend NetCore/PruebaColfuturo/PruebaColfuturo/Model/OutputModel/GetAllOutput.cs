using PruebaColfuturo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaColfuturo.Model.OutputModel
{
    public class GetAllOutput
    {
        public Usuario Usuario { set; get; }
        public List<Menu> Menu { set; get; }
        public List<Idioma> Idioma { set; get; }
    }
}
