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
    public partial class UpdateCon : System.Web.UI.Page
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
                else
                {
                    if (!Page.IsPostBack)
                    {
                        string query = "SELECT containerId FROM Container WHERE status = @status";
                        List<SqlParameter> parameterList = new List<SqlParameter>();
                        parameterList.Add(new SqlParameter("@status", "Occupied"));
                        DataTable dt = dbHelper.ExecuteQuery(query, CommandType.Text, parameterList);

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dropContainer.Items.Insert(i, new ListItem(Convert.ToString(dt.Rows[i]["containerId"])));
                            }
                        }

                        string query2 = "SELECT * FROM Container WHERE containerId = @containerId";
                        List<SqlParameter> parameterList2 = new List<SqlParameter>();
                        parameterList2.Add(new SqlParameter("@containerId", dropContainer.Text));
                        DataTable dt2 = dbHelper.ExecuteQuery(query2, CommandType.Text, parameterList2);

                        if (dt2.Rows.Count > 0)
                        {
                            dropStatus.Items.Insert(0, new ListItem(Convert.ToString(dt2.Rows[0]["status"])));
                            dropStatus.Items.Insert(1, new ListItem("Empty"));
                            lblCompany.Text = Convert.ToString(dt2.Rows[0]["company"]);
                            lblLocation.Text = Convert.ToString(dt2.Rows[0]["location"]);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {                
                string username = Convert.ToString(Session["Username"]);
                string query = "UPDATE Container SET status = @status, updatedBy = @username, location = @location, updatedDate = @date";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                parameterList.Add(new SqlParameter("@status", "Empty"));
                parameterList.Add(new SqlParameter("@username", username));
                parameterList.Add(new SqlParameter("@location", ""));
                parameterList.Add(new SqlParameter("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                bool result = dbHelper.ExecuteNonQuery(query, CommandType.Text, parameterList);

                if (result)
                {
                    lblMessage.Text = dropContainer.Text + " is updated.";
                }
                else
                {
                    lblMessage.Text = "Unhandled error has occurred, please contact the developer.";
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