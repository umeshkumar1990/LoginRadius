using System.Web.Http;
using LoginRadiusAssignment.Models.Request;
using LoginRadiusAssignment.Models.Response;
using BusinessIntelligence.Services;
using System;
using LoginRadiusAssignment.CustomAttribute;

namespace LoginRadiusAssignment.API
{
    [ApiAuthorize()]
    [RoutePrefix("api/WeatherBroadcast")]
    public class WeatherBroadcastController : ApiController
    {
        private static string userid = "user1";
        WeatherBroadcast weather = new WeatherBroadcast();

        // POST api/Account/WeatherBroadcast
        [Route("GetWeatherbyCityName")]
        [HttpPost]
        public CommandResponseModel GetWeatherbyCityName([FromBody] WeatherMapRequestModel req)
        {
            var res = new CommandResponseModel();
            try {
               
                if (!string.IsNullOrEmpty(req.city))
                {
                    res.Data = weather.GetweatherbyCityName(req.city);
                }
                else
                {
                    res.Message = "City Name is empty.";
                }
            }
            catch(Exception ex) {
                res.Message = ex.ToString();
            }         
                   
            return res;
        }
        [Route("GetWeatherbyZip")]
        [HttpPost]
        public CommandResponseModel GetWeatherbyZip([FromBody] WeatherMapRequestModel req)
        {
            var res = new CommandResponseModel();
            try
            {
                if (!string.IsNullOrEmpty(req.zipcode) && !string.IsNullOrEmpty(req.countrycode))
                {

                    res.Data = weather.Getweatherbyzip(req.zipcode, req.countrycode);
                }
                else
                {
                    res.Message = "Empty ZipCode or CountryCode";
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.ToString();
            }
            return res;
        }
    }
}
