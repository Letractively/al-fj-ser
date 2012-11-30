using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String aux = "INSERT INTO sala_apartada values(null," + TextBox2.Text + ", " + TextBox3.Text + ", '" + TextBox6.Text + "', '" + TextBox7.Text + "');";
        try
        {
            MySqlConnection Cn;
            MySqlCommand Cm;
            String cadena;
            Cn = new MySqlConnection();
            cadena = "Server=localhost; user=root; database=Laboratorio";
            Cn.ConnectionString = cadena;
            Cn.Open();
            /////Insertar/////
            Cm = new MySqlCommand(aux, Cn);
            Cm.ExecuteNonQuery();
            Cn.Close();
            Label1.Text = "Datos Guardados";
            //Response.Write(@"<script language='javascript'>alert('realizada')</script>");
        }

        catch (MySqlException es)
        {
           // Response.Write(@"<script language='javascript'>alert('Error')</script>");
            Label1.Text = "No se Pudo regsitrar Entrada"; 
        }
    }
}