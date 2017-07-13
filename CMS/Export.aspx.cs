using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class Export : System.Web.UI.Page
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
                        string query = "SELECT yardId FROM Yard WHERE usage = @usage";
                        List<SqlParameter> parameterList = new List<SqlParameter>();
                        parameterList.Add(new SqlParameter("@usage", "Export"));
                        DataTable dt = dbHelper.ExecuteQuery(query, CommandType.Text, parameterList);

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dropYard.Items.Insert(i, new ListItem(Convert.ToString(dt.Rows[i]["yardId"])));
                            }
                        }

                        string query2 = "SELECT gateId FROM Gate WHERE yardId = @yardId";
                        List<SqlParameter> parameterList2 = new List<SqlParameter>();
                        parameterList2.Add(new SqlParameter("@yardId", dropYard.Text));
                        DataTable dt2 = dbHelper.ExecuteQuery(query2, CommandType.Text, parameterList2);

                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                dropGate.Items.Insert(i, new ListItem(Convert.ToString(dt2.Rows[i]["gateId"])));
                            }
                        }

                        string query3 = "SELECT containerId FROM Container WHERE gateId = @gateId AND status = @status";
                        List<SqlParameter> parameterList3 = new List<SqlParameter>();
                        parameterList3.Add(new SqlParameter("@gateId", dropGate.Text));
                        parameterList3.Add(new SqlParameter("@status", "Empty"));
                        DataTable dt3 = dbHelper.ExecuteQuery(query3, CommandType.Text, parameterList3);

                        if (dt3.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt3.Rows.Count; i++)
                            {
                                dropContainer.Items.Insert(i, new ListItem(Convert.ToString(dt3.Rows[i]["containerId"])));
                            }
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try{
                if (dropContainer.Text == null)
                {
                    lblMessage.Text = "No container is available for this moment.";
                }
                else if (txtDestination.Text == null || txtCompany.Text == null)
                {
                    lblMessage.Text = "Field(s) must be all entered!";
                }
                else
                {
                    string username = Convert.ToString(Session["Username"]);
                    string query = "UPDATE Container SET status = @status, updatedBy = @username, company=@company, location = @location, updatedDate = @date WHERE containerId = @containerId";
                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    parameterList.Add(new SqlParameter("@status", "Occupied"));
                    parameterList.Add(new SqlParameter("@username", username));
                    parameterList.Add(new SqlParameter("@company", txtCompany.Text));
                    parameterList.Add(new SqlParameter("@location", txtDestination.Text));
                    parameterList.Add(new SqlParameter("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    parameterList.Add(new SqlParameter("@containerId", dropContainer.Text));
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
            }
            catch (Exception err)
            {
                lblMessage.Text = "If any error has occurred, please contact the developer.";
                throw err;
            }
        }

        protected void dropYard_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query2 = "SELECT gateId FROM Gate WHERE yardId = @yardId";
            List<SqlParameter> parameterList2 = new List<SqlParameter>();
            parameterList2.Add(new SqlParameter("@yardId", dropYard.Text));
            DataTable dt2 = dbHelper.ExecuteQuery(query2, CommandType.Text, parameterList2);

            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    dropGate.Items.Insert(i, new ListItem(Convert.ToString(dt2.Rows[i]["gateId"])));
                }
            }
        }

        protected void dropGate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query3 = "SELECT containerId FROM Container WHERE gateId = @gateId AND status = @status";
            List<SqlParameter> parameterList3 = new List<SqlParameter>();
            parameterList3.Add(new SqlParameter("@gateId", dropGate.Text));
            parameterList3.Add(new SqlParameter("@status", "Empty"));
            DataTable dt3 = dbHelper.ExecuteQuery(query3, CommandType.Text, parameterList3);

            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    dropContainer.Items.Insert(i, new ListItem(Convert.ToString(dt3.Rows[i]["containerId"])));
                }
            }
        }
    }
}