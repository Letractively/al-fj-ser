using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bRegistrarSalida_Click(object sender, EventArgs e)
    {
        Boolean rSalida = false;

        if (tMatriculaSalida.Text == "")
        {
            statusSalida.Text = "Debe ingresar Matricula";
        }
        else {
            String cons = "select hora_salida from computadora_apartada where matricula_alumno="+tMatriculaSalida.Text.Trim()+";";
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
                    rSalida = true;
                }
                else
                    rSalida = false;
                resultado.Close();
                Conexion.Close();
            }

            catch (MySqlException ex)
            {
                rSalida = false;
            }


            if (rSalida) 
            {

                /////////////////////////////////////////////////////////

                String consulta = "UPDATE computadoras SET disponibilidad = '1' WHERE id_computadora = (select id_computadora from computadora_apartada where matricula_alumno=" + tMatriculaSalida.Text.Trim()+ " and hora_salida='00:00:00');";
                
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

                    statusSalida.Text = "Se ha registrado satisfactoriamente tu Salida ";
                }
                catch (MySqlException ex)
                {
                    //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                    statusSalida.Text = "No se puede realizar operacion, Verifica tus Datos";
                }
                //////////////////////////////////////////////////////////

                String hora = "'" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "'";
           
                 consulta = "UPDATE computadora_apartada SET hora_salida = "+hora+" WHERE matricula_alumno ="+tMatriculaSalida.Text+" and hora_salida='00:00:00'";
               //statusSalida.Text = consulta;
                
                try
                {
                    MySqlConnection Conexion = new MySqlConnection();
                    String cadena;
                    cadena = "Server=localhost; user=root; database=Laboratorio";
                    Conexion.ConnectionString = cadena;
                    Conexion.Open();
                    MySqlCommand command = new MySqlCommand(consulta, Conexion);
                    
                    command.ExecuteNonQuery();

                    consulta = "UPDATE `laboratorio`.`computadoras` SET `disponibilidad` = '1' WHERE `id_computadora` = (select id_computadora from computadora_apartada where matricula_alumno="+tMatriculaSalida.Text.ToString()+" and hora_salida='00:00:00');";

               

                    Conexion.Close();

                    statusSalida.Text = "Se ha registrado satisfactoriamente tu Salida ";
                    
                }
                catch (MySqlException ex)
                {
                    //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                    statusSalida.Text = "No se puede realizar operacion, Verifica tus Datos";
                }
                //////////////////////////////////////////////////
              

                ///////////////////////////////////////////////////////
            }
            
            
        }

    }
}
