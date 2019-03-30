using BusinessIntelligence.Services;
using LoginRadiusAssignment.CustomAttribute;
using LoginRadiusAssignment.Models;
using LoginRadiusAssignment.Models.Response;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.UI;

namespace LoginRadiusAssignment.API
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        // POST api/Account/Login
        [Route("Login")]
        [HttpPost]
        public CommandResponseModel Login(GetUserRequestModel request)
        {
            var response = new CommandResponseModel();
            if (string.IsNullOrEmpty(request.Username) && string.IsNullOrEmpty(request.Password) )
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            AccountService accountService = new AccountService();
            response.Data = accountService.Login(request.Username,request.Password);
            return response;      
         }
    }
}
