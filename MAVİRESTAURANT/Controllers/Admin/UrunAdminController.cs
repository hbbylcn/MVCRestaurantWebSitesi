using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;
using System.IO;
using PagedList;
using PagedList.Mvc;

namespace MAVİRESTAURANT.Controllers.Admin
{
    public class UrunAdminController : Controller
    {
        // GET: UrunAdmin
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Urun(int? page)
        {
            var model = db.Urunler.OrderBy(m => m.Kategori).ToList().ToPagedList(page ?? 1, 6);
            return View(model);
        }
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategori_adi,
                                                 Value = i.Kategori_Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]

        public ActionResult UrunEkle(Urunler urn, Resim rsm, HttpPostedFileBase dosya)
        {

            if (dosya.ContentLength > 0)
            {
                string resimAdi = Path.GetFileName(dosya.FileName);
                string resimYolu = Path.Combine(Server.MapPath("~/Content/Mavi/img/menu"), Path.GetFileName(resimAdi));
                dosya.SaveAs(resimYolu);
                rsm.ResimAd = resimAdi;
                rsm.ResimYol = resimYolu;
                db.Resim.Add(rsm);
                db.SaveChanges();
            }

            var ktgr = db.Kategori.Where(m => m.Kategori_Id == urn.Kategori1.Kategori_Id).FirstOrDefault();
            urn.Kategori1 = ktgr;
            urn.Resim = rsm;
            db.Urunler.Add(urn);
            db.SaveChanges();
            return RedirectToAction("Urun");
        }
        [HttpGet]
        public ActionResult UrunGuncelle(int UrunId)
        {
            var urn = db.Urunler.Find(UrunId);
            List<SelectListItem> degerler = (from i in db.Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategori_adi,
                                                 Value = i.Kategori_Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            List<SelectListItem> degerler2 = (from j in db.Resim.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = j.ResimAd,
                                                  Value = j.Resim_Id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;

            return View("UrunGuncelle", urn);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urunler urn, Resim rsm, HttpPostedFileBase dosya)
        {

            var urun = db.Urunler.Find(urn.UrunId);
            
            //if (dosya.ContentLength > 0)
            //{
                var resim = db.Resim.Find(rsm.Resim_Id);
                var resim2 = db.Resim.Where(m => m.Resim_Id == urn.Resim.Resim_Id).FirstOrDefault();
                urun.UrunResim = resim2.Resim_Id;
                //string resimAdi = Path.GetFileName(dosya.FileName);
                //string resimYolu = Path.Combine(Server.MapPath("~/Content/Mavi/img/menu"), Path.GetFileName(resimAdi));
                //dosya.SaveAs(resimYolu);
                //rsm.ResimAd = resimAdi;
                //rsm.ResimYol = resimYolu;
                //resim.ResimAd = rsm.ResimAd;
                //resim.ResimYol = rsm.ResimYol;
                //db.SaveChanges();
                
            //}
            urun.UrunKod = urn.UrunKod;
            var ktgr = db.Kategori.Where(m => m.Kategori_Id == urn.Kategori1.Kategori_Id).FirstOrDefault();
            urun.Kategori = ktgr.Kategori_Id;
            urun.UrunAd = urn.UrunAd;
            urun.Stok = urn.Stok;


            //string resimAdi = Path.GetFileName(dosya.FileName);
            //string resimYolu = Path.Combine(Server.MapPath("~/Content/img"), Path.GetFileName(resimAdi));
            //dosya.SaveAs(resimYolu);
            //urun.resim = resimAdi;
            //urun.resimyolu = resimYolu;


            urun.Fiyat = urn.Fiyat;
            urun.Aciklama = urn.Aciklama;
            urun.Durum = urn.Durum;
            db.SaveChanges();
            return RedirectToAction("Urun");
        }
        public ActionResult UrunSil(int UrunId)
        {
            var silincekVeri = db.Urunler.Find(UrunId);
            if (silincekVeri == null)
            {
                return HttpNotFound();
            }
            db.Urunler.Remove(silincekVeri);
            db.SaveChanges();
            return RedirectToAction("Urun");
        }
        
    }
}