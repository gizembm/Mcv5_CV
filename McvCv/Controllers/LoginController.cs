using McvCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace McvCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            dinamikCvDBEntities db = new dinamikCvDBEntities();
            var bilgi = db.TblAdmin.FirstOrDefault(x =>x.username == p.username && x.password == p.password);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.username, false);
                Session["username"] = bilgi.username.ToString();
                return RedirectToAction("Index","Experience");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}