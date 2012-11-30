using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class bpc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       string aux="DELETE FROM computadoras  WHERE id_computadora="+TextBox2.Text;
        try
        {
          
            MySqlCommand Cm;
            MySqlConnection Cn;

            Cn = new MySqlConnection();
            Cn.ConnectionString = "Server=localhost; User id=root; Database=laboratorio";
            Cn.Open();
            Cm = new MySqlCommand(aux,Cn);
            Cm.ExecuteNonQuery();
            Cn.Close();
            Response.Write(@"<script language='javascript'>alert('Eliminacion Realizada')</script>");
            TextBox1.Text = "";
        }
        catch (MySqlException es)
        {
            //Response.Write(@"<script language='javascript'>alert('Error :P')</script>");
            Label1.Text = aux;
        }
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
 
}