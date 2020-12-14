using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class HomeController : Controller
    {
        // GET: Home
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OdemeBilgisi()
        {
            var OdemeKosullari = db.OdemeKosullari.ToList();
            return View(OdemeKosullari);
            
           
        }
        public ActionResult TeslimatKosullari()
        {
            var TeslimatKosullari = db.TeslimatKosullari.ToList();
            return View(TeslimatKosullari);
        }
        public ActionResult PartialViewSample()
        {
            var iletisim = db.IletisimBilgileri.ToList();
            var calisma = db.CalismaPlani.ToList();
            return PartialView(Tuple.Create("PartialViewSample", iletisim, calisma));
        }
    }
}