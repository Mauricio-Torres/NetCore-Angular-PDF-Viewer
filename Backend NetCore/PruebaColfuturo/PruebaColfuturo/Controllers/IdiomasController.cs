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
    public class IdiomasController : ControllerBase
    {
        private readonly DataContext _context;

        public IdiomasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Idiomas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idioma>>> GetIdioma()
        {
            return await _context.Idioma.ToListAsync();
        }

    }
}
