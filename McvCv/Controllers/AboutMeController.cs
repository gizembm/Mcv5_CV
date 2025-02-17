using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    public class AboutMeController : Controller
    {
        // GET: Interests
        GenericRepository<tblAboutMe> repo = new GenericRepository<tblAboutMe>();

        [HttpGet]
        public ActionResult Index()
        {
            var bilgi = repo.list();
            return View(bilgi);
        }

        [HttpPost]
        public ActionResult Index(tblAboutMe p)
        {
            var deger = repo.Find(x => x.ID == 1);
            deger.name = p.name;
            deger.surname = p.surname;
            deger.address = p.address;
            deger.phone = p.phone;
            deger.picture = p.picture;
            deger.description = p.description;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }

    }
}
