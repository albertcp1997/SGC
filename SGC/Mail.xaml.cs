using iTextSharp.text;
using iTextSharp.text.pdf;
using SGC.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGC
{
    /// <summary>
    /// Lógica de interacción para Mail.xaml
    /// </summary>
    public partial class Mail : Window
    {
        string pathpdf;
        string host;
        string puerto;
        Facturas fc;
        List<IVAs> iva;
        public Mail(Facturas f, List<IVAs> liva, string h, string p, List<Clientes> c)
        {
            InitializeComponent();
            fc = f;
            iva = liva;
            pathpdf= GenPDF(f, liva);
            source.Text= Properties.Settings.Default.Mail;
            pass.Password = Properties.Settings.Default.pssw;
            if (((Clientes)c.Find(x => x.nombre_completo.Equals(f.Nombre_Cliente))) != null)
                source2.Text = ((Clientes)c.Find(x => x.nombre_completo.Equals(f.Nombre_Cliente))).mail;
            else
                source2.Text = f.Mail;
            host = h;
            puerto = p;
            asunto.Text = Properties.Settings.Default.Asunto;
            Cuerpo.Text = Properties.Settings.Default.Cuerpo;

        }
        public Mail()
        {
            InitializeComponent();
        }
        private string GenPDF(Facturas f, List<IVAs> liva)
        {

            
                float iva21 = 0;
                float iva10 = 0;
                float iva4 = 0;
                float ivaotros = 0;
                float descuento = 0;
                float totals = 0;

                string pathPDF = Directory.GetCurrentDirectory()+@"\Facturas_plantilla.pdf";
                string pdfname = f.Numero_Factura.Replace(" ", "_") + "_" + f.Nombre_Cliente + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".pdf";
                pdfname.Trim();
                pdfname = @"\" + pdfname;
                string filename = Directory.GetCurrentDirectory() + pdfname;


                string pathPDF2 = filename;

                //Objeto para leer el pdf original
                iTextSharp.text.pdf.PdfReader oReader = new iTextSharp.text.pdf.PdfReader(pathPDF);
                //Objeto que tiene el tamaño de nuestro documento
                iTextSharp.text.Rectangle oSize = oReader.GetPageSizeWithRotation(1);
                //documento de itextsharp para realizar el trabajo asignandole el tamaño del original
                Document oDocument = new Document(oSize);

                // Creamos el objeto en el cual haremos la inserción
                FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
                PdfWriter oWriter = PdfWriter.GetInstance(oDocument, oFS);
                oDocument.Open();


                PdfContentByte oPDF = oWriter.DirectContent;



                //bf = BaseFont.CreateFont("Calibri", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                oPDF.SetColorFill(BaseColor.BLACK);
                //oPDF.SetFontAndSize(bf, 9);
                Font titleFont = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
                Font subtitleFont = FontFactory.GetFont("Calibri", 10, new BaseColor(123, 123, 122));
                Font importantNoticeFont = FontFactory.GetFont("Calibri", 10, new BaseColor(123, 123, 122));
                Font importantNoticeFont2 = FontFactory.GetFont("Calibri", 10, new BaseColor(123, 123, 122));
                iTextSharp.text.Paragraph docTitle = new iTextSharp.text.Paragraph(f.Empresa, titleFont);
                iTextSharp.text.Paragraph subTitle = new iTextSharp.text.Paragraph(f.Direccion_Facturacion, subtitleFont);
                iTextSharp.text.Paragraph importantNotice = new iTextSharp.text.Paragraph(f.CP_Facturacion + ", " + f.Poblecion_Facturacion + ", " + f.Pais_Facturacion, importantNoticeFont);
                iTextSharp.text.Paragraph importantNotice2 = new iTextSharp.text.Paragraph("Telf. " + f.Telefono_Camping, importantNoticeFont2);


                PdfPCell cell = new PdfPCell();
                PdfPCell cellCaveat = new PdfPCell();
                PdfPCell cellImportantNote = new PdfPCell();
                PdfPCell cellImportantNote2 = new PdfPCell();
                PdfPTable table;
                PdfContentByte pcb = oWriter.DirectContent;


                table = new PdfPTable(1); // the arg is the number of columns

                cell = new PdfPCell(docTitle);


                cell.Border = PdfPCell.NO_BORDER;
                cell.FixedHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cell);
                cellCaveat = new PdfPCell(subTitle);

                cellCaveat.Border = PdfPCell.NO_BORDER;
                cellCaveat.FixedHeight = 15f;
                table.AddCell(cellCaveat);
                cellImportantNote = new PdfPCell(importantNotice);

                cellImportantNote.Border = PdfPCell.NO_BORDER;
                cellImportantNote.FixedHeight = 15f;
                table.AddCell(cellImportantNote);

                cellImportantNote2 = new PdfPCell(importantNotice2);

                cellImportantNote2.Border = PdfPCell.NO_BORDER;
                cell.FixedHeight = 15f;
                table.AddCell(cellImportantNote2);
                
                    iTextSharp.text.Paragraph importantNotice3 = new iTextSharp.text.Paragraph("CIF: B64787906", importantNoticeFont2);
                    cell = new PdfPCell(importantNotice3);
                    cell.Border = PdfPCell.NO_BORDER;
                    cell.FixedHeight = 15f;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(cell);
                
                table.TotalWidth = 595f;
                table.WriteSelectedRows(0, -1, 40, 738, pcb);



                // Now we've added 2 rows: two rows will be shown:



                //////////////////////////////////////////////////////////////////////
                //////
                //Datos Cliente////////////////////////////////////////////////////////
                //////
                //////////////////////////////////////////////////////////////////////

                pcb = oWriter.DirectContent;
                table = new PdfPTable(1);
                table.TotalWidth = 595;

                // there isn't any content in the table: there's nothing to write yet

                // Inner middle row.
                titleFont = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);

                docTitle = new iTextSharp.text.Paragraph("FACTURA PARA", titleFont);

                Font titleFont2 = FontFactory.GetFont("Calibri", 10, new BaseColor(123, 123, 122));
                iTextSharp.text.Paragraph docTitle2 = new iTextSharp.text.Paragraph(f.Nombre_Cliente, titleFont2);

                subtitleFont = FontFactory.GetFont("Calibri", 10, new BaseColor(123, 123, 122));
                iTextSharp.text.Paragraph docTitle7 = new iTextSharp.text.Paragraph(f.DNI_CIF, subtitleFont);
                subTitle = new iTextSharp.text.Paragraph(f.Direccion_Cliente, subtitleFont);

                importantNoticeFont = FontFactory.GetFont("Calibri", 10, new BaseColor(123, 123, 122));
                importantNotice = new iTextSharp.text.Paragraph(f.CP_Cliente + ", " + f.Poblacio_Cliente, importantNoticeFont);

                importantNoticeFont2 = FontFactory.GetFont("Calibri", 10, new BaseColor(123, 123, 122));
                importantNotice2 = new iTextSharp.text.Paragraph(f.Provincia_Cliente + ", " + f.Pais_Cliente, importantNoticeFont2);

                Font titleFont3 = FontFactory.GetFont("Calibri", 10, 1, BaseColor.BLACK);
                iTextSharp.text.Paragraph docTitle3 = new iTextSharp.text.Paragraph("Factura", titleFont3);

                Font titleFont4 = FontFactory.GetFont("Calibri", 8, 1, BaseColor.BLACK);
                iTextSharp.text.Paragraph docTitle4 = new iTextSharp.text.Paragraph("Fecha:", titleFont4);


                Font titleFont5 = FontFactory.GetFont("Calibri", 8, new BaseColor(123, 123, 122));
                iTextSharp.text.Paragraph docTitle5 = new iTextSharp.text.Paragraph(f.Numero_Factura, titleFont5);

                Font titleFont6 = FontFactory.GetFont("Calibri", 8, new BaseColor(123, 123, 122));
                iTextSharp.text.Paragraph docTitle6 = new iTextSharp.text.Paragraph(f.fecha.ToString("dd/MM/yyyy"), titleFont6);

                PdfPCell espacio2; PdfPCell espacio3;

                table = new PdfPTable(1);
                cell = new PdfPCell(docTitle2);
                cell.Border = PdfPCell.NO_BORDER;
                cell.FixedHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cell);
                cell = new PdfPCell(docTitle7);
                cell.FixedHeight = 15f;
                cell.Border = PdfPCell.NO_BORDER;

                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cell);


                cellCaveat = new PdfPCell(subTitle);

                cellCaveat.Border = PdfPCell.NO_BORDER;
                cell.FixedHeight = 15f;
                table.AddCell(cellCaveat);
                cellImportantNote = new PdfPCell(importantNotice);

                cellImportantNote.Border = PdfPCell.NO_BORDER;
                cell.FixedHeight = 15f;
                table.AddCell(cellImportantNote);

                cellImportantNote2 = new PdfPCell(importantNotice2);

                cellImportantNote2.Border = PdfPCell.NO_BORDER;
                cell.FixedHeight = 15f;
                //table.AddCell(cellImportantNote2);




                // Now we've added 2 rows: two rows will be shown:
                table.TotalWidth = 595f;
                table.WriteSelectedRows(0, -1, 400, 738, pcb);


                
                    table = new PdfPTable(1); cell = new PdfPCell(docTitle3);
                    cell.Border = PdfPCell.NO_BORDER;

                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(cell);
                    cellCaveat = new PdfPCell(docTitle4);

                    cellCaveat.Border = PdfPCell.NO_BORDER;

                    //table.AddCell(cellCaveat);
                    table.TotalWidth = 595f;
                    table.WriteSelectedRows(0, -1, 400, 665, pcb);

                    table = new PdfPTable(1); cell = new PdfPCell(docTitle5);
                    cell.Border = PdfPCell.NO_BORDER;

                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    //table.AddCell(cell);
                    cellCaveat = new PdfPCell(docTitle6);

                    cellCaveat.Border = PdfPCell.NO_BORDER;

                    //table.AddCell(cellCaveat);
                    table.TotalWidth = 595f;
                    table.WriteSelectedRows(0, -1, 470, 665, pcb);
                
                //////////////////////////////////////////////////////////////////////
                //////
                //Tabla Pedido////////////////////////////////////////////////////////
                //////
                //////////////////////////////////////////////////////////////////////
                ///
                table = new PdfPTable(6);
                float[] anchoDeColumnas = new float[] { 10f, 10f, 10f, 10f, 10f, 10f };
                table.SetWidthPercentage(anchoDeColumnas, oDocument.PageSize);
                //table.DefaultCell.Border = PdfPCell.BOTTOM_BORDER;
                table.DefaultCell.BorderWidthBottom = 5;

                table.DefaultCell.BorderColorBottom = new BaseColor(12, 105, 66);
                titleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));

                docTitle = new iTextSharp.text.Paragraph("NUM FACTURA", titleFont);
                
                titleFont3 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(123, 123, 122));
                docTitle3 = new iTextSharp.text.Paragraph(Math.Round(f.Importe, 2) + " €", titleFont3);
                docTitle3.Alignment = Element.ALIGN_LEFT;
                docTitle4 = new iTextSharp.text.Paragraph(" ", titleFont);
                titleFont2 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                docTitle2 = new iTextSharp.text.Paragraph("FECHA.", titleFont2);
                docTitle2.Alignment = Element.ALIGN_LEFT;
                subtitleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                subTitle = new iTextSharp.text.Paragraph("IMPORTE TOTAL", subtitleFont);

                cell = new PdfPCell();
                cell.AddElement(docTitle);

                cell.PaddingTop = -0;
                cell.FixedHeight = 20;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER; ;
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.PaddingTop = -0;
                f.Numero_Factura.Replace("__", "_");
                iTextSharp.text.Paragraph pppp = new iTextSharp.text.Paragraph(f.Numero_Factura, titleFont3);
               
                pppp.Alignment = Element.ALIGN_LEFT;
                cell.AddElement(pppp);
                cell.FixedHeight = 20;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                cell.VerticalAlignment = PdfPCell.ALIGN_LEFT;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cell);

                cellCaveat = new PdfPCell();
                pppp = new iTextSharp.text.Paragraph("FECHA FACTURA", titleFont2);
                
                pppp.Alignment = Element.ALIGN_RIGHT;
                pppp.SpacingAfter = 50;
                cellCaveat.AddElement(pppp);
                cellCaveat.PaddingTop = -0;
                cellCaveat.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                cellCaveat.FixedHeight = 20;
                cellCaveat.BorderColor = new BaseColor(12, 105, 66);
                cellCaveat.VerticalAlignment = Element.ALIGN_CENTER;
                cellCaveat.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cellCaveat);

                cell = new PdfPCell();
                pppp = new iTextSharp.text.Paragraph(f.fecha.ToString("dd/MM/yyyy"), titleFont3);
                
                pppp.Alignment = Element.ALIGN_CENTER;
                cell.AddElement(pppp);
                cell.PaddingTop = -0;
                cell.PaddingLeft = 10;
                cell.FixedHeight = 20;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);

                cellCaveat = new PdfPCell();
                PdfPCell espacio = new PdfPCell();
                espacio.AddElement(subTitle);
                espacio.PaddingTop = -0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                cell = new PdfPCell();
                cell.AddElement(docTitle3);
                cell.PaddingTop = -0;
                cell.FixedHeight = 20;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);

                table.TotalWidth = 520;
                table.WriteSelectedRows(0, -1, 40, 610, pcb);

                table = new PdfPTable(5);
                anchoDeColumnas = new float[] { 37f, 15f, 15f, 15f, 15f };
                table.SetWidthPercentage(anchoDeColumnas, oDocument.PageSize);
                //table.DefaultCell.Border = PdfPCell.BOTTOM_BORDER;
                table.DefaultCell.BorderWidthBottom = 5;

                table.DefaultCell.BorderColorBottom = new BaseColor(12, 105, 66);
                titleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                docTitle = new iTextSharp.text.Paragraph("Descripción", titleFont);
                titleFont3 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(123, 123, 122));
                docTitle3 = new iTextSharp.text.Paragraph("Camping", titleFont3);


                docTitle4 = new iTextSharp.text.Paragraph(" ", titleFont);

                titleFont2 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                docTitle2 = new iTextSharp.text.Paragraph("CANTIDAD.", titleFont2);

                subtitleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                subTitle = new iTextSharp.text.Paragraph("Precio", subtitleFont);
                Font subtitleFont2 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                iTextSharp.text.Paragraph subTitle2 = new iTextSharp.text.Paragraph("Tipo IVA", subtitleFont);
                subTitle2.PaddingTop = 0;
                Font subtitleFont3 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                iTextSharp.text.Paragraph subTitle3 = new iTextSharp.text.Paragraph("Importe", subtitleFont);

                cell = new PdfPCell();
                cell.AddElement(docTitle);
                cell.FixedHeight = 20;
                cell.PaddingTop = 0;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.BOTTOM_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cellCaveat = new PdfPCell();

                cellCaveat.AddElement(docTitle2);

                cellCaveat.Border = PdfPCell.BOTTOM_BORDER;

                cellCaveat.PaddingTop = 0;
                cellCaveat.FixedHeight = 20;
                cellCaveat.BorderColor = new BaseColor(12, 105, 66);

                cellCaveat.VerticalAlignment = Element.ALIGN_CENTER; ;

                cellCaveat.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cellCaveat);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle);
                espacio.PaddingTop = 0;

                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle2);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle3);
                espacio.PaddingTop = 0;

                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);



                table.TotalWidth = 520;
                table.WriteSelectedRows(0, -1, 40, 590, pcb);


                int i = 0;
                table = new PdfPTable(5);
                float tasa = 0;
                foreach (Producto s in f.Lista_productos)
                {
                    if (s.Nombre_Producto.ToLower().Contains("tasa turistica"))
                    {
                        tasa += float.Parse(s.Precio.Replace("€", "")) * float.Parse(s.Cantidad.Replace("€", ""));
                    }
                    if (liva.Find(x => x.Id == int.Parse(s.IVA)).Porcentaje.Equals("21"))
                    {
                        iva21 += float.Parse(s.Cantidad) * float.Parse(s.Precio.Replace("€", "")) * 0.21f;
                    }
                    else if (liva.Find(x => x.Id == int.Parse(s.IVA)).Porcentaje.Equals("10"))
                    {
                        iva10 += float.Parse(s.Cantidad) * float.Parse(s.Precio.Replace("€", "")) * 0.10f;
                    }
                    else
                    {
                        ivaotros += float.Parse(s.Cantidad) * float.Parse(s.Precio.Replace("€", "")) * int.Parse(liva.Find(x => x.Id == int.Parse(s.IVA)).Porcentaje) / 100;
                    }
                    totals += float.Parse(s.Descuento.Replace("€", ""));

                    anchoDeColumnas = new float[] { 40f, 15f, 15f, 15f, 15f };
                    table.SetWidthPercentage(anchoDeColumnas, oDocument.PageSize);
                    //table.DefaultCell.Border = PdfPCell.BOTTOM_BORDER;
                    table.DefaultCell.BorderWidthBottom = 5;

                    table.DefaultCell.BorderColorBottom = new BaseColor(12, 105, 66);
                    titleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(38, 38, 38));
                    docTitle = new iTextSharp.text.Paragraph(s.Nombre_Producto, titleFont);
                    titleFont3 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                    docTitle3 = new iTextSharp.text.Paragraph(s.Cantidad, titleFont3);


                    docTitle4 = new iTextSharp.text.Paragraph(" ", titleFont);

                    titleFont2 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                    docTitle2 = new iTextSharp.text.Paragraph(s.Cantidad, titleFont2);

                    subtitleFont = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                    subTitle = new iTextSharp.text.Paragraph(s.Precio, subtitleFont);
                    subtitleFont2 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                    subTitle2 = new iTextSharp.text.Paragraph(liva.Find(x => x.Id == int.Parse(s.IVA)).Tipo, subtitleFont);
                    subtitleFont3 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                    subTitle3 = new iTextSharp.text.Paragraph(s.Total, subtitleFont);
                    if (i == f.Lista_productos.Count() - 1)
                    {
                        cell = new PdfPCell();
                        cell.AddElement(docTitle);
                        cell.FixedHeight = 20;
                        cell.BorderColor = new BaseColor(123, 123, 122);
                        cell.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER;
                        cell.VerticalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingTop = -0;
                        table.AddCell(cell);

                        cellCaveat = new PdfPCell();

                        cellCaveat.AddElement(docTitle2);

                        cellCaveat.PaddingLeft = 10;
                        cellCaveat.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER;
                        cellCaveat.FixedHeight = 20;
                        cellCaveat.BorderColor = new BaseColor(123, 123, 122);
                        cellCaveat.PaddingTop = -0;
                        cellCaveat.VerticalAlignment = Element.ALIGN_TOP;

                        cellCaveat.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(cellCaveat);

                        espacio = new PdfPCell();
                        espacio.AddElement(subTitle);
                        espacio.VerticalAlignment = Element.ALIGN_TOP;
                        espacio.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER;
                        espacio.FixedHeight = 20;
                        espacio.PaddingTop = -0;
                        espacio.BorderColor = new BaseColor(123, 123, 122);

                        espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(espacio);

                        espacio = new PdfPCell();
                        espacio.AddElement(subTitle2);

                        espacio.PaddingLeft = 10;
                        espacio.PaddingTop = -0;
                        espacio.VerticalAlignment = Element.ALIGN_TOP;
                        espacio.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER;
                        espacio.FixedHeight = 20;
                        espacio.BorderColor = new BaseColor(123, 123, 122);

                        espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(espacio);

                        espacio = new PdfPCell();
                        espacio.AddElement(subTitle3);
                        espacio.PaddingTop = -0;

                        espacio.VerticalAlignment = Element.ALIGN_TOP; ;
                        espacio.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER;
                        espacio.FixedHeight = 20;
                        espacio.BorderColor = new BaseColor(123, 123, 122);

                        espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(espacio);
                    }
                    else
                    {
                        cell = new PdfPCell();
                        cell.AddElement(docTitle);
                        cell.FixedHeight = 20;
                        cell.BorderColor = new BaseColor(123, 123, 122);
                        cell.Border = PdfPCell.TOP_BORDER;
                        cell.VerticalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingTop = -0;
                        table.AddCell(cell);

                        cellCaveat = new PdfPCell();

                        cellCaveat.AddElement(docTitle2);

                        cellCaveat.PaddingLeft = 10;
                        cellCaveat.Border = PdfPCell.TOP_BORDER;
                        cellCaveat.FixedHeight = 20;
                        cellCaveat.BorderColor = new BaseColor(123, 123, 122);
                        cellCaveat.PaddingTop = -0;
                        cellCaveat.VerticalAlignment = Element.ALIGN_TOP;

                        cellCaveat.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(cellCaveat);

                        espacio = new PdfPCell();
                        espacio.AddElement(subTitle);
                        espacio.VerticalAlignment = Element.ALIGN_TOP;
                        espacio.Border = PdfPCell.TOP_BORDER;
                        espacio.FixedHeight = 20;
                        espacio.PaddingTop = -0;
                        espacio.BorderColor = new BaseColor(123, 123, 122);

                        espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(espacio);

                        espacio = new PdfPCell();
                        espacio.AddElement(subTitle2);

                        espacio.PaddingLeft = 10;
                        espacio.PaddingTop = -0;
                        espacio.VerticalAlignment = Element.ALIGN_TOP;
                        espacio.Border = PdfPCell.TOP_BORDER;
                        espacio.FixedHeight = 20;
                        espacio.BorderColor = new BaseColor(123, 123, 122);

                        espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(espacio);

                        espacio = new PdfPCell();
                        espacio.AddElement(subTitle3);
                        espacio.PaddingTop = -0;

                        espacio.VerticalAlignment = Element.ALIGN_TOP; ;
                        espacio.Border = PdfPCell.TOP_BORDER;
                        espacio.FixedHeight = 20;
                        espacio.BorderColor = new BaseColor(123, 123, 122);

                        espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(espacio);


                    }
                    //List<String> l2 = s.Split('*').ToList();

                    i++;
                }
                table.TotalWidth = 520;
                table.WriteSelectedRows(0, -1, 40, 570, pcb);

                table = new PdfPTable(8);
                table.DefaultCell.BorderWidthBottom = 5;

                table.DefaultCell.BorderColorBottom = new BaseColor(12, 105, 66);
                titleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                docTitle = new iTextSharp.text.Paragraph("IMPORTE NETO", titleFont);
                titleFont3 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(123, 123, 122));


                titleFont2 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                docTitle2 = new iTextSharp.text.Paragraph("DESC", titleFont2);

                docTitle2.Alignment = Element.ALIGN_CENTER;
                subtitleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                subTitle = new iTextSharp.text.Paragraph("BASE IMP.", subtitleFont);
                subTitle.Alignment = Element.ALIGN_CENTER;
                subtitleFont2 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                subTitle2 = new iTextSharp.text.Paragraph("IMP. TUR", subtitleFont);
                subTitle2.Alignment = Element.ALIGN_CENTER;
                subtitleFont3 = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                subTitle3 = new iTextSharp.text.Paragraph("(1) IVA 21%", subtitleFont);
                subTitle3.Alignment = Element.ALIGN_CENTER;
                iTextSharp.text.Paragraph subTitle4 = new iTextSharp.text.Paragraph("(2) 10%", subtitleFont);
                subTitle4.Alignment = Element.ALIGN_CENTER;
                iTextSharp.text.Paragraph subTitle5 = new iTextSharp.text.Paragraph("(3) OTROS%", subtitleFont);
                subTitle5.Alignment = Element.ALIGN_CENTER;
                iTextSharp.text.Paragraph subTitle6 = new iTextSharp.text.Paragraph("TOTAL", subtitleFont);
                subTitle6.Alignment = Element.ALIGN_RIGHT;
                cell = new PdfPCell();
                cell.AddElement(docTitle);

                cell.PaddingTop = 0;
                cell.FixedHeight = 20;
                cell.PaddingTop = 0;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cellCaveat = new PdfPCell();

                cellCaveat.AddElement(docTitle2);

                cellCaveat.PaddingTop = 0;
                cellCaveat.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;

                cellCaveat.PaddingTop = 0;
                cellCaveat.FixedHeight = 20;
                cellCaveat.BorderColor = new BaseColor(12, 105, 66);

                cellCaveat.VerticalAlignment = Element.ALIGN_CENTER; ;

                cellCaveat.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cellCaveat);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle);
                espacio.PaddingTop = 0;

                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle2);

                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle3);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);
                espacio = new PdfPCell();
                espacio.AddElement(subTitle4);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);
                espacio = new PdfPCell();
                espacio.AddElement(subTitle5);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);
                espacio = new PdfPCell();
                espacio.AddElement(subTitle6);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                table.DefaultCell.BorderColorBottom = new BaseColor(123, 123, 122);
                titleFont = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                docTitle = new iTextSharp.text.Paragraph(f.BI.ToString("0.00") + " €", titleFont);
                titleFont3 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));

                titleFont2 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                docTitle2 = new iTextSharp.text.Paragraph(f.Descuento + " (" + f.Descuento + "%)", titleFont2);

                docTitle2.Alignment = Element.ALIGN_CENTER;
                subtitleFont = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                subTitle = new iTextSharp.text.Paragraph(f.BI.ToString("0.00") + " €", subtitleFont);
                subTitle.Alignment = Element.ALIGN_CENTER;
                subtitleFont2 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                subTitle2 = new iTextSharp.text.Paragraph(tasa.ToString("0.00") + " €", subtitleFont);
                subTitle2.Alignment = Element.ALIGN_CENTER;
                subtitleFont3 = FontFactory.GetFont("Calibri", 9, 1, BaseColor.BLACK);
                subTitle3 = new iTextSharp.text.Paragraph(iva21.ToString("0.00") + " €", subtitleFont);
                subTitle3.Alignment = Element.ALIGN_CENTER;
                subTitle4 = new iTextSharp.text.Paragraph(iva10.ToString("0.00") + " €", subtitleFont);
                subTitle4.Alignment = Element.ALIGN_CENTER;
                subTitle5 = new iTextSharp.text.Paragraph(ivaotros.ToString("0.00") + " €", subtitleFont);
                subTitle5.Alignment = Element.ALIGN_CENTER;
                subTitle6 = new iTextSharp.text.Paragraph(Math.Round(f.Importe, 2) + " €", subtitleFont3);
                subTitle6.Alignment = Element.ALIGN_RIGHT;
                cell = new PdfPCell();
                cell.AddElement(docTitle);

                cell.PaddingTop = 0;
                cell.FixedHeight = 20;
                cell.PaddingTop = 0;
                cell.BorderColor = new BaseColor(123, 123, 122);
                cell.Border = PdfPCell.BOTTOM_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cellCaveat = new PdfPCell();

                cellCaveat.AddElement(docTitle2);

                cellCaveat.PaddingTop = 0;
                cellCaveat.Border = PdfPCell.BOTTOM_BORDER;

                cellCaveat.PaddingTop = 0;
                cellCaveat.FixedHeight = 20;
                cellCaveat.BorderColor = new BaseColor(123, 123, 122);

                cellCaveat.VerticalAlignment = Element.ALIGN_CENTER; ;

                cellCaveat.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cellCaveat);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle);
                espacio.PaddingTop = 0;

                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(123, 123, 122);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle2);

                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(123, 123, 122);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle3);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(123, 123, 122);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);
                espacio = new PdfPCell();
                espacio.AddElement(subTitle4);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(123, 123, 122);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);
                espacio = new PdfPCell();
                espacio.AddElement(subTitle5);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(123, 123, 122);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);
                espacio = new PdfPCell();
                espacio.AddElement(subTitle6);
                espacio.PaddingTop = 0;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(123, 123, 122);
                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);



                table.TotalWidth = 520;
                table.WriteSelectedRows(0, -1, 40, 150, pcb);
                table = new PdfPTable(4);
                anchoDeColumnas = new float[] { 10f, 40f, 10f, 40f };
                table.SetWidthPercentage(anchoDeColumnas, oDocument.PageSize);
                //table.DefaultCell.Border = PdfPCell.BOTTOM_BORDER;
                table.DefaultCell.BorderWidthBottom = 5;

                table.DefaultCell.BorderColorBottom = new BaseColor(12, 105, 66);
                titleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                docTitle = new iTextSharp.text.Paragraph("METODO PAGO", titleFont);
                titleFont3 = FontFactory.GetFont("Calibri", 9, 0, new BaseColor(123, 123, 122));
                string ss = "Tarjeta";

                if (f.Metodo_Pago == 2)
                {
                    ss = "Transferencia";
                }
                else if (f.Metodo_Pago == 3)
                {
                    ss = "Efectivo";

                }


                titleFont2 = FontFactory.GetFont("Calibri", 8, 0, new BaseColor(123, 123, 122));
                docTitle2 = new iTextSharp.text.Paragraph(ss, titleFont2);

                docTitle2.Alignment = Element.ALIGN_LEFT;
                subtitleFont = FontFactory.GetFont("Calibri", 9, 1, new BaseColor(12, 105, 66));
                subTitle = new iTextSharp.text.Paragraph("", subtitleFont);
                subTitle.Alignment = Element.ALIGN_CENTER;
                if (f.Metodo_Pago == 2)
                {
                    subTitle = new iTextSharp.text.Paragraph("IBAN", subtitleFont);
                }
            subtitleFont2 = FontFactory.GetFont("Calibri", 8, 0, new BaseColor(123, 123, 122));
                subTitle2 = new iTextSharp.text.Paragraph(f.IBAN, subtitleFont2);
                subTitle2.Alignment = Element.ALIGN_LEFT;

                cell = new PdfPCell();
                cell.AddElement(docTitle);

                cell.PaddingTop = 0;
                cell.FixedHeight = 20;
                cell.PaddingTop = 0;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                cellCaveat = new PdfPCell();

                cellCaveat.AddElement(docTitle2);

                cellCaveat.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;

                cellCaveat.PaddingTop = 1;
                cellCaveat.FixedHeight = 20;
                cellCaveat.BorderColor = new BaseColor(12, 105, 66);

                cellCaveat.VerticalAlignment = Element.ALIGN_CENTER; ;

                cellCaveat.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cellCaveat);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle);
                espacio.PaddingTop = 0;

                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                espacio = new PdfPCell();
                espacio.AddElement(subTitle2);

                espacio.PaddingTop = 1;
                espacio.VerticalAlignment = Element.ALIGN_CENTER; ;
                espacio.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;
                espacio.FixedHeight = 20;
                espacio.BorderColor = new BaseColor(12, 105, 66);

                espacio.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(espacio);

                table.TotalWidth = 520;
                table.WriteSelectedRows(0, -1, 40, 70, pcb);

                table = new PdfPTable(1);

                titleFont = FontFactory.GetFont("Calibri", 8, 0, new BaseColor(12, 105, 66));
                docTitle = new iTextSharp.text.Paragraph(f.Direccion_Facturacion + " | " + f.CP_Facturacion + ", " + f.Poblecion_Facturacion + " (" + f.Provincia_Facturacion + ") | Tlf." + f.Telefono_Camping + " | info@campingmontserrat.cat", titleFont);
                docTitle.Alignment = Element.ALIGN_CENTER;

                cell = new PdfPCell();
                //cell.AddElement(docTitle);

                cell.PaddingTop = 0;
                cell.FixedHeight = 20;
                cell.PaddingTop = 0;
                cell.BorderColor = new BaseColor(12, 105, 66);
                cell.Border = PdfPCell.NO_BORDER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                //table.AddCell(cell);
                table.TotalWidth = 520;
                table.WriteSelectedRows(0, -1, 40, 25, pcb);
                //table = new PdfPTable(2);

                //crea una nueva pagina y agrega el pdf original

                // Cerramos los objetos utilizados
                
                    PdfImportedPage page = oWriter.GetImportedPage(oReader, 1);
                    oPDF.AddTemplate(page, 0, 0);
                
                oDocument.Close();
                oFS.Close();
                oWriter.Close();
                oReader.Close();

            return filename;


        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fromAddress = new MailAddress(source.Text, "Camping Montserrat Factura");
                var toAddress = new MailAddress(source2.Text, "To Name");
                string fromPassword = pass.Password;
                string subject = asunto.Text;
                string body = Cuerpo.Text;
                Properties.Settings.Default.Mail = source.Text;
                Properties.Settings.Default.pssw = pass.Password;
                Properties.Settings.Default.Save();
                var smtp = new SmtpClient
                {
                    Host = host,
                    Port = int.Parse(puerto),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = subject;
                    message.Body = body;
                    if (!System.IO.File.Exists(pathpdf))
                    {
                        pathpdf = GenPDF(fc, iva);
                    }
                        message.Attachments.Add(new Attachment(pathpdf));

                    smtp.Send(message);
                    smtp.Dispose();
                }             
                
                if (System.IO.File.Exists(pathpdf))
                {
                    System.IO.File.Delete(pathpdf);
                }

                this.Close();
            }
            catch (Exception ee){
                Console.WriteLine(ee.Message);
                MessageBox.Show("Error! Compruebe si esta bien configurado el mail desde sistema", "Alerta!", MessageBoxButton.OK, MessageBoxImage.Error);

                if (System.IO.File.Exists(pathpdf))
                {
                    System.IO.File.Delete(pathpdf);
                }
            }
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                addall2_Click(addall2, new RoutedEventArgs());
            }
        }
    }
}
