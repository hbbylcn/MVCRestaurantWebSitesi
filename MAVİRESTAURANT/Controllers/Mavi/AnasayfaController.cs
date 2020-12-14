using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class AnasayfaController : Controller
    {
        // GET: HOME
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Anasayfa()
        {
            
            var Hakkimizda = db.Hakkimizda.ToList();
            var CokSatanlar = db.CokSatanlar.ToList();
            var Yorum = db.Yorum.ToList();
            var CalismaPlani = db.CalismaPlani.ToList();
           
           
            return View(Tuple.Create(Hakkimizda,CokSatanlar,Yorum,CalismaPlani));
        }

        public void SepeteEkle(int id)
        {
            SepetItem si = new SepetItem();
            Urunler u = db.Urunler.FirstOrDefault(m => m.UrunId == id);
            si.yemek = u;
            si.Adet = 1;
            Sepet s = new Sepet();
            s.SepeteEkle(si);

        }
      

        public void VeriyiOdemeyeGotur(int id)
        {
            SepetItem si = new SepetItem();
            Urunler u = db.Urunler.FirstOrDefault(m => m.UrunId == id);
            si.yemek = u;
            si.Adet = 1;
            Sepet s = new Sepet();
            s.SepeteEkle(si);
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
        public PartialViewResult MiniSepetWidget()
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                return PartialView((Sepet)HttpContext.Session["AktifSepet"]);
            }
            else
            {
                return PartialView();
            }
        }

    }
        
}