using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class OdemeController : Controller
    {
        // GET: Odeme
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Odeme()
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                return View((Sepet)HttpContext.Session["AktifSepet"]);
            }
            else
            {
                return View();
            }            
        }

        public PartialViewResult GetSepet()
        {
            Sepet sepet = new Sepet();
            if (HttpContext.Session["AktifSepet"] != null)
                sepet = (Sepet)HttpContext.Session["AktifSepet"];
            return PartialView("_Odeme", sepet);
        }

        public PartialViewResult UpdateSepet(int id)
        {
            Sepet s = new Sepet();
            if (HttpContext.Session["AktifSepet"] != null)
            {
                 s = (Sepet)HttpContext.Session["AktifSepet"];

                if (s.SepetUrunler.FirstOrDefault(m => m.yemek.UrunId == id).Adet > 1)
                {
                    s.SepetUrunler.FirstOrDefault(m => m.yemek.UrunId == id).Adet--;
                }
                else
                {
                    SepetItem si = s.SepetUrunler.FirstOrDefault(m => m.yemek.UrunId == id);
                    s.SepetUrunler.Remove(si);
                }
            }

            return PartialView("_Odeme", s);
        }

        public void SepetUrunAdetDusur(int id)
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                Sepet s = (Sepet)HttpContext.Session["AktifSepet"];

                if (s.SepetUrunler.FirstOrDefault(m => m.yemek.UrunId == id).Adet > 1)
                {
                    s.SepetUrunler.FirstOrDefault(m => m.yemek.UrunId == id).Adet--;
                }
                else
                {
                    SepetItem si = s.SepetUrunler.FirstOrDefault(m => m.yemek.UrunId == id);
                    s.SepetUrunler.Remove(si);
                }
            }
        }
        [HttpGet]
        public ActionResult kaydet()
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                return View((Sepet)HttpContext.Session["AktifSepet"]);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult kaydet(siparis s)
        {
            var siparis = db.siparis.Add(s);
            db.SaveChanges();
            ViewBag.Message = "Sipariş İşleminiz Başarıyla Yapılmıştır...!";
            return View();
        }


    }
}