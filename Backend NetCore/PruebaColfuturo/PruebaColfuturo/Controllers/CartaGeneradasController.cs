using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaColfuturo.DataBase;
using PruebaColfuturo.Model;
using PruebaColfuturo.Utils;

namespace PruebaColfuturo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaGeneradasController : ControllerBase
    {
        private readonly DataContext _context;
        private IHostingEnvironment _env;
        private string namePdf = "";
        private string file = "";

        public CartaGeneradasController(DataContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/CartaGeneradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartaGenerada>>> GetCartaGenerada()
        {
            return await _context.CartaGenerada.ToListAsync();
        }

        [HttpGet]
        [Route("/getCarta")]
        public byte[] GetCarta(int id)
        {
            var dat = _context.CartaGenerada.FirstOrDefault(carta => carta.Id == id);

            if (dat != null)
            {

                if (System.IO.File.Exists(dat.urlPdf))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(dat.urlPdf);
                    return bytes;
                }
                else
                {
                    return null;
                }
             
            }

            return null;
            
        }

        [HttpGet]
        [Route("/cartasGeneradas")]

        public List<CartaGenerada> GetCartasGeneradas(string select)
        {

            var selectCarta = JsonConvert.DeserializeObject<InputConsultarCarta>(select);

            if (selectCarta.IdIdioma > 0 || selectCarta.IdTipo > 0)
            {
                return (from cg in _context.CartaGenerada
                             join i in _context.Idioma on cg.Idiomas.Id equals i.Id
                             join tc in _context.TipoCarta on i.Id equals tc.Idiomas.Id
                             where cg.Idiomas.Id == selectCarta.IdIdioma && tc.Id == selectCarta.IdTipo
                             select cg).ToList();
            } else {
                
                return _context.CartaGenerada.ToList();
            }            
        }

        [HttpGet]
        [Route("/generarPdf")]
        public bool CreateCarta(string inputDate)
        {
            var inputGenerateCarta = JsonConvert.DeserializeObject<InputGenerateCarta>(inputDate);

            try
            {
                var query = (from i in _context.Idioma
                             join tc in _context.TipoCarta on i.Id equals tc.Idiomas.Id
                             where i.Id == inputGenerateCarta.IdIdiomas && tc.Id == inputGenerateCarta.IdTipo
                             select new { idioma = i.Nombre, tipo = tc.Nombre }).FirstOrDefault();

                if (query != null)
                {
                    inputGenerateCarta.NamePdf = DateTime.Now.ToString("yyyy-MM-dd HHmmss") + " " + query?.idioma + " " + query?.tipo;
                }
                else
                {
                    inputGenerateCarta.NamePdf = DateTime.Now.ToString("yyyy-MM-dd HHmmss");
                }

                GeneratePDFFile_Click( inputGenerateCarta);
                insertGeneratePdf(inputGenerateCarta);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }


        private void insertGeneratePdf(InputGenerateCarta inputGenerateCarta )
        {
            var idiomas =_context.Idioma.FirstOrDefault(i => i.Id == inputGenerateCarta.IdIdiomas);
            var usuario = _context.Usuario.FirstOrDefault(i => i.Id == inputGenerateCarta.IdUsuarios);
           
            var cartaGenerada = new CartaGenerada()
            {
                Nombre = inputGenerateCarta.Nombre,
                Apellido = inputGenerateCarta.Apellido,
                Titulo = inputGenerateCarta.Titulo,
                Cargo = inputGenerateCarta.Cargo,
                Organizacion = inputGenerateCarta.Organizacion,
                Direccion = inputGenerateCarta.Direccion,
                Ciudad = inputGenerateCarta.Ciudad,
                Idiomas = idiomas,
                Usuarios = usuario,
                Pais = inputGenerateCarta.Pais,
                namePdf = namePdf,
                urlPdf = file
            };

            _context.CartaGenerada.Add(cartaGenerada);
            _context.SaveChanges();
        } 
        private void GeneratePDFFile_Click(InputGenerateCarta inputGenerateCarta)
        {
            //var webRoot = _env.WebRootPath;
            var path = @"C:\DocsPDF";
            //var pathRoot = Path.GetPathRoot();
            namePdf = inputGenerateCarta.NamePdf + ".pdf";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            file = Path.Combine(path, namePdf);

            Document doc = new Document();
            PdfPTable tableLayout = new PdfPTable(4);
            PdfWriter.GetInstance(doc, new FileStream(file, FileMode.Create));
            doc.Open();
            doc.Add(Add_Content_To_PDF(tableLayout, inputGenerateCarta));
            doc.Close();

        }
        private PdfPTable Add_Content_To_PDF(PdfPTable tableLayout, InputGenerateCarta inputGenerateCarta)
        {
            float[] headers = { 20, 20, 30, 30 }; 
            tableLayout.SetWidths(headers); 
            tableLayout.WidthPercentage = 80; 
                                             
            tableLayout.AddCell(new PdfPCell(new Phrase("Creating PDF", new Font(Font.HELVETICA, 13, 1, new iTextSharp.text.BaseColor(153, 51, 0))))
            {
                Colspan = 4,
                Border = 0,
                PaddingBottom = 20,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            //Add header  
            AddCellToHeader(tableLayout, inputGenerateCarta.Nombre);
            AddCellToHeader(tableLayout, inputGenerateCarta.Apellido);
            AddCellToHeader(tableLayout, inputGenerateCarta.Titulo);
            AddCellToHeader(tableLayout, inputGenerateCarta.Cargo);
            AddCellToHeader(tableLayout, inputGenerateCarta.Organizacion);
            //Add body  
            AddCellToBody(tableLayout, "Los ingenieros de software de ordenador se encargan de analizar, diseñar, crear y probar los sistemas informáticos y de ");
            AddCellToBody(tableLayout, "software. Además, escriben programas de software para satisfacer las necesidades de un cliente o para resolver un");
            AddCellToBody(tableLayout, "problema particular.");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "Los ingenieros de software están involucrados en todas las etapas del desarrollo de un producto de");
            AddCellToBody(tableLayout, "software. Aplican la tecnología de software para satisfacer una necesidad específica o para resolver un");
            AddCellToBody(tableLayout, "problema particular.");
            AddCellToBody(tableLayout, inputGenerateCarta.Pais);
            AddCellToBody(tableLayout, inputGenerateCarta.Ciudad);
            AddCellToBody(tableLayout, inputGenerateCarta.Direccion);
            AddCellToBody(tableLayout, "Saroj Kohli, Prem Kohli");
            return tableLayout;
        }
        // Method to add single cell to the header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 8, 1, iTextSharp.text.BaseColor.Red)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(0, 51, 102)
            });
        }
        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 8, 1, iTextSharp.text.BaseColor.Black)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = iTextSharp.text.BaseColor.White
            });
        }



    }
}
