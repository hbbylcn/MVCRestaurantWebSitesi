using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;
using System.Data.Entity;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class MenuController : Controller
    {
        // GET: Menu
        dbmaviwebEntities db = new dbmaviwebEntities();
        public ActionResult Menu()
        {

            var kategori = db.Kategori.Include(x=>x.Urunler).ToList();
            var urun = db.Urunler.ToList();

            //return View(Tuple.Create(kategori, urun));
            return View(kategori);
        }

        public PartialViewResult GetProducts(int Id)
        {
            var urunler = db.Urunler.Where(x => x.Kategori == Id).ToList();
            return PartialView("_Urunler", urunler);
        }
        
    }
}