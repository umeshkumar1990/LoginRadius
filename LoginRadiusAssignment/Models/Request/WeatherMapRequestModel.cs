using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRadiusAssignment.Models.Request
{
    public class WeatherMapRequestModel
    {
        public string token { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string countrycode { get; set; }

    }
}