using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["usuarioAdmin"] == null)
        {
            bRS.Visible = true;   
        }
        else
        {
            lLogin.Visible=true;
            lLogin.Text = Server.HtmlEncode(Request.Cookies["usuarioAdmin"].Value);
            bCerrarS.Visible = true;
        }

    }
    protected void bRS_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void bCerrarS_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["usuarioAdmin"] != null)
        {
            Response.Cookies["usuarioAdmin"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("Default.aspx");
        }
    }
}
