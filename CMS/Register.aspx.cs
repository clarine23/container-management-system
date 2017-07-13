using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CMS
{
    public partial class Register : System.Web.UI.Page
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "" || txtUserType.Text == null)
                {
                    lblMessage.Text = "Field(s) must be all filled in!";
                }
                else if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    lblMessage.Text = "Password and Confirm Passowrd mismatch!";
                }
                else
                {
                    string query = "SELECT username FROM EndUser WHERE username = @username";
                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    parameterList.Add(new SqlParameter("@username", txtUsername.Text));
                    DataTable dt = dbHelper.ExecuteQuery(query, CommandType.Text, parameterList);

                    if (dt.Rows.Count > 0)
                    {
                        lblMessage.Text = txtUsername.Text + " already registered.";
                    }
                    else
                    {
                        string query2 = "INSERT INTO EndUser VALUES(@username, @password, @usertype)";
                        List<SqlParameter> parameterList2 = new List<SqlParameter>();
                        parameterList2.Add(new SqlParameter("@username", txtUsername.Text));
                        parameterList2.Add(new SqlParameter("@password", txtPassword.Text));
                        parameterList2.Add(new SqlParameter("@usertype", txtUserType.Text));
                        bool result = dbHelper.ExecuteNonQuery(query2, CommandType.Text, parameterList2);
                        if(result)
                        {
                            lblMessage.Text = "Registered Successfully.";                            
                        }
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