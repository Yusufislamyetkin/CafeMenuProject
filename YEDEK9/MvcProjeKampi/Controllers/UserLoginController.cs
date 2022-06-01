using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
   [AllowAnonymous]
    public class UserLoginController : Controller
    {
        UserManager um = new UserManager(new EFUserDal());


        // GET: UserLogin

        public static string MD5Olustur(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }


        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {

          user.HASHPASSWORD  =   MD5Olustur(user.SALTPASSWORD);
            var UserInfo = um.GetBySession(user);


            if (UserInfo != null)
            {


                FormsAuthentication.SetAuthCookie(UserInfo.USERNAME, false);

                Session["USERNAME"] = UserInfo.USERNAME;
              
                
              
                return RedirectToAction("MenuCategoryAdd", "UserPanel");


            }
            else
            {
                TempData["AlertMessageStudent"] = "Giriş Yapılamadı ";
                return RedirectToAction("Index");
            }

           
        }

        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(User user)
        {
           user.HASHPASSWORD = MD5Olustur(user.SALTPASSWORD);
            um.AddValue(user);

            return RedirectToAction("Index");
        }


        public ActionResult UserLogOut()
        {


            FormsAuthentication.SignOut();
            Session.Abandon(); 

            return RedirectToAction("Index");
        }


    }
}