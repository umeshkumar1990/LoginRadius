using System.Collections.Generic;
namespace LoginRadiusAssignment.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

    }
    public static class UserStorage
    {
        public static List<UserModel> Users { get; set; } = new List<UserModel> {
            new UserModel {UserId="user1",Password = "user1psd",Username="Namrata Rajput" },
            new UserModel {UserId="user2",Password = "user2psd",Username="Login Radius" },
        };
        public static string Message { get; set; }
    }
}