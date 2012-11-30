using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class sala : System.Web.UI.Page
{
     
    protected void save_Click(object sender, EventArgs e)
    {
        String cons = "INSERT INTO salas (capacidad,id_sala) VALUES(" + capa.Text + ",'" + name.Text + "')";
        try
        {
            MySqlConnection Cn;
            MySqlCommand Cm;
            String cadena;
            Cn = new MySqlConnection();
            cadena = "Server=localhost; User id=root; Database=Laboratorio";
            Cn.ConnectionString = cadena;
            Cn.Open();
            /////Insertar/////
            
            Cm = new MySqlCommand(cons, Cn);
            Cm.ExecuteNonQuery();
            Cn.Close();
           Response.Write(@"<script language='javascript'>alert('insercion realizada')</script>");
            // Label1.Text = "Datos Guardados";
           
        }
         

        catch (MySqlException es)
        {
            //Response.Write(@"<script language='javascript'>alert('Error')</script>");
            Label1.Text="No se puede realizar la operacion: Verifique Datos";
           // Label1.Text = cons;
        }

        name.Text = "";
        capa.Text = "";
    }
    
}