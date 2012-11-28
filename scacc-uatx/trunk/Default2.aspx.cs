using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
public partial class Default2 : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        

        try
        {
            var doc = new iTextSharp.text.Document();
            string path = Server.MapPath("PDFs");
            PdfWriter.GetInstance(doc, new FileStream(path + "/Doc1.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph(TextBox1.Text.ToString()+"\n"));

            string imagepath = Server.MapPath("Images");
            Image gif = Image.GetInstance(imagepath + "/escudo_uat.png");
           


            PdfPTable table = new PdfPTable(3);
            PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            table.AddCell(gif);
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            table.AddCell("Col 1 Row 2");
            table.AddCell("Col 2 Row 2");
            table.AddCell("Col 3 Row 2");
            doc.Add(table);


            doc.Close();


            Response.Redirect("PDFs/Doc1.pdf");
        }
        catch (IOException ex) { 
            
        }

    }
  
}