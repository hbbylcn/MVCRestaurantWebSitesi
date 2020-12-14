using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;


namespace MAVİRESTAURANT.Controllers.Admin
{
    public class IletisimAdminController : Controller
    {
        // GET: IletisimAdmin
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Iletisim()
        {
            var model = db.IletisimBilgileri.ToList();
            return View(model);
           
        }
       
        [HttpGet]
        public ActionResult IletisimBilgisi_Guncelle(int Iletisimbilgi_Id)
        {
            var iletisim = db.IletisimBilgileri.Find(Iletisimbilgi_Id);
            return View("IletisimBilgisi_Guncelle", iletisim);
        }
        [HttpPost]
        public ActionResult IletisimBilgisi_Guncelle(IletisimBilgileri i1)
        {
            var iletisim = db.IletisimBilgileri.Find(i1.Iletisimbilgi_Id);
            iletisim.Eposta = i1.Eposta;
            iletisim.Adres = i1.Adres;
            iletisim.Tel = i1.Tel;
            iletisim.HaritaYolu = i1.HaritaYolu;
            db.SaveChanges();
            return RedirectToAction("Iletisim");
        }
        public ActionResult IletisimBilgisi_Sil(int Iletisimbilgi_Id)
        {
            var iletisim = db.Kategori.Find(Iletisimbilgi_Id);
            db.Kategori.Remove(iletisim);
            db.SaveChanges();
            return RedirectToAction("Iletisim");
        }
    }
}