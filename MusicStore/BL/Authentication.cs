using System.Linq;
using MusicStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using System;

namespace MusicStore.BL
{
    public class Authentication
    {
        private static Repository<User> user = new Repository<User>();

        public static Dictionary<bool, string> VerifyLogin(string username, string password)
        {
            var dic = new Dictionary<bool, string>();
            try
            {
                var data = user.GetAll().Where(u => u.UserName.Equals(username)).FirstOrDefault();
                if (data == null)
                {
                    dic.Add(false, "No username found.");
                }
                else if (data.Password != password)
                {
                    dic.Add(false, "Wrong password");
                }
                else if (data.IsEnable == false)
                {
                    dic.Add(false, "User is disable");
                }
                else if (data.Password == password)
                {
                    dic.Add(true, "Valid login");

                    //session
                    HttpContext.Current.Session["userid"] = data.UserID;
                    HttpContext.Current.Session["username"] = username;

                    //form authentication
                    var authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), false, "phearom123@$&");
                    var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Current.Response.Cookies.Add(authCookie);
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUserName.Text, false));
                }
                else
                {
                    dic.Add(false, "Unknown");
                }
            }
            catch (System.Exception ex)
            {
                dic.Add(false, ex.Message);
            }
            return dic;
        }
    }
}