using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;
using System.IO;

namespace MAVİRESTAURANT.Controllers.Admin
{
    public class HakkimizdaAdminController : Controller
    {
        // GET: HakkimizdaAnasayfa
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Hakkimizda()
        {
            var model = db.Hakkimizda.ToList();
            return View(model);
        }
       
        [HttpGet]
        public ActionResult Hakkimizda_Guncelle(int Hakkimizda_Id)
        {
            var hak = db.Hakkimizda.Find(Hakkimizda_Id);
            List<SelectListItem> degerler2 = (from j in db.Resim.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = j.ResimAd,
                                                  Value = j.Resim_Id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            return View("Hakkimizda_Guncelle", hak);

        }
        [HttpPost]
        public ActionResult Hakkimizda_Guncelle(Hakkimizda h1,Resim rsm)
        {
            var hakkimizda = db.Hakkimizda.Find(h1.Hakkimizda_Id);
            hakkimizda.Baslik = h1.Baslik;
            var resim = db.Resim.Find(rsm.Resim_Id);
            var resim2 = db.Resim.Where(m => m.Resim_Id == h1.Resim.Resim_Id).FirstOrDefault();
            hakkimizda.HakkimizdaResim = resim2.Resim_Id;
            hakkimizda.Paragraf1 = h1.Paragraf1;
            hakkimizda.Paragraf2 = h1.Paragraf2;
            hakkimizda.Paragraf3 = h1.Paragraf3;
            hakkimizda.Paragraf4 = h1.Paragraf4;
            hakkimizda.Paragraf5 = h1.Paragraf5;
            hakkimizda.Paragraf6 = h1.Paragraf6;
            hakkimizda.Durum = h1.Durum;
            db.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
        public ActionResult Hakkimizda_Sil(int Hakkimizda_Id)
        {
            var silincekVeri = db.Hakkimizda.Find(Hakkimizda_Id);
            if (silincekVeri == null)
            {
                return HttpNotFound();
            }
            db.Hakkimizda.Remove(silincekVeri);
            db.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
    }
}