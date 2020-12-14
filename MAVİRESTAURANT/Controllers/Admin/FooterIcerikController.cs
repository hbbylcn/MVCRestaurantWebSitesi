using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;
namespace MAVİRESTAURANT.Controllers.Admin
{
    public class FooterIcerikController : Controller
    {
        // GET: FooterIcerik
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult OdemeKosullari()
        {
            var model = db.OdemeKosullari.ToList();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult OdemeKosullari_Guncelle(int OdemeKosul_Id)
        {
            var odeme = db.OdemeKosullari.Find(OdemeKosul_Id);
            List<SelectListItem> degerler2 = (from j in db.Resim.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = j.ResimAd,
                                                  Value = j.Resim_Id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            return View("OdemeKosullari_Guncelle", odeme);
        }
        [HttpPost]
        public ActionResult OdemeKosullari_Guncelle(OdemeKosullari o1,Resim rsm)
        {
            var odeme = db.OdemeKosullari.Find(o1.OdemeKosul_Id);
            odeme.KosulBaslik1 = o1.KosulBaslik1;
            odeme.KosulBaslik2 = o1.KosulBaslik2;
            odeme.KosulParagraf1 = o1.KosulParagraf1;
            odeme.KosulParagraf2 = o1.KosulParagraf2;
            odeme.KosulParagraf3 = o1.KosulParagraf3;
            odeme.KosulBaslik3 = o1.KosulBaslik3;
            odeme.KosulParagraf4 = o1.KosulParagraf4;
            odeme.KosulParagraf5 = o1.KosulParagraf5;
            var resim = db.Resim.Find(rsm.Resim_Id);
            var resim2 = db.Resim.Where(m => m.Resim_Id == o1.Resim.Resim_Id).FirstOrDefault();
            odeme.KosulResim = resim2.Resim_Id;
            odeme.KosulDurum = o1.KosulDurum;
            db.SaveChanges();
            if (odeme == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("OdemeKosullari");
        }
       
        public ActionResult TeslimatKosullari()
        {
            var model = db.TeslimatKosullari.ToList();
            return View(model);
        }
      
        [HttpGet]
        public ActionResult TeslimatKosullari_Guncelle(int Teslimat_Id)
        {
            var teslimat = db.TeslimatKosullari.Find(Teslimat_Id);
            
            List<SelectListItem> degerler2 = (from j in db.Resim.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = j.ResimAd,
                                                  Value = j.Resim_Id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;
            
            return View("TeslimatKosullari_Guncelle", teslimat);
        }
        [HttpPost]
        public ActionResult TeslimatKosullari_Guncelle(TeslimatKosullari t1, Resim rsm)
        {
            var teslimat = db.TeslimatKosullari.Find(t1.Teslimat_Id);
            teslimat.TeslimatBaslik = t1.TeslimatBaslik;
            teslimat.TeslimatMetin1 = t1.TeslimatMetin1;
            teslimat.TeslimatMetin2 = t1.TeslimatMetin2;
            teslimat.TeslimatMetin3 = t1.TeslimatMetin3;
            teslimat.TeslimatMetin4 = t1.TeslimatMetin4;
            var resim = db.Resim.Find(rsm.Resim_Id);
            var resim2 = db.Resim.Where(m => m.Resim_Id == t1.Resim.Resim_Id).FirstOrDefault();
            teslimat.TeslimatResim = resim2.Resim_Id;
            teslimat.MetinDurum = t1.MetinDurum;
            db.SaveChanges();
            if (teslimat == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("TeslimatKosullari");
        }
      
    }
}