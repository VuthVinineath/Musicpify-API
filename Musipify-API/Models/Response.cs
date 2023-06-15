using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musipify_API.Models
{
    public class Response
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}