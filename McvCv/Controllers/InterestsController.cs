using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Repositories;
using McvCv.Models.Entity;

namespace McvCv.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        GenericRepository<TblInterests> repo = new GenericRepository<TblInterests>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.list();
            return View(hobi);
        }

        [HttpPost]
        public ActionResult Index(TblInterests p)
        {
            var deger = repo.Find(x => x.ID == 1);
            deger.description1 = p.description1;
            deger.description2 = p.description2;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }

    }
}