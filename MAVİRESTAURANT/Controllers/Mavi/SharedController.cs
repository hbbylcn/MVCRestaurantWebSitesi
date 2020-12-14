using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;
using System.Data.Entity;


namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class SharedController : Controller
    {
        // GET: Shared
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult footer()
        {
            var iletisim = db.IletisimBilgileri.ToList();
            var calisma = db.CalismaPlani.ToList();
            return PartialView(Tuple.Create(iletisim, calisma));

        }
    }
}