using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaColfuturo.DataBase;
using PruebaColfuturo.Model;

namespace PruebaColfuturo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCartasController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoCartasController(DataContext context)
        {
            _context = context;
        }

      

        // GET: api/TipoCartas/5
        [HttpGet("{id}")]
        public List<TipoCarta> GetTipoCarta(int? idIdioma)
        {
            var tipoCarta =  _context.TipoCarta.Where(carta => carta.Idiomas.Id == idIdioma).ToList();

            if (tipoCarta == null)
            {
                return null;
            }

            return tipoCarta;
        }
    }
}
