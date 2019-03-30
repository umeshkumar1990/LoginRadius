using LoginRadiusAssignment.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessIntelligence.Provider;
using LoginRadiusAssignment.Models;
using System.Data.SqlClient;

namespace BusinessIntelligence.Services
{
    public class AccountService
    {
        private const string _userNameCacheKey = "UserNameCacheKey";
        public GetTokenResponseModel Login(string userName, string password)
        {         
            GetTokenResponseModel response = new GetTokenResponseModel();
            UserModel user = new UserModel();
            user = ValidateUser(userName, password);
            if (user !=null)
            {
                response.access_token = Auth.GetAuthKey("userid");
                response.token_type = "Bearer";
               // response.refresh_token = "3";
                response.userName = user.Username;
                response.issued = DateTime.Now;
                response.expires_in = TimeSpan.FromHours(24).TotalSeconds;
                response.expires = response.issued.AddHours(24);
            }            
            return response;
        }
        public UserModel ValidateUser(string userId, string password)
        {
            UserModel res = new UserModel();
            try
            {
                //DB query goes here. As for now I am taking the static values of Username/Password which I am going to match with the request.
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(password))
                {
                    res.Username = UserStorage.Users.Where(c => c.UserId == userId && c.Password == password).Select(c => c.Username).FirstOrDefault();
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
