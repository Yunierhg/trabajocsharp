using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace prueba_pdf_receta
{
    public class PdfReceta
    {
        #region URLS
        //string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\Recetas Medicas");
        string carpeta = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Recetas Medicas";
        //string img = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "\\assets\\img\\logo.png");
        string img = $"{Directory.GetCurrentDirectory()}\\assets\\img\\logo.png";

        Uri uri = new Uri("pack://application:,,,/assets//img/logo.png");
       
        #endregion
        public void crearPdfReceta(string nombrePdf)
        {

            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            Document doc = new Document(PageSize.A6);
            doc.SetMargins(8, 8, 8, 8);
            var output = new FileStream($"{carpeta}\\{nombrePdf}.pdf", FileMode.Create);
            var Writer = PdfWriter.GetInstance(doc, output);

            
            //Writer.PageEvent = new PDFFooter();

            doc.Open();


            PdfPTable table1 = new PdfPTable(12);
            table1.DefaultCell.Border = 0;
            table1.WidthPercentage = 90;
            table1.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cell1 = new PdfPCell();
            cell1.Colspan = 2;
            cell1.BorderWidth = 0;
            cell1.AddElement(new Paragraph(15, "Nombre:", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));

            PdfPCell cell2 = new PdfPCell();
            cell2.Colspan = 10;
            cell2.BorderWidthLeft = 0;
            cell2.BorderWidthRight = 0;
            cell2.BorderWidthTop = 0;
            cell2.HorizontalAlignment = 0;
            cell2.AddElement(new Paragraph(15, "Nombre Nombre Apellido Apellido", new Font(Font.FontFamily.HELVETICA, 9)));



            PdfPCell cell3 = new PdfPCell();
            cell3.Colspan = 2;
            cell3.BorderWidth = 0;
            cell3.AddElement(new Paragraph(15, "Edad:", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));

            PdfPCell cell4 = new PdfPCell();
            cell4.Colspan = 2;
            //cell2.BorderWidth = 0;
            cell4.BorderWidthLeft = 0;
            cell4.BorderWidthRight = 0;
            cell4.BorderWidthTop = 0;
            cell4.HorizontalAlignment = 0;
            cell4.AddElement(new Paragraph(15, "45 Años", new Font(Font.FontFamily.HELVETICA, 9)));



            PdfPCell cell5 = new PdfPCell();
            cell5.Colspan = 4;
            cell5.BorderWidth = 0;
            cell5.AddElement(new Paragraph(15, "C. Identificación:", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));

            PdfPCell cell6 = new PdfPCell();
            cell6.Colspan = 4;
            cell6.BorderWidthLeft = 0;
            cell6.BorderWidthRight = 0;
            cell6.BorderWidthTop = 0;
            cell6.HorizontalAlignment = 0;
            cell6.AddElement(new Paragraph(15, "18536511-5", new Font(Font.FontFamily.HELVETICA, 9)));

            PdfPCell cell7 = new PdfPCell();
            cell7.Colspan = 3;
            cell7.BorderWidth = 0;
            cell7.AddElement(new Paragraph(15, "Dirección:", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));

            PdfPCell cell8 = new PdfPCell();
            cell8.Colspan = 9;
            //cell2.BorderWidth = 0;
            cell8.BorderWidthLeft = 0;
            cell8.BorderWidthRight = 0;
            cell8.BorderWidthTop = 0;
            cell8.HorizontalAlignment = 0;
            cell8.AddElement(new Paragraph(15, "AV. LAS QUINTAS 539", new Font(Font.FontFamily.HELVETICA, 9)));



            PdfPCell cell13 = new PdfPCell();
            cell13.Colspan = 12;
            cell13.BorderWidth = 0;
            cell13.AddElement(new Paragraph(30, "Rp.", new Font(Font.FontFamily.TIMES_ROMAN, 13, Font.BOLD)));

            PdfPCell cell14 = new PdfPCell();
            cell13.Colspan = 12;
            cell13.BorderWidth = 0;
            cell13.AddElement(new Paragraph(15, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new Font(Font.FontFamily.TIMES_ROMAN , 9)));


            string url = "http://altasalud.cl/img/logo.1445268882.png";
            Image jpg = iTextSharp.text.Image.GetInstance(new Uri(url));

            PdfPCell cell11 = new PdfPCell(jpg);

            cell11.FixedHeight = 45;
            cell11.HorizontalAlignment = Element.ALIGN_CENTER;
            cell11.VerticalAlignment = Element.ALIGN_MIDDLE;
            jpg.ScaleAbsolute(150, 35);
            cell11.Colspan = 12;
            cell11.BorderWidth = 0;

            

            PdfPCell cell12 = new PdfPCell();
            cell12.Colspan = 1;
            cell12.BorderWidth = 0;
            cell12.AddElement(new Paragraph(""));



            PdfPCell cell9 = new PdfPCell();
            cell9.Colspan = 3;
            cell9.BorderWidth = 0;
            cell9.AddElement(new Paragraph(15, "Fch Emisión:", new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)));

            PdfPCell cell10 = new PdfPCell();
            cell10.Colspan = 9;
            cell10.BorderWidthLeft = 0;
            cell10.BorderWidthRight = 0;
            cell10.BorderWidthTop = 0;
            cell10.HorizontalAlignment = 1;
            cell10.AddElement(new Paragraph(15, "22-05-2019", new Font(Font.FontFamily.HELVETICA, 9)));


            PdfPTable tableHeader = new PdfPTable(12);
            tableHeader.DefaultCell.Border = 0;
            tableHeader.WidthPercentage = 90;
            tableHeader.HorizontalAlignment = Element.ALIGN_CENTER;



            tableHeader.AddCell(cell11);
            tableHeader.AddCell(cell12);
            

            table1.AddCell(cell1);
            table1.AddCell(cell2);
            table1.AddCell(cell3);
            table1.AddCell(cell4);
            table1.AddCell(cell5);
            table1.AddCell(cell6);
            table1.AddCell(cell7);
            table1.AddCell(cell8);
            table1.AddCell(cell9);
            table1.AddCell(cell10);
            table1.AddCell(cell13);
            table1.AddCell(cell14);
            


            doc.Add(tableHeader);
            doc.Add(table1);

            doc.Close();
        }
    }


    public class PDFFooter : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer  
        PdfContentByte cb;

        // we will put the final number of pages in a template  
        PdfTemplate  footerTemplate;

        // this is the BaseFont we are going to use for the header / footer  
        BaseFont bf = null;

        // This keeps track of the creation time  
        DateTime PrintTime = DateTime.Now;

        #region Fields  
        private string _header;
        #endregion

        #region Properties  
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion

        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                //headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(100, 50);
            }
            catch (DocumentException de)
            {
            }
            catch (System.IO.IOException ioe)
            {
            }
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            
            base.OnEndPage(writer, document);

            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            

            //Create PdfTable object  
            PdfPTable pdfTab = new PdfPTable(3);

            //We will have to create separate cells to include image logo and 2 separate strings  
            //Row 1  
            String text = "Desarrollado por: www.efebyte.com ";


            //Add paging to footer  
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 6);
                cb.SetTextMatrix(document.PageSize.GetRight(180), document.PageSize.GetBottom(10));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 6);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(10));
            }

            

            //set the alignment of all three cells and set border to 0  
            

            //add all three cells into PdfTable  

            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 70;
            //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;      

            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable  
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write  
            //Third and fourth param is x and y position to start writing  
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            //set pdfContent value  

            //Move the pointer and draw line to separate footer section from rest of page  
            cb.MoveTo(40, document.PageSize.GetBottom(50));
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            cb.Stroke();
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 6);
            footerTemplate.SetTextMatrix(0, 0);
            //footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();
        }
    }

}
