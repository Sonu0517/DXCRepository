using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCUI.Models;
using DataAccess;
using System.Web.Security;

namespace MVCUI.Controllers
{
    public class MTController : Controller
    {
        // GET: MT
        public ActionResult Register()
        {
            return View();

        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost,ValidateInput(true),ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationViewModel objModel)
        {
            if (ModelState.IsValid)
            {
                Person objUser = new Person();
                objUser.userid = objModel.UserId;
                objUser.fullname = objModel.Fullname;
                objUser.email = objModel.Email;
                objUser.password = objModel.Password;
                objUser.joined = objModel.Joined;
                var Repository = new UserRepository();
                Repository.AddUser(objUser);

                ViewBag.Message = "Registartion successful";

            }
            return View(objModel);
        }

        [HttpPost, ValidateInput(true), ValidateAntiForgeryToken]
        public ActionResult login(loginViewModel objModel)
        {
            if (ModelState.IsValid)
            {
                var Repository = new UserRepository();
                var Isvalid = Repository.VerifyUser(objModel.Username, objModel.Password);
                if (Isvalid == false)
                {
                    ViewBag.Message = "Invalid username/password";
                    return View(objModel);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(objModel.Username,objModel.RememberMe);
                    return RedirectToAction("Index", "Blogs");
                }
            }
            return View(objModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "MT");
        }
    }
}
