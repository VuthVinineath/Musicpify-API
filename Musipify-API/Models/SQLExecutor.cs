using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Musipify_API.Models
{
    public class SQLExecutor
    {
        #region Declaration
        private string conStr;
        private string procedure;
        public string message { get; set; }
        Logger logger = new Logger();
        #endregion

        #region SQL POST
        public void ExecuteQuery(string procedure, string[] param, string[] value, out bool status)
        {
            this.conStr = ConfigurationManager.ConnectionStrings["musicpify-aws"].ConnectionString;
            this.procedure = procedure;
            status = false;

            using (MySqlConnection connection = new MySqlConnection(conStr))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                if (!DBNull.Equals(value, null))
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i], value[i]);
                    }
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    logger.log("trace", "Successful");
                    status = true;
                }
                catch (Exception ex)
                {
                    logger.log("error", ex.Message);
                    status = false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region SQL GET BY DATATABLE
        public void ExecuteQuery(string procedure, string[] param, string[] value, out DataTable dataTable)
        {
            this.conStr = ConfigurationManager.ConnectionStrings["musicpify-aws"].ConnectionString;
            this.procedure = procedure;
            dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(conStr))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                if (!DBNull.Equals(value, null))
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i], value[i]);
                    }
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                try
                {
                    adapter.Fill(dataTable);
                    logger.log("trace", "Successful");
                }
                catch (Exception ex)
                {
                    String message = ex.Message;
                    logger.log("error", ex.Message);
                }
                finally
                {
                    dataTable.Dispose();
                    connection.Close();
                }
            }
        }
        #endregion
    }
}