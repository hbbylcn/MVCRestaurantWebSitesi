using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;
using System.IO;

namespace MAVİRESTAURANT.Controllers.Admin
{
    public class GaleriAdminController : Controller
    {
        // GET: GaleriAdmin
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Galeri()
        {
            var model = db.Galeri.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult GaleriResim_Ekle()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult GaleriResim_Ekle(Galeri g, Resim rsm, HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string resimAdi = Path.GetFileName(dosya.FileName);
                string resimYolu = Path.Combine(Server.MapPath("~/Content/Mavi/img/gallery"), Path.GetFileName(resimAdi));
                dosya.SaveAs(resimYolu);
                rsm.ResimAd = resimAdi;
                rsm.ResimYol = resimYolu;
                db.Resim.Add(rsm);
                db.SaveChanges();
            }
            g.Resim = rsm;
            db.Galeri.Add(g);
            db.SaveChanges();
            return RedirectToAction("Galeri");
            
            
        }
        [HttpGet]
        public ActionResult GaleriResim_Guncelle(int GaleriId)
        {
            var galeri = db.Galeri.Find(GaleriId);
            List<SelectListItem> degerler2 = (from j in db.Resim.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = j.ResimAd,
                                                  Value = j.Resim_Id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            return View("GaleriResim_Guncelle");
        }
       [HttpPost]
       public ActionResult GaleriResim_Guncelle(Galeri g,Resim rsm)
        {
            var galeri = db.Galeri.Find(g.GaleriId);
            var resim = db.Resim.Find(rsm.Resim_Id);
            var resim2 = db.Resim.Where(m => m.Resim_Id == g.Resim.Resim_Id).FirstOrDefault();
            galeri.ResimId = resim2.Resim_Id;
            db.SaveChanges();
            return RedirectToAction("Galeri");
        }
        public ActionResult GaleriResim_Sil(int GaleriId)
        {
            var silincekVeri = db.Galeri.Find(GaleriId);
            if (silincekVeri == null)
            {
                return HttpNotFound();
            }
            db.Galeri.Remove(silincekVeri);
            db.SaveChanges();
            return RedirectToAction("Galeri");
        }
    }
}