using System; 
using System.Globalization; 
using System.Linq; 
using System.Security.Claims; 
using System.Threading.Tasks; 
using System.Web; 
using System.Web.Mvc; 
using Microsoft.AspNet.Identity; 
using Microsoft.AspNet.Identity.Owin; 
using Microsoft.Owin.Security;
using TelerikAcademyASPNETWebApp.Account.Interfaces;
using TelerikAcademyASPNETWebApp.Account.Models;
using TelerikAcademyASPNETWebApp.Account.BusinessLayer;
using System.Web.Security;
using System.Net;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TelerikAcademyASPNETWebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IAccountManagement _accountManagement;

        public AccountController()
        {
            this._accountManagement = new AccountManagement();
        }

        // 
        // GET: /Account/Login 
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Response.Cookies["loggedUser"] != null 
                && Response.Cookies["loggedUser"]["User"] != null 
                && Response.Cookies["loggedUser"]["User"].Length > 0)
            {
                Response.Cookies["loggedUser"].Expires = DateTime.Now.AddDays(1d);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // 
        // POST: /Account/Login 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection model)
        {
            var loginModel = new LoginViewModel()
            {
                Username = model["Username"] != null ? model["Username"] : "",
                Password = model["Password"] != null ? model["Password"] : "",
                RememberMe = model["RememberMe"] != null ? model["RememberMe"].ToLower().IndexOf("true") > -1 : false
            };
            if (ModelState.IsValid)
            {
                loginModel.RememberMe = this._accountManagement.UserLogin(loginModel);
                if (loginModel.RememberMe)
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Username, loginModel.RememberMe);
                    
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(new[] { DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.ExternalBearer });
                    authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = loginModel.RememberMe }, claimsIdentity);

                    if (Response.Cookies["loggedUser"] != null)
                    {
                        Response.Cookies["loggedUser"]["User"] = loginModel.Username;
                        Response.Cookies["loggedUser"].Expires = DateTime.Now.AddDays(1d);
                    }
                    else
                    {
                        HttpCookie myCookie = new HttpCookie("loggedUser");
                        myCookie["User"] = loginModel.Username;
                        myCookie.Expires = DateTime.Now.AddDays(1d);
                        Response.Cookies.Add(myCookie);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }            
            return View(loginModel);
        }

        // 
        // GET: /Account/Register 
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // 
        // POST: /Account/Register 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection model) // RegisterViewModel model
        {
            if (Response.Cookies["loggedUser"] != null
                && Response.Cookies["loggedUser"]["User"] != null
                && Response.Cookies["loggedUser"]["User"].Length > 0)
            {
                Response.Cookies["loggedUser"].Expires = DateTime.Now.AddDays(1d);
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var result = this._accountManagement.UserRegister(new RegisterViewModel()
                {
                    Username = model["Username"] != null ? model["Username"] : "",
                    Password = model["Password"] != null ? model["Password"] : "",
                    ConfirmPassword = model["ConfirmPassword"] != null ? model["ConfirmPassword"] : "",
                    Email = model["Email"] != null ? model["Email"] : "",
                    UserRoles = model["UserRoles"] != null ? model["UserRoles"] : "-1",
                });
                if (!result)
                {
                    return RedirectToAction("Register", "Account");
                }
                FormsAuthentication.SetAuthCookie(model["Username"], true);
            }
            return RedirectToAction("Index", "Home");
        }

        // 
        // POST: /Account/LogOff 
        [HttpPost]
        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            if (Response.Cookies["loggedUser"] != null
                && Response.Cookies["loggedUser"]["User"] != null
                && Response.Cookies["loggedUser"]["User"].Length > 0)
            {
                Response.Cookies["loggedUser"].Expires = DateTime.Now.AddDays(-1d);
            }
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        // 
        // GET: /Account/ExternalLoginFailure 
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    if (_userManager != null)
            //    {
            //        _userManager.Dispose();
            //        _userManager = null;
            //    }

            //    if (_signInManager != null)
            //    {
            //        _signInManager.Dispose();
            //        _signInManager = null;
            //    }
            //}

            base.Dispose(disposing);
        }
    }
}