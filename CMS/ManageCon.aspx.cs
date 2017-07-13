using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class ManageCon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                lblMessage.Text = "";
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx", true);
                }
            }
            catch (Exception err)
            {
                lblMessage.Text = "If any error has occurred, please contact the developer.";
                throw err;
            }
        }
    }
}