using System.Diagnostics;
using iTextSharp.text.pdf;
using System;
using System.IO;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using Microsoft.AspNetCore.Hosting;
using PruebaColfuturo.Model;

namespace PruebaColfuturo.Utils
{
    public class GeneratePDF
    {
       
        private IHostingEnvironment _env;
        public InputGenerateCarta inputGenerateCarta { set; get; }
        public GeneratePDF(IHostingEnvironment env)
        {
            _env = env;
        }

        public void GeneratePDFFile_Click()
        {
            var webRoot = _env.WebRootPath;
            var file = Path.Combine(webRoot, inputGenerateCarta.NamePdf);

            Document doc = new Document();
            PdfPTable tableLayout = new PdfPTable(4);
            PdfWriter.GetInstance(doc, new FileStream(file, FileMode.Create));
            doc.Open();
            doc.Add(Add_Content_To_PDF(tableLayout));
            doc.Close();

        }
        private PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            float[] headers = { 100 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 80; //Set the PDF File witdh percentage  
                                              //Add Title to the PDF file at the top  
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
         
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, inputGenerateCarta.Pais);
            AddCellToBody(tableLayout, inputGenerateCarta.Ciudad);
            AddCellToBody(tableLayout, inputGenerateCarta.Direccion);
            AddCellToBody(tableLayout, "Saroj Kohli, Prem Kohli");
            return tableLayout;
        }
        // Method to add single cell to the header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 8, 1, iTextSharp.text.BaseColor.White)))
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
