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
        if (Request.Cookies["usuarioAdmin"] == null)
        {
           // lblMensaje.Text = "La cookie no existe, imposible leerla";

            panLogin.Visible = true;
            panRegister.Visible=true;
            pSesionIniciada.Visible = false;
        }
        else
        {
            lSesionIniciada.Text = Server.HtmlEncode(Request.Cookies["usuarioAdmin"].Value);
            panLogin.Visible = false;
            panRegister.Visible = false;
            pSesionIniciada.Visible = true;
        }
      
        
    }
    protected void bRegistrar_Click(object sender, EventArgs e)
    {
        String user = tUser.Text;
        String password = passwordT.Text;
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
    protected void bLogin_Click(object sender, EventArgs e)
    {
    
            String usuario, password;
            String user = userT.Text;
            String passw = passwordT.Text;
            String cons = "select user, password from administrador where user='" + user + "' and password='" + passw + "';";
            verificarDatos.Text = cons;
            try
            {
                MySqlConnection Conexion = new MySqlConnection();
                String cadena;
                cadena = "Server=localhost; user=root; database=Laboratorio";
                Conexion.ConnectionString = cadena;
                Conexion.Open();

                MySqlCommand command = new MySqlCommand(cons, Conexion);
                MySqlDataReader resultado = command.ExecuteReader();

                if (resultado.HasRows)
                {
                    // usuario = resultado[0].ToString();
                    //password = resultado[1].ToString();

                    verificarDatos.Text = "Datos validos";
                    if (Request.Cookies["usuarioAdmin"] == null)
                    {
                        Response.Cookies["usuarioAdmin"].Value = user;
                        panLogin.Visible = false;
                        pSesionIniciada.Visible = true;
                        Response.Redirect("Default.aspx");
                    }


                }
                else
                verificarDatos.Text = "Datos no Validos";
                resultado.Close();
                Conexion.Close();



            }
            catch (MySqlException ex)
            {
                // Response.Write("<script language='javascript'>alert('Verifica tus Datos')</script>");
                verificarDatos.Text = "Usuario o Contraseña no validos ";
            }
      
    }
    protected void bCerrarSesion_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["usuarioAdmin"] != null)
        {
            Response.Cookies["usuarioAdmin"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("Default.aspx");
        }
    }
}