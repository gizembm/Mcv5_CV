using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience 
        DeneyimRepository repository = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repository.list();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult deneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult deneyimEkle(TblExperience p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult deneyimSil(int id)
        {
            TblExperience t = repository.Find(x =>x.ID == id);
            repository.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult deneyimGuncelle(int id) 
        {
            TblExperience t = repository.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult deneyimGuncelle(TblExperience p)
        {
            TblExperience t = repository.Find(x => x.ID == p.ID);
            t.title = p.title;
            t.subtitle= p.subtitle;
            t.description= p.description;
            t.date = p.date;
            repository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}