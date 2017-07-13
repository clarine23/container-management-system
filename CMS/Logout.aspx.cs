using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                Session.Clear();
                Response.Redirect("Default.aspx", true);
            }
            catch (Exception err)
            {
                lblMessage.Text = "If any error has occurred, please contact the developer.";
                throw err;
            }
        }
    }
}