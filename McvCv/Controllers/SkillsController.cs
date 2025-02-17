using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Models.Entity;
using McvCv.Repositories;

namespace McvCv.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        GenericRepository<TblSkills> repository = new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var yetenekler = repository.list();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult yeniYetenek()
        {
            return View();
        }
        [HttpPost]

        public ActionResult yeniYetenek(TblSkills p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult yetenekSil(int id)
        {
            var yetenekler = repository.Find(x => x.ID == id);
            repository.TRemove(yetenekler);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult yetenekDüzenle(int id)
        {
            TblSkills t = repository.Find(x => x.ID == id);

            return View(t);
        }

        [HttpPost]
        public ActionResult yetenekDüzenle(TblSkills p)
        {
            TblSkills t = repository.Find(x => x.ID == p.ID);
            t.skills = p.skills;
            t.ratio = p.ratio;
            repository.TUpdate(t);  
            return RedirectToAction("Index");
        }

    }
}