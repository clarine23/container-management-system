using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMS
{
    class DBHelper
    {
        private static SqlConnection currrentConn = null;

        // Switch case for different database connection
        public DBHelper()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            //Console.WriteLine("You are connecting to database: " + connectionString);
            currrentConn = new SqlConnection(connectionString);
        }

        // ExecuteQuery method 
        public DataTable ExecuteQuery(string commandText, CommandType commandType, List<SqlParameter> parameterList)
        {
            SqlConnection conn = currrentConn; // For thread safe purpose
            DataTable dt = new DataTable();
            SqlCommand cmd = conn.CreateCommand();

            SqlParameter[] parameters = parameterList.ToArray(); // Convert list to array

            try
            {
                conn.Open();
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

            return dt;
        }

        // ExecuteNonQuery method
        public Boolean ExecuteNonQuery(string commandText, CommandType commandType, List<SqlParameter> parameterList)
        {
            SqlConnection conn = currrentConn; // For thread safe purpose
            Boolean result = false;
            DataTable dt = new DataTable();
            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction transaction = null;

            SqlParameter[] parameters = parameterList.ToArray(); // Convert list to array

            try
            {
                conn.Open();

                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                int rowAffected = cmd.ExecuteNonQuery();

                transaction.Commit();
                result = true;
                if (rowAffected <= 0)
                    result = false;
            }
            catch (Exception err)
            {
                try
                {
                    transaction.Rollback(); // Attempt to roll back the transaction.
                    throw err;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

            return result;
        }
    }
}
