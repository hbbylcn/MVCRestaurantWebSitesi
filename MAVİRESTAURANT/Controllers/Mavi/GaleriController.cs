using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Galeri()
        {
            var model = db.Galeri.ToList();
            return View(model);
        }
    }
}