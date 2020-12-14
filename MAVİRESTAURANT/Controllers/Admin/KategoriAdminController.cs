using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Admin
{
    public class KategoriAdminController : Controller
    {
        // GET: KategoriAnasayfa
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Kategoriler()
        {
            var model = db.Kategori.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k1)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            db.Kategori.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int Kategori_Id)
        {
            var ktgr = db.Kategori.Find(Kategori_Id);
            return View("KategoriGuncelle", ktgr);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori k1)
        {
            var ktgr = db.Kategori.Find(k1.Kategori_Id);
            ktgr.Kategori_adi = k1.Kategori_adi;
            db.SaveChanges();
            if (ktgr == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Kategoriler");
        }
        public ActionResult KategoriSil(int Kategori_Id)
        {
            var kategori = db.Kategori.Find(Kategori_Id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");

        }
    }
}