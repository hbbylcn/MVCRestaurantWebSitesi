using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MAVİRESTAURANT.Models.Entity;

namespace MAVİRESTAURANT.Controllers.Mavi
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        dbmaviwebEntities db = new dbmaviwebEntities();
        [HttpGet]
        public ActionResult Iletisim()
        {
            var iletisim = db.IletisimBilgileri.ToList();
            var calisma = db.CalismaPlani.ToList();
            return View(Tuple.Create(iletisim, calisma));
        }
        [HttpPost]
        public ActionResult Iletisim(Contact model, Iletisim d)
        {
            var deger = db.Iletisim.Add(d);
            var iletisim = db.IletisimBilgileri.ToList();
            var calisma = db.CalismaPlani.ToList();

            if (db.SaveChanges() > 0)
            {
                if (ModelState.IsValid)
                {
                    var body = new StringBuilder();
                    body.AppendLine("Ad Soyad: " + model.AdSoyad);
                    body.AppendLine("Mail : " + model.Mail);
                    body.AppendLine("Konu: " + model.Konu);
                    body.AppendLine("Mesaj: " + model.Mesaj);
                    Mail.MailSender(body.ToString());
                    ViewBag.Success = true;
                   

                }

            }
            return View(Tuple.Create(iletisim, calisma));
        }
    }
}