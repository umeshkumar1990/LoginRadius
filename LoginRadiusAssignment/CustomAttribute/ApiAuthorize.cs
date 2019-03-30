using LoginRadiusAssignment.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BusinessIntelligence.Provider;

namespace LoginRadiusAssignment.CustomAttribute
{
    public class ApiAuthorize : ActionFilterAttribute
    {
        private static string _EncryptKey = "GmgHxN7vAbgwF9lBtiBgdWQLPCdIs";
        private static string _Seed = "GQJhfY9m8WU61n";
        private readonly string[] _param;
        public ApiAuthorize(params string[] param)
        {
            _param = param;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var authorized = HttpContext.Current.Request.IsAuthenticated;
            bool usedCommandKey = false;
            Encryptor E = new Encryptor(_EncryptKey, _Seed);
            var obj = ((LoginRadiusAssignment.Models.Request.WeatherMapRequestModel)(actionContext.ActionArguments.FirstOrDefault(c => c.Key == "req").Value)).token;

            string bString = E.DecryptAES(obj.Replace("-e", "=").Replace("-s", "/").Replace("-p", "+"));

            byte[] bytes = System.Convert.FromBase64String(bString);
            AuthKeyInfo aki = (AuthKeyInfo)Auth.DeSerializeObject(bytes);

            if (aki.Expire >= DateTime.Now)
            {
                authorized = true;
                usedCommandKey = true;                
            }

            //if (!authorized)
            //{
            //    throw new HttpResponseException(HttpStatusCode.Forbidden);
            //}
            base.OnActionExecuting(actionContext);
        }
    }
}