using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Repositories;
using McvCv.Models.Entity;


namespace McvCv.Controllers
{
    public class ContectController : Controller
    {
        // GET: Contect
        GenericRepository<TblContact> repo = new GenericRepository<TblContact>();
        public ActionResult Index()
        {
            var iletisim = repo.list();
            return View(iletisim);
        }

        public ActionResult mesajSil(int id)
        {
            TblContact sil = repo.Find(x=>x.ID == id);  
            repo.TRemove(sil);
            return RedirectToAction("Index");
        }

    }
}