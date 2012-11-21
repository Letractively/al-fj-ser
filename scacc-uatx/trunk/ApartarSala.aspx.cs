using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    public String idSalaT = "";
    public String idComT = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        idSalaT = listSala.SelectedValue.ToString();
        idComT = listComputadora.SelectedValue.ToString();
                listSala.Items.Clear();
                String cons = "select id_sala from salas;";
                try
                {
                    MySqlConnection Conexion = new MySqlConnection();
                    String cadena;
                    cadena = "Server=localhost; user=root; database=Laboratorio";
                    Conexion.ConnectionString = cadena;
                    Conexion.Open();

                    MySqlCommand command = new MySqlCommand(cons, Conexion);
                    MySqlDataReader resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        listSala.Items.Add(resultado[0].ToString());
                    }
                    resultado.Close();
                    Conexion.Close();
                }

                catch (MySqlException ex)
                {
                    // Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                }
    }



    protected void listSala_SelectedIndexChanged1(object sender, EventArgs e)
    {
        listComputadora.Items.Clear();

    
        String cons = "select id_computadora from computadoras where id_sala="+idSalaT+";";
      //  statusMaquina.Text = cons;
      
        try
        {
            MySqlConnection Conexion = new MySqlConnection();
            String cadena;
            cadena = "Server=localhost; user=root; database=Laboratorio";
            Conexion.ConnectionString = cadena;
            Conexion.Open();

            MySqlCommand command = new MySqlCommand(cons, Conexion);
            MySqlDataReader resultado = command.ExecuteReader();

            while (resultado.Read())
            {
                listComputadora.Items.Add(resultado[0].ToString());
            }
            resultado.Close();
            Conexion.Close();
        }

        catch (MySqlException ex)
        {
            // Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
        }
    }
    protected void bRegistrar_Click(object sender, EventArgs e)
    {

    }
}
