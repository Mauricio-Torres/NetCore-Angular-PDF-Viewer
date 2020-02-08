using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PruebaColfuturo.DataBase;
using PruebaColfuturo.Model.OutputModel;

namespace PruebaColfuturo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/resultados")]
        public GetAllOutput Resultados()
        {
            try
            {
                var usuario = _context.Usuario.FirstOrDefault();
                var idiaoma = _context.Idioma.ToList();
                var menu = obtenerMenu();

                var retorno = new GetAllOutput()
                {
                    Usuario = usuario,
                    Idioma = idiaoma,
                    Menu = menu
                };

                return retorno;
            }
            catch (Exception e)
            {
                return new GetAllOutput();
            }
        }

        private List<Menu> obtenerMenu()
        {


            return new List<Menu>() {  
                new Menu() {
                titulo="Cartas de Patrocinio",
                icono= "mdi mdi-gauge",
                path = "/dashboard"
            },

             new Menu() {
                titulo="Lista de cartas generadas",
                icono= "mdi mdi-account-box-outline",
                path = "/cartasGeneradas"
            },
            };
        }
    }


    public class Menu
    {
        public string titulo { set; get;}
        public string icono { set; get; }
        public string path { set; get; }


    }

    public class SubMenu
    {
        public string titulo { set; get; }
        public string path { set; get; }

    }
}
