using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nerede.Models.Tables;
using Nerede.Database_Layers;
using Nerede.Models.Views;

namespace Nerede.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Anasayfa()
        {
            if (Request.Cookies["x"]!=null)
            {
                ViewDbLayer viewDb = new ViewDbLayer();
                List<urunListesi> urun = viewDb.sonEklenenler(Convert.ToDecimal(Request.Cookies["x"].Value), Convert.ToDecimal(Request.Cookies["y"].Value));
                return View(urun);
            }
            return RedirectToAction("Giris");
        }
        public ActionResult Urun(int id)
        {
            if (Request.Cookies["x"] != null)
            {
                UrunlerDbLayer urunlerDb = new UrunlerDbLayer();
                ViewDbLayer viewDb = new ViewDbLayer();
                List<musteriUrun> urun = viewDb.musteriUrunViewListe(urunlerDb.urunAdiBul(id), Convert.ToDecimal(Request.Cookies["x"].Value), Convert.ToDecimal(Request.Cookies["y"].Value));
                urun.Sort((x, y) => x.indirimliFiyat.CompareTo(y.indirimliFiyat));
                ViewData["x"] = Convert.ToDecimal(Request.Cookies["x"].Value);
                return View(urun);
            }
            return RedirectToAction("Giris");
            
        }
        public ActionResult Arama(string urunA)
        {
            if (Request.Cookies["x"] != null)
            {
                ViewDbLayer viewDb = new ViewDbLayer();
                List<urunListesi> urunler = viewDb.musteriUrunListesiViewListe(urunA, Convert.ToDecimal(Request.Cookies["x"].Value), Convert.ToDecimal(Request.Cookies["y"].Value));
                return View(urunler);
            }
            return RedirectToAction("Giris");
        }
        [HttpPost]
        public ActionResult Giris(Lokasyon l)
        {
            Response.Cookies["y"].Value = l.yKoordinat.ToString();
            Response.Cookies["x"].Value = l.xKoordinat.ToString();
           
            return RedirectToAction("Anasayfa");
        }


    }
}