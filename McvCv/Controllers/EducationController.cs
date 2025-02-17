using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Repositories;
using McvCv.Models.Entity;


namespace McvCv.Controllers
{
    
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        public ActionResult Index()
        {
            var egitim = repo.list();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult yeniEgitim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniEgitim(TblEducation egitim)
        {
            if (!ModelState.IsValid)
            {
                return View("yeniEgitim");
            }
            repo.TAdd(egitim);
            return RedirectToAction("Index");
        }

        public ActionResult egitimSil(int id)
        {
            TblEducation t = repo.Find(x =>x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult egitimGuncelle(int id)
        {
            TblEducation t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult egitimGuncelle(TblEducation e)
        {
            if (!ModelState.IsValid)
            {
                return View("yeniEgitim");
            }
            TblEducation t = repo.Find(x => x.ID == e.ID);
            t.title = e.title;
            t.subtitle1 = e.subtitle1;
            t.subtitle2 = e.subtitle2;
            t.GNO = e.GNO;
            t.date = e.date;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}