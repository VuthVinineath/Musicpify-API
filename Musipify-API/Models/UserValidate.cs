using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Musipify_API.Models
{
    public class UserValidate
    {
        //public static byte[] GetHash(string inputString)
        //{
        //    HashAlgorithm algorithm = SHA1.Create();
        //    return algorithm.ComputeHash(Encoding.Unicode.GetBytes(inputString));
        //}

        //public static string GetHashString(string inputString)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (byte b in GetHash(inputString))
        //        sb.Append(b.ToString("X2"));

        //    return sb.ToString();
        //}

        private static string conStr = ConfigurationManager.ConnectionStrings["musicpify"].ConnectionString;
        private static User user = new User();
        //This method is used to check the user credentials
        public static bool Login(string username, string password)
        {
            SQLExecutor executeQuery = new SQLExecutor();
            string[] P1 = { "@P_EMAIL", "@P_PASSWORD" };
            string[] V1 = { username, password };
            DataTable dataTable;
            executeQuery.ExecuteQuery("USER_VALIDATION", P1, V1, out dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}