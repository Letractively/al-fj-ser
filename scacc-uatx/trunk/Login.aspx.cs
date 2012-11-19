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
       
        panLogin.Visible = false;
        
    }
    protected void bRegistrar_Click(object sender, EventArgs e)
    {
        String user = tUser.Text;
        String password = tPassword.Text;
        String email = tEmail.Text;
        String nombre = tNombre.Text;
        String aPaterno = taPaterno.Text;
        String aMaterno = taMaterno.Text;

        if (user.Equals("") || password.Equals("") || email.Equals("") || nombre.Equals("") || aPaterno.Equals("") || aMaterno.Equals(""))
        {
            statusRegister.Text=" VERIFICA TUS DATOS";
        }
        else{
            //INSERT INTO `laboratorio`.`administrador` (`id_administrador`, `nombre`, `aPaterno`, `aMaterno`, `email`, `user`, `password`) VALUES ('1', 'Sergio', 'Molina', 'Guarneros', 'scmg_57@hotmail.com', 'SerWolf', 'lobito11');
            String consulta = "Insert into administrador values (null, '" + nombre + "', '" + aPaterno + "', '" + aMaterno + "', '" + email + "', '" + user + "', '" + password + "'" + ");";

            // statusRegister.Text = consulta;

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
                //Response.Write("<script language='javascript'>alert('Usuario Registrado')</script>");

                panLogin.Visible = true;
                panRegister.Visible = false;
                // Response.Redirect("LoginU.aspx");
            }
            catch (MySqlException ex)
            {
                //Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                statusRegister.Text = " Verifica tus Datos";
            }
        }
        
        
    }
}