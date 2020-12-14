using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;


namespace MAVİRESTAURANT.Controllers.Admin
{
    public class MusteriTalepleriController : Controller
    {
        // GET: MusteriTalepleri
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Musteri_Rezervasyon()
        {
            var rezerve = db.Rezervasyon.ToList();
            return View(rezerve);
        }
        public ActionResult Musteri_Iletisim()
        {
            var iletisim = db.Iletisim.ToList();
           
            return View(iletisim);
        }
       
    }
}