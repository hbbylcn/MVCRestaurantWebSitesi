using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAVİRESTAURANT.Models.Entity
{
    public class Sepet
    {
        public static Sepet AktifSepet
        {
            get
            {
                HttpContext ctx = HttpContext.Current;//Giriş yapmış kullanıcının Session'unu tutar.
                if (ctx.Session["AktifSepet"] == null)
                    ctx.Session["AktifSepet"] = new Sepet();

                return (Sepet)ctx.Session["AktifSepet"];
            }
        }
        private List<SepetItem> Urunler = new List<SepetItem>();

        public List<SepetItem> SepetUrunler//içinde ürünleri tutuyoruz
        {
            get
            {
                return Urunler;
            }
            set
            {
                Urunler = value;
            }
        }
        public void SepeteEkle(SepetItem si)
        {
            if (HttpContext.Current.Session["AktifSepet"] != null)
            {
                Sepet s = (Sepet)HttpContext.Current.Session["AktifSepet"];

                if (s.SepetUrunler.Any(x => x.yemek.UrunId == si.yemek.UrunId))
                {
                    s.SepetUrunler.FirstOrDefault(x => x.yemek.UrunId == si.yemek.UrunId).Adet++;
                }
                else
                {
                    s.SepetUrunler.Add(si);
                }
            }
            else
            {
                Sepet s = new Sepet();
                s.SepetUrunler.Add(si);
                HttpContext.Current.Session["AktifSepet"] = s;
            }

        }
        public decimal ToplamTutar
        {
            get
            {
                return SepetUrunler.Sum(x => x.Tutar);
            }
        }
    }
    public class SepetItem //Birden fazla ürün ekleme için
    {
        public Urunler yemek { get; set; }
        /* public CokSatanlar CokSatan { get; set; }*/ //üründen nesne tutuyoruz
        public int Adet { get; set; }
        

        public decimal Tutar
        {
            get
            {
                return Convert.ToDecimal(yemek.Fiyat) * Adet;
            }
        }
    }
}
