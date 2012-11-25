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


        String cons = "select id_computadora from computadoras where id_sala=" + idSalaT + " and disponibilidad=1 ;";
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
        Boolean s = false;

        if (tMatriculaAP.Text.Trim() == "")
        {
            statusMaquina.Text = "Debe ingresar Matricula de Alumno";
        }
        else
        {

            String fecha ="'"+DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day+"'";
            String hora = "'" + DateTime.Now.Hour.ToString() + ":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString()+"'";
            String consulta = "Insert into computadora_apartada values (null, " + listComputadora.SelectedValue + ", " + tMatriculaAP.Text + ", " + fecha+ ", " + hora + ");";

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
                s = true;
            }
            catch (MySqlException ex)
            {
                //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                statusMaquina.Text = " Verifica tus Datos";
            }

            ///////
            if (s)
            {

               
                consulta = "UPDATE `laboratorio`.`computadoras` SET `disponibilidad`='0' WHERE `id_computadora`='" + listComputadora.SelectedValue + "'";
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




                }
                catch (MySqlException ex)
                {
                    //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                    statusMaquina.Text = " Verifica tus Datos";
                }

                ///////////////////////////////////////////////

                String cons = "select nombre, aPaterno, aMaterno from alumnos where matricula=" + tMatriculaAP.Text + ";";
                //statusMaquina.Text = cons;
                try
                {
                    MySqlConnection Conexion = new MySqlConnection();
                    String cadena;
                    cadena = "Server=localhost; user=root; database=Laboratorio";
                    Conexion.ConnectionString = cadena;
                    Conexion.Open();

                    MySqlCommand command = new MySqlCommand(cons, Conexion);
                    MySqlDataReader resultado = command.ExecuteReader();

                    if (resultado.Read())
                    {
                        // usuario = resultado[0].ToString();
                        //password = resultado[1].ToString();

                        Label1.Text = resultado[0].ToString();
                        Label2.Text = resultado[1].ToString();
                        Label3.Text = resultado[2].ToString();
                        Panel1.Visible = true;

                    }

                    resultado.Close();
                    Conexion.Close();



                }
                catch (MySqlException ex)
                {
                    // Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                    statusMaquina.Text = cons;
                }


                /////////////////////////////////////

                listComputadora.Items.Clear();


                 cons = "select id_computadora from computadoras where id_sala=" + idSalaT + " and disponibilidad=1 ;";
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



                //////////////////////////
            }

        }
    }

 
}
