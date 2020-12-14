using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;
using System.IO;

namespace MAVİRESTAURANT.Controllers
{
    public class AdminAnasayfaController : Controller
    {
        // GET: AdminAnasayfa
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult Kisa_Hakkimizda()
        {
            var model = db.Hakkimizda.ToList();
            return View(model);
        }
        //[HttpGet]
        //public ActionResult Kisa_Hakkimizda_Ekle()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Kisa_Hakkimizda_Ekle(Hakkimizda h1, Resim rsm, HttpPostedFileBase dosya)
        //{
        // if (dosya.ContentLength > 0)
        //    {
        //        string resimAdi = Path.GetFileName(dosya.FileName);
        //string resimYolu = Path.Combine(Server.MapPath("~/Content/Mavi/img/menu"), Path.GetFileName(resimAdi));
        //dosya.SaveAs(resimYolu);
        //        rsm.ResimAd = resimAdi;
        //        rsm.ResimYol = resimYolu;
        //        db.Resim.Add(rsm);
        //        db.SaveChanges();
        //    }
        //    db.Hakkimizda.Add(h1);
        //h1.HakkimizdaResim = rsm;
        //    db.SaveChanges();
        //    return View();
        //}

        [HttpGet]
        public ActionResult Kisa_Hakkimizda_Guncelle(int Hakkimizda_Id)
        {
            var hak = db.Hakkimizda.Find(Hakkimizda_Id);
            List<SelectListItem> degerler2 = (from j in db.Resim.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = j.ResimAd,
                                                  Value = j.Resim_Id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            return View("Kisa_Hakkimizda_Guncelle", hak);

        }
        [HttpPost]
        public ActionResult Kisa_Hakkimizda_Guncelle(Hakkimizda h1,Resim rsm)
        {
            var hakkimizda = db.Hakkimizda.Find(h1.Hakkimizda_Id);
            var resim = db.Resim.Find(rsm.Resim_Id);
            var resim2 = db.Resim.Where(m => m.Resim_Id == h1.Resim.Resim_Id).FirstOrDefault();
            hakkimizda.HakkimizdaResim = resim2.Resim_Id;
            hakkimizda.Baslik = h1.Baslik;
            hakkimizda.Paragraf1 = h1.Paragraf1;
            hakkimizda.Paragraf2 = h1.Paragraf2;
            hakkimizda.Paragraf3 = h1.Paragraf3;
            hakkimizda.Durum = h1.Durum;
            db.SaveChanges();
            return RedirectToAction("Kisa_Hakkimizda");
        }
        public ActionResult Kisa_Hakkimizda_Sil(int Hakkimizda_Id)
        {
            var silincekVeri = db.Hakkimizda.Find(Hakkimizda_Id);
            if (silincekVeri == null)
            {
                return HttpNotFound();
            }
            db.Hakkimizda.Remove(silincekVeri);
            db.SaveChanges();
            return RedirectToAction("Kisa_Hakkimizda");
        }
        public ActionResult CokSatanlar()
        {
            var model = db.CokSatanlar.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult CokSatanlar_Ekle()
        {
            List<SelectListItem> degerler = (from i in db.Urunler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.UrunAd,
                                                 Value = i.UrunId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult CokSatanlar_Ekle(CokSatanlar cok)
        {
            var urun = db.Urunler.Where(m => m.UrunId == cok.Urunler.UrunId).FirstOrDefault();
            cok.Urunler = urun;
            db.CokSatanlar.Add(cok);
            db.SaveChanges();
            return RedirectToAction("CokSatanlar");
        }
        [HttpGet]
        public ActionResult CokSatanlar_Guncelle(int Id)
        {
            var cok = db.CokSatanlar.Find(Id);
            List<SelectListItem> degerler = (from i in db.Urunler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.UrunAd,
                                                 Value = i.UrunId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("CokSatanlar_Guncelle", cok);
        }
        [HttpPost]
        public ActionResult CokSatanlar_Guncelle(CokSatanlar cs)
        {
            var cok = db.CokSatanlar.Find(cs.Id);
            var urun = db.Urunler.Where(x => x.UrunId == cs.Urunler.UrunId).FirstOrDefault();
            cok.UrunId = urun.UrunId;
            db.SaveChanges();
            return RedirectToAction("CokSatanlar");
        }
        public ActionResult CokSatanlar_Sil(int Id)
        {
            var silincekVeri = db.CokSatanlar.Find(Id);
            if (silincekVeri == null)
            {
                return HttpNotFound();
            }
            db.CokSatanlar.Remove(silincekVeri);
            db.SaveChanges();
            return RedirectToAction("CokSatanlar");
        }
        public ActionResult CalismaSaatleri()
        {
            var model = db.CalismaPlani.ToList();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult CalismaSaatleri_Guncelle(int Calısma_Id)
        {
            var saat = db.CalismaPlani.Find(Calısma_Id);
            return View("CalismaSaatleri_Guncelle",saat);
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
        public ActionResult Yorumlar()
        {
            var model = db.Yorum.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yorumlar_Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yorumlar_Ekle(Yorum y1)
        {
            db.Yorum.Add(y1);
            db.SaveChanges();
            return RedirectToAction("Yorumlar");
        }
        [HttpGet]
        public ActionResult Yorumlar_Guncelle(int Yorum_Id)
        {
            var yorum = db.Yorum.Find(Yorum_Id);
            return View("Yorumlar_Guncelle", yorum);
        }
        [HttpPost]
        public ActionResult Yorumlar_Guncelle(Yorum y1)
        {
            var yorum = db.Yorum.Find(y1.Yorum_Id);
            yorum.Yorum1 = y1.Yorum1;
            yorum.AdSoyad = y1.AdSoyad;
            db.SaveChanges();
            return RedirectToAction("Yorumlar");
        }
        public ActionResult Yorumlar_Sil(int Yorum_Id)
        {
            var silincekVeri = db.Yorum.Find(Yorum_Id);
            if (silincekVeri == null)
            {
                return HttpNotFound();
            }
            db.Yorum.Remove(silincekVeri);
            db.SaveChanges();
            return RedirectToAction("Yorumlar");
        }

    }
}