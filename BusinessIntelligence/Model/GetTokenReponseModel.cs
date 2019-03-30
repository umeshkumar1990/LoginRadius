using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRadiusAssignment.Models.Response
{
    public class GetTokenResponseModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public double expires_in {get;set;}
        //public string refresh_token {get;set;}
        public string userName { get; set; }
        public DateTime issued { get; set; }
        public DateTime expires {get;set;}
        public string message { get; set; }

    }
}