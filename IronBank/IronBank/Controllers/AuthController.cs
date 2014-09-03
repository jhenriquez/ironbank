using IronBank.Models;
using IronBank.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.Mvc;

namespace IronBank.Controllers
{   
    public class AuthController : IronController {

        [HttpPost]
        public ActionResult Login(LoginInformation login)
        {
            try
            {
                Authentication.LogIn(login.Username, login.Password);

                if (string.IsNullOrEmpty(login.ReturnUrl))
                    return Redirect(Url.Action("Index", "Dashboard"));

                return Redirect(login.ReturnUrl);
            }
            catch (Exception x)
            {
                return View(login);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Authentication.LogOut();

            return Redirect("/");
        }
    }
}