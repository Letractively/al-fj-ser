using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class About : System.Web.UI.Page
{
    private String[] g;

   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        String idSalaT = TextBox4.Text;
        String fecha = "'" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "'";

      // idSalaT=lis

        String consulta = "Insert into mantenimiento values (null, " + fecha + ", " + idSalaT+ ", " + TextBox2.Text.ToString() + ", '" + TextBox3.Text.ToString() + "');";

        // statusMaquina.Text = consulta;

        try
        {
            MySqlConnection Conexion = new MySqlConnection();
            String cadena;
            cadena = "Server=localhost; user=root; database=Laboratorio";
            Conexion.ConnectionString = cadena;
            Conexion.Open();
            MySqlCommand command = new MySqlCommand(consulta, Conexion);
            command.ExecuteNonQuery();
            Conexion.Close();
            Label1.Text = "Datps Guardados";
            //s = true;
        }

        catch (MySqlException ex)
        {
            //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
            Label1.Text = " Verifica tus Datos";
           
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

     


        String cons = "select count(*) from mantenimiento;";
        //  statusMaquina.Text = cons;


        try
        {
            var doc = new iTextSharp.text.Document();
            string path = Server.MapPath("PDFs");
            PdfWriter.GetInstance(doc, new FileStream(path + "/Doc1.pdf", FileMode.Create));
            doc.Open();
           // doc.Add(new Paragraph(TextBox1.Text.ToString() + "\n"));

            string imagepath = Server.MapPath("Images");
            Image gif = Image.GetInstance(imagepath + "/escudo_uat.png");

            doc.Add(gif);


            PdfPTable table = new PdfPTable(5);
            PdfPCell cell = new PdfPCell(new Phrase("Reporte"));
            cell.Colspan = 5;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            
            table.AddCell("No. Mantenimiento");
            table.AddCell("Fecha");
            table.AddCell("Sala");
            table.AddCell("Numero de computadora");
            table.AddCell("Motivo");

            string connect = "Server=localhost; user=root; database=Laboratorio";
            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                string query = "SELECT * from mantenimiento";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            table.AddCell(rdr[0].ToString());
                            table.AddCell(rdr[1].ToString());
                            table.AddCell(rdr[2].ToString());
                            table.AddCell(rdr[3].ToString());
                            table.AddCell(rdr[4].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                //doc.Add(table);
            }




            doc.Add(table);


            doc.Close();

            Response.Redirect("PDFs/Doc1.pdf");
            
        }
        catch (IOException ex)
        {

        }
  
    }
}
