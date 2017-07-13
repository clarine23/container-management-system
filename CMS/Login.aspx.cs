using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class Login : System.Web.UI.Page
    {
        DBHelper dbHelper = new DBHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                if (Session["Username"] != null)
                {
                    Response.Redirect("Default.aspx", true);
                }
            }
            catch (Exception err)
            {
                lblMessage.Text = "If any error has occurred, please contact the developer.";
                throw err;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    lblMessage.Text = "Field(s) must be all filled in!";
                }
                else
                {
                    string query = "SELECT username, password FROM EndUser WHERE username = @username AND password = @password";
                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    parameterList.Add(new SqlParameter("@username", txtUsername.Text));
                    parameterList.Add(new SqlParameter("@password", txtPassword.Text));
                    DataTable dt = dbHelper.ExecuteQuery(query, CommandType.Text, parameterList);

                    if (dt.Rows.Count > 0)
                    {
                        Session["Username"] = Convert.ToString(dt.Rows[0]["Username"]);
                        Response.Redirect("Default.aspx", true);
                    }
                    else
                    {
                        lblMessage.Text = "Wrong username or password!";
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                    }
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