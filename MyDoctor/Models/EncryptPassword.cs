using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Security;

namespace MyDoctor.Models
{
    public class EncryptPassword
    {
        public static string encryptPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] encode = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for(int i=0;i<encode.Length;i++)
            {

                strBuilder.Append(encode[i].ToString("x2"));
            }

            
            return strBuilder.ToString();


            //string encryptdpassword = "";
            //byte[] encode = new byte[password.Length];
            //encode = Encoding.UTF8.GetBytes(password);

            //encryptdpassword = Convert.ToBase64String(encode);
            //return encryptdpassword;
            
        }
    }
}