using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class bsala : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        try
        {

            MySqlCommand Cm;
            MySqlConnection Cn;

            Cn = new MySqlConnection();
            Cn.ConnectionString = "Server=localhost; User id=root; Database=Laboratorio";
            Cn.Open();
            Cm = new MySqlCommand("DELETE FROM salas WHERE id_sala = " + idbsala.Text + "", Cn);
            Cm.ExecuteNonQuery();
            Cn.Close();
            Response.Write(@"<script language='javascript'>alert('Eliminacion Realizada')</script>");
            idbsala.Text = "";
            Label1.Text = "Datos guardados";
        }
        catch (MySqlException es)
        {

            //Response.Write(@"<script language='javascript'>alert('Error :P')</script>");
            Label1.Text = "Verifica Datos";
            Label1.Text = "Primero Debes eliminar todas las computadoras de las sala"+idbsala.Text;
        }
    }
    
}