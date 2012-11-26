using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class About : System.Web.UI.Page
{
    public String idSalaT = "";
    public String idComT = "";
    public String matSalT = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        idSalaT = selectSala.SelectedValue.ToString();
        idComT = listComputadora.SelectedValue.ToString();
        matSalT = lAlumno.SelectedValue.ToString();
        selectSala.Items.Clear();
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
                selectSala.Items.Add(resultado[0].ToString());
            }
            resultado.Close();
            Conexion.Close();
        }

        catch (MySqlException ex)
        {
            // Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
        }
    }

    protected void selectSala_SelectedIndexChanged(object sender, EventArgs e)
    {
        listComputadora.Items.Clear();


        String cons = "select id_computadora from computadoras where id_sala=" + idSalaT + " and disponibilidad=0 ;";
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
           listComputadora.Items.Add("");
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

    protected void listComputadora_SelectedIndexChanged(object sender, EventArgs e)
    {
        lAlumno.Items.Clear();


        String cons = "select matricula_alumno from computadora_apartada where id_computadora="+ listComputadora.SelectedValue.ToString()+" and hora_salida='00:00:00'";
        statusS.Text = cons;
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
                
                lAlumno.Items.Add(resultado[0].ToString());
            }
            resultado.Close();
            Conexion.Close();
        }

        catch (MySqlException ex)
        {
            // Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
        }
    }
}

