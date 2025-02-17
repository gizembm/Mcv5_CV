using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Repositories;
using McvCv.Models.Entity;

namespace McvCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<TblCertifications> repo = new GenericRepository<TblCertifications>();
        public ActionResult Index()
        {
            var sertifika = repo.list();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult sertifikaGetir(int id)
        {
            TblCertifications t = repo.Find(x =>x.ID == id);
            ViewBag.d = id;
            return View(t);
        }

        [HttpPost]
        public ActionResult sertifikaGetir(TblCertifications t)
        {
            TblCertifications p = repo.Find(x => x.ID == t.ID);
            p.description = t.description;
            p.date = t.date;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult yeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniSertifika(TblCertifications p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult sertifkaSil(int id)
        {
            TblCertifications sil = repo.Find(x =>x.ID ==id);
            repo.TRemove(sil);
            return RedirectToAction("Index");
        }

    }
}