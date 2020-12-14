using MAVİRESTAURANT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Rezervasyon()
        {
            var calisma = db.CalismaPlani.ToList();
            return View(calisma);

        }
        [HttpPost]
        public ActionResult Rezervasyon(Rezervasyon r)
        {
            var rezerve = db.Rezervasyon.Add(r);
            var calisma = db.CalismaPlani.ToList();
            db.SaveChanges();
            ViewBag.Message = "Rezervasyon İşleminiz Başarıyla Yapılmıştır...!";
            return View(calisma);
        }
    }
}