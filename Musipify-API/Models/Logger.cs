using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace Musipify_API.Models
{
    public class Logger
    {
        private string ID { get; set; }
        private string REC_DATE { get; set; }
        private string USER_NAME = Environment.UserName;
        private string PC_IP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        private string SRV_IP = HttpContext.Current.Request.Url.ToString() + " [" + HttpContext.Current.Request.HttpMethod.ToString() + "]";
        private string LEVEL;
        private string DESCRIPTION { get; set; }

        public void log(string level, string errorDescription)
        {
            this.LEVEL = level;
            this.DESCRIPTION = errorDescription;

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["musicpify"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GBL_LOG_PROC";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@P_USER_NAME", USER_NAME);
                    cmd.Parameters.AddWithValue("@P_PC_IP", PC_IP);
                    cmd.Parameters.AddWithValue("@P_SRV_IP", SRV_IP);
                    cmd.Parameters.AddWithValue("@P_LEVEL", LEVEL);
                    cmd.Parameters.AddWithValue("@P_DESCRIPTION", DESCRIPTION);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception EX)
            {
                string message = EX.Message;
            }
        }
    }
}