using LoginRadiusAssignment.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.Provider
{
    public class Auth
    {       
        private static string _EncryptKey = "GmgHxN7vAbgwF9lBtiBgdWQLPCdIs";
        private static string _Seed = "GQJhfY9m8WU61n";
        public static string GetAuthKey(string ID)
        {
            return GetAuthKey(ID, new TimeSpan(24, 0, 0));
        }
        private static string GetAuthKey(string ID, TimeSpan lifetime)
        {
            return GetAuthKey(ID, lifetime, _EncryptKey, _Seed);
        }

        private static string GetAuthKey(string ID, TimeSpan lifespan, string encryptKey, string salt)
        {
            AuthKeyInfo aki = new AuthKeyInfo();
            aki.ID = ID;
            aki.Expire = DateTime.Now.Add(lifespan);
            byte[] akiB = SerializeObject(aki);
            Encryptor E = new Encryptor(encryptKey, salt);
            return E.EncryptAES(Convert.ToBase64String(akiB)).Replace("=", "-e").Replace("/", "-s").Replace("+", "-p");
        }
        public static byte[] SerializeObject(object item)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream mStream = new MemoryStream();
            formatter.Serialize(mStream, item);
            return mStream.ToArray();
        }
        public static object DeSerializeObject(byte[] values)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream mStream = new MemoryStream(values);
            return formatter.Deserialize(mStream);
        }
        //public static bool ValidateToken(string ID, string token)
        //{
        //    return VerifyAuthKey(ID, token, _EncryptKey, _Seed);
        //}
        //private static bool VerifyAuthKey(string ID, string key, string encryptKey, string seed)
        //{
        //    Encryptor E = new Encryptor(encryptKey, seed);
        //    string bString = E.DecryptAES(key.Replace("-e", "=").Replace("-s", "/").Replace("-p", "+"));

        //    byte[] bytes = System.Convert.FromBase64String(bString);
        //    AuthKeyInfo aki = (AuthKeyInfo)DeSerializeObject(bytes);

        //    if (aki.Expire >= DateTime.Now)
        //    {
        //        return (aki.ID == ID);
        //    }

        //    return false;
        //}
    }
    [Serializable]
    public struct AuthKeyInfo
    {
        public string ID { get; set; }
        public DateTime Expire { get; set; }
    }
}
