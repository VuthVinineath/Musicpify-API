using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musipify_API.Models
{
    public class User
    {
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public string AUTHORIZER { get; set; }
        public string CREATED_DATE { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string PROFILE_ID { get; set; }
        public string MODIFIED_DATE { get; set; }
    }

    public class UserInformation : User
    {
        public string USERNAME { get; set; }
        public string ACCOUNT_TYPE { get; set; }
        public string PHOTO { get; set; }
        public string MODIFIED_DATE { get; set; }
    }
}