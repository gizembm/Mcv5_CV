using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Repositories;
using McvCv.Models.Entity;

namespace McvCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia>();
        public ActionResult Index()
        {
            var socialMedia = repo.list();
            return View(socialMedia);
        }
        [HttpGet]
        public ActionResult ekle()
        {
          return View();
        }

        [HttpPost]
        public ActionResult ekle(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult duzenle(int id)
        {
            TblSocialMedia t = repo.Find(x => x.ID == id);
            return View(t);
          
        }

        [HttpPost]
        public ActionResult duzenle(TblSocialMedia p)
        {
            TblSocialMedia t = repo.Find(x => x.ID == p.ID);
            t.name = p.name;
            t.link = p.link;
            t.icon = p.icon;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }

        public ActionResult sil(TblSocialMedia p)
        {
            TblSocialMedia t = repo.Find(x => x.ID == p.ID);
            repo.TRemove(t);
            return RedirectToAction("Index");

        }






    }
}