using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class HakkimizdaController : Controller
    {
        // GET: Hakkimizda
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Hakkimizda()
        {
            var model = db.Hakkimizda.ToList();
            return View(model);
            
        }
    }
}