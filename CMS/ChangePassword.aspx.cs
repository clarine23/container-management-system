using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        DBHelper dbHelper = new DBHelper();

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

        protected void btnSave_Click(object sender, EventArgs e)
        {          
            try
            {
                string username = Convert.ToString(Session["Username"]);

                string query = "SELECT password FROM EndUser WHERE username = @username";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                parameterList.Add(new SqlParameter("@username", username));
                DataTable dt = dbHelper.ExecuteQuery(query, CommandType.Text, parameterList);

                string oldPassword = Convert.ToString(dt.Rows[0]["password"]);

                if (txtOldPassowrd.Text == "" || txtNewPassword.Text == "" || txtConfirmPassword.Text == "")
                {
                    lblMessage.Text = "Field(s) must be all filled in!";
                }
                else if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    lblMessage.Text = "Password and Confirm Passowrd Mismatch!";
                }
                else if (!txtOldPassowrd.Text.Equals(oldPassword))
                {
                    lblMessage.Text = "Wrong Old Password!";
                }
                else
                {
                    string query2 = "UPDATE EndUser SET password = @password WHERE username = @username";
                    List<SqlParameter> parameterList2 = new List<SqlParameter>();
                    parameterList2.Add(new SqlParameter("@username", username));
                    parameterList2.Add(new SqlParameter("@password", txtNewPassword.Text));
                    bool result = dbHelper.ExecuteNonQuery(query2, CommandType.Text, parameterList2);

                    if(result)
                    {
                        lblMessage.Text = "Password has changed;";
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