using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Models.Entity;
using McvCv.Repositories;

namespace McvCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var liste = repo.list();
            return View(liste);
        }

        public ActionResult sil(TblAdmin p)
        {
            TblAdmin t = repo.Find(x =>x.ID == p.ID);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult duzenle(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult duzenle(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.username = p.username;
            t.password = p.password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }




    }
}