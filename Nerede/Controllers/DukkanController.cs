using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nerede.Models.Views;
using Nerede.Models.Tables;
using Nerede.Database_Layers;
using System.Web.Security;

namespace Nerede.Controllers
{
    public class DukkanController : Controller
    {
        // GET: Dukkan
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }

        public ActionResult cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris");
        }

        [HttpGet]
        public ActionResult yeniDukkan()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Stoklar()
        {
            ViewDbLayer viewDb = new ViewDbLayer();
            List<musteriUrun> stok = viewDb.dukkanUrunViewListe(Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name));
            return View(stok);
        }

        [Authorize]
        [HttpGet]
        public ActionResult StokEkle()
        {
            ViewDbLayer viewDb = new ViewDbLayer();
            List<urunListesi> urunler = viewDb.urunListesiViewListe();
            return View(urunler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult StokSilme(int id)
        {
            StokDbLayer stokDb = new StokDbLayer();
            stokDb.deleteStokDb(id, Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name));
            return RedirectToAction("Stoklar");
        }
        [Authorize]
        [HttpGet]
        public ActionResult stokGuncelleme(int id)
        {
            ViewDbLayer viewDb = new ViewDbLayer();
            musteriUrun urun = viewDb.urunDon(id, Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name));
            return View(urun);
        }
        [Authorize]
        [HttpGet]
        public ActionResult urunEkle()
        {
            KategoriDbLayer kategoriDb = new KategoriDbLayer();
            List<Kategori> k = kategoriDb.kategoriListesi();
            return View(k);
        }
        

        [HttpPost]
        public ActionResult Giris(Giris g)
        {
            GirisDbLayer girisDb = new GirisDbLayer();
            var u= girisDb.girisListesi().FirstOrDefault(x =>x.kullaniciAdi==g.kullaniciAdi&&x.sifre==g.sifre);
            if (u!=null)
            {
                g.dukkanId = girisDb.girisListesi().FirstOrDefault(x => x.kullaniciAdi == g.kullaniciAdi && x.sifre == g.sifre).dukkanId;
                FormsAuthentication.SetAuthCookie(g.dukkanId.ToString(),false);
                return RedirectToAction("Stoklar");
            }
            else
            {
                ViewData["hata"] = "HATA: Hatalı Kullanici Adi veya Sifre";
            }
            return View();
        }
        [HttpPost]
        public ActionResult yeniDukkan(Lokasyon l,Dukkan d,Giris g)
        {
            GirisDbLayer girisDb = new GirisDbLayer();
            var u = girisDb.girisListesi().FirstOrDefault(x => x.kullaniciAdi == g.kullaniciAdi);
            if (u==null)
            {
                LokasyonDbLayer lokasyonDb = new LokasyonDbLayer();
                lokasyonDb.insertLokasyonDb(l);
                d.koordinatId = lokasyonDb.lastIndex();
                DukkanDbLayer dukkanDb = new DukkanDbLayer();
                dukkanDb.insertDukkanDb(d);
                g.dukkanId = dukkanDb.lastIndex();
                GirisDbLayer giris = new GirisDbLayer();
                giris.insertGirisDb(g);
                return RedirectToAction("Giris");
            }
            else
            {

                ViewData["hata"] = "Kullanıcı adı kullanılmış başka bir kullanıcı adı giriniz!";
                return View();
            }
            
        }


        [HttpPost]
        public ActionResult StokEkle(Stok s)
        {
            s.dukkanId = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name);
            StokDbLayer stokDb = new StokDbLayer();
            stokDb.insertStokDb(s);
            return RedirectToAction("Stoklar");
        }


        [HttpPost]
        public ActionResult urunEkle(Urunler u,Resimler r)
        {
            UrunlerDbLayer uDb = new UrunlerDbLayer();
            if (uDb.urunListesiUrunVarmı(u.urunAdi))
            {
                if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
                {
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string TamYolYeri = "~/Images/UrunResimleri/" + DosyaAdi + uzanti;
                    r.resimAdi = DosyaAdi + uzanti;
                    r.resimYolu = "/Images/UrunResimleri/";
                    Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                    ResimlerDbLayer resimlerDb = new ResimlerDbLayer();
                    resimlerDb.insertResimlerDb(r);
                    u.resimId = resimlerDb.lastIndex();

                }
                else
                {
                    u.resimId = 1;
                }
                UrunlerDbLayer urunlerDb = new UrunlerDbLayer();
                u.urunAciklama = (u.urunAciklama == null) ? "" : u.urunAciklama;
                urunlerDb.insertUrunlerDb(u);
                return RedirectToAction("StokEkle");
            }
            else
            {
                KategoriDbLayer kategoriDb = new KategoriDbLayer();
                List<Kategori> k = kategoriDb.kategoriListesi();
                ViewData["hata"] = "Hata: Aynı İsimli Bir Ürün Vardır!";
                return View(k);
            }
            
            
        }
        [HttpPost]
        public ActionResult stokGuncelleme(Stok s)
        {
            s.dukkanId = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name);
            StokDbLayer stokDb = new StokDbLayer();
            stokDb.updateStokDb(s);
            return RedirectToAction("Stoklar");
        }
    }
}