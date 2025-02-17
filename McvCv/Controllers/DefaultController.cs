using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Models.Entity;

namespace McvCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        dinamikCvDBEntities db = new dinamikCvDBEntities();
        public ActionResult Index()
        {
            var degerler=db.tblAboutMe.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyim=db.TblExperience.ToList();
            return PartialView(deneyim);
        }

        public PartialViewResult Egitim()
        {
            var egitimlerim = db.TblEducation.ToList();
            return PartialView(egitimlerim);
        }

        public PartialViewResult Hobi()
        {
            var hobilerim = db.TblInterests.ToList();
            return PartialView(hobilerim);
        }

        public PartialViewResult Yeteneklerim() 
        {
            var yeteneklerim = db.TblSkills.ToList();
            return PartialView(yeteneklerim);
        }

        public PartialViewResult Sertifikalarim()
        {
            var sertifikalarim = db.TblCertifications.ToList();
            return PartialView(sertifikalarim);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(TblContact t)
        {
            t.date = DateTime.Now;
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TblSocialMedia.ToList();
            return PartialView(sosyalMedya);
        }

    }
}