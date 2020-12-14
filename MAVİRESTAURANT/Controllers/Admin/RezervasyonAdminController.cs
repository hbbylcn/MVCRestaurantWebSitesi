using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Admin
{
    public class RezervasyonAdminController : Controller
    {
        // GET: RezervasyonAnasayfa
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult CalismaSaatleri()
        {
            var model = db.CalismaPlani.ToList();
            return View(model);
        }
       
        [HttpGet]
        public ActionResult CalismaSaatleri_Guncelle(int Calısma_Id)
        {
            var saat = db.CalismaPlani.Find(Calısma_Id);
            return View("CalismaSaatleri_Guncelle", saat);
        }
        [HttpPost]
        public ActionResult CalismaSaatleri_Guncelle(CalismaPlani cp)
        {
            var saat = db.CalismaPlani.Find(cp.Calısma_Id);
            saat.Gün = cp.Gün;
            saat.Saat = cp.Saat;
            db.SaveChanges();
            return RedirectToAction("CalismaSaatleri");
        }
        public ActionResult CalismaSaatleri_Sil(int Calısma_Id)
        {
            var silincekVeri = db.CalismaPlani.Find(Calısma_Id);
            if (silincekVeri == null)
            {
                return HttpNotFound();
            }
            db.CalismaPlani.Remove(silincekVeri);
            db.SaveChanges();
            return RedirectToAction("CalismaSaatleri");
        }
    }
}