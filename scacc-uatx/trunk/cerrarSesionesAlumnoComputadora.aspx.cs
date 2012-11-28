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
        //matSalT = lAlumno.SelectedValue.ToString();
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
       // lAlumno.Items.Clear();

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
                lAlumno.Text = resultado[0].ToString();

                //lAlumno.Items.Add(resultado[0].ToString());
            }
            resultado.Close();
            Conexion.Close();
        }

        catch (MySqlException ex)
        {
            // Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
        }
    }
    protected void cerrarSesionAlumno_Click(object sender, EventArgs e)
    {


        Boolean rSalida = false;

        if (lAlumno.Text == "")
        {
            statusS.Text = "Selecciona Sala y Computadoras";
        }
        else
        {
            String cons = "select hora_salida from computadora_apartada where matricula_alumno=" + lAlumno.Text + ";";
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

                String consulta = "UPDATE computadoras SET disponibilidad = '1' WHERE id_computadora = (select id_computadora from computadora_apartada where matricula_alumno=" + lAlumno.Text.Trim() + " and hora_salida='00:00:00');";

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

                    statusS.Text = "Se ha registrado satisfactoriamente tu Salida ";
                }
                catch (MySqlException ex)
                {
                    //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                    statusS.Text = "No se puede realizar operacion, Verifica tus Datos";
                }
                //////////////////////////////////////////////////////////



                String hora = "'" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "'";

                consulta = "UPDATE computadora_apartada SET hora_salida = " + hora + " WHERE matricula_alumno =" + lAlumno.Text + " and hora_salida='00:00:00'";
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

                    consulta = "UPDATE `laboratorio`.`computadoras` SET `disponibilidad` = '1' WHERE `id_computadora` = (select id_computadora from computadora_apartada where matricula_alumno=" + lAlumno.Text.ToString() + " and hora_salida='00:00:00');";



                    Conexion.Close();

                    statusS.Text = "Se ha registrado satisfactoriamente tu Salida ";

                }
                catch (MySqlException ex)
                {
                    //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                    statusS.Text = "No se puede realizar operacion, Verifica tus Datos";
                }

                //////////////////////////////////////////////////


                ///////////////////////////////////////////////////////
            }
        }
    }

    protected void bCerrarSesiones_Click(object sender, EventArgs e)
    {
        //String[] nMatriculas;
        int nMatriculas=0;
        String cons = "SELECT count(*) FROM laboratorio.computadora_apartada where	hora_salida ='00:00:00';";
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
                nMatriculas = Convert.ToInt32(resultado[0].ToString());
            }
        }

        catch (MySqlException ex)
        {
            nMatriculas=0;
        }

        /////////////////
        String[] matriculas =new String[nMatriculas];
        cons = "SELECT matricula_alumno FROM laboratorio.computadora_apartada where hora_salida ='00:00:00';";
        try
        {
            MySqlConnection Conexion = new MySqlConnection();
            String cadena;
            cadena = "Server=localhost; user=root; database=Laboratorio";
            Conexion.ConnectionString = cadena;
            Conexion.Open();

            MySqlCommand command = new MySqlCommand(cons, Conexion);
            MySqlDataReader resultado = command.ExecuteReader();
            int i = 0;
            while (resultado.Read())
            {
                matriculas[i] = resultado[0].ToString();
                i++;
            }
        }

        catch (MySqlException ex)
        {
            matriculas = new String[0];
        }
        ////////////////////////////////////////////////////////////




        Boolean flag = true;
         int j = 0;
         String hora = "";
         String consulta = "";

         ///////////////////////////////////////
         j = 0;
         flag = true;
         while (flag)
         {

             if (j >= nMatriculas)
                 flag = false;
             else
             {

                 consulta = "UPDATE computadoras SET disponibilidad = '1' WHERE id_computadora = (select id_computadora from computadora_apartada where matricula_alumno=" + matriculas[j] + " and hora_salida='00:00:00');";

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

                     statusCTS.Text = "Se ha registrado satisfactoriamente tu Salida ";
                 }
                 catch (MySqlException ex)
                 {
                     //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                     statusCTS.Text = "No se puede realizar operacion, Verifica tus Datos";
                 }
                 j++;
             }

         }






        //////////////
         consulta = "";

         ///////////////////////////////////////
         j = 0;
         flag = true;

        while(flag){

            if (j >= nMatriculas)
            {
                flag = false;
            }
            else
            {
                hora = "'" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "'";

                consulta = "UPDATE computadora_apartada SET hora_salida = " + hora + " WHERE matricula_alumno =" + matriculas[j] + " and hora_salida='00:00:00'";
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

                    Conexion.Close();
                    statusCTS.Text = "Accion Realizada";

                }
                catch (MySqlException ex)
                {
                    //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                    statusCTS.Text = "No se puede realizar operacion, Verifica tus Datos";
                }

                j++;
            }
    }
        





    }
}