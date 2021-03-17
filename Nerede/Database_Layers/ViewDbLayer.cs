using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nerede.Models.Views;
using Nerede.Models.Tables;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Nerede.Database_Layers
{
    public class ViewDbLayer:DbConnection
    {
       public List<urunListesi> urunListesiViewListe()
        {
            List<urunListesi> urunler = new List<urunListesi>();
            try
            {
                cmd = new SqlCommand("exec urunListe", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    urunListesi urun = new urunListesi();
                    urun.urunId = Convert.ToInt32(rdr["urunId"]);
                    urun.urunAdi = rdr["urunAdi"].ToString();
                    urun.urunDurum = rdr["urunDurum"].ToString();
                    urun.resimYolu = rdr["resimYolu"].ToString();
                    urun.resimAdi= rdr["resimAdi"].ToString();
                    urun.kategoriAdi= rdr["kategoriAdi"].ToString();
                    urunler.Add(urun);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
            return urunler;
        }

        public List<urunListesi> musteriUrunListesiViewListe(string urunAdi,decimal x,decimal y)
        {
            List<urunListesi> urunler = new List<urunListesi>();
            try
            {
                cmd = new SqlCommand("EXEC musteriUrunListe @urunAdi,@x,@y", con);
                cmd.Parameters.AddWithValue("@urunAdi",urunAdi);
                cmd.Parameters.AddWithValue("@x",x);
                cmd.Parameters.AddWithValue("@y",y);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    urunListesi urun = new urunListesi();
                    urun.urunId = Convert.ToInt32(rdr["urunId"]);
                    urun.urunAdi = rdr["urunAdi"].ToString();
                    urun.urunDurum = rdr["urunDurum"].ToString();
                    urun.resimYolu = rdr["resimYolu"].ToString();
                    urun.resimAdi = rdr["resimAdi"].ToString();
                    urun.kategoriAdi = rdr["kategoriAdi"].ToString();
                    urunler.Add(urun);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
            return urunler;
        }

        public List<musteriUrun> musteriUrunViewListe(string urunAdi, decimal x, decimal y)
        {
            List<musteriUrun> urunler = new List<musteriUrun>();
            try
            {
                cmd = new SqlCommand("EXEC urunArama @urunAdi,@x,@y", con);
                cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                cmd.Parameters.AddWithValue("@x", x);
                cmd.Parameters.AddWithValue("@y", y);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    musteriUrun urun = new musteriUrun();
                    urun.stokId = Convert.ToInt32(rdr["stokId"]);
                    urun.urunAdi = rdr["urunAdi"].ToString();
                    urun.kategoriAdi = rdr["kategoriAdi"].ToString();
                    urun.resimYolu= rdr["resimYolu"].ToString();
                    urun.resimAdi= rdr["resimAdi"].ToString();
                    urun.fiyat = Convert.ToDecimal(rdr["fiyat"]);
                    urun.indirimTutari= Convert.ToDecimal(rdr["indirimTutari"]);
                    urun.indirimliFiyat = urun.fiyat - (urun.fiyat * (urun.indirimTutari / 100));
                    urun.dukkanAdi= rdr["dukkanAdi"].ToString();
                    urun.xKoordinat = Convert.ToDecimal(rdr["xKoordinat"]);
                    urun.yKoordinat = Convert.ToDecimal(rdr["yKoordinat"]);
                    urun.stokAdet = Convert.ToInt16(rdr["stokAdet"]);
                    urunler.Add(urun);
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return urunler;
        }

        public List<musteriUrun> dukkanUrunViewListe(int dukkanId)
        {
            List<musteriUrun> urunler = new List<musteriUrun>();
            try
            {
                cmd = new SqlCommand("SELECT * FROM musteriUrun WHERE dukkanId=@dukkanId", con);
                cmd.Parameters.AddWithValue("@dukkanId", dukkanId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    musteriUrun urun = new musteriUrun();
                    urun.stokId = Convert.ToInt32(rdr["stokId"]);
                    urun.urunAdi = rdr["urunAdi"].ToString();
                    urun.kategoriAdi = rdr["kategoriAdi"].ToString();
                    urun.resimYolu = rdr["resimYolu"].ToString();
                    urun.resimAdi = rdr["resimAdi"].ToString();
                    urun.fiyat = Convert.ToDecimal(rdr["fiyat"]);
                    urun.indirimTutari = Convert.ToDecimal(rdr["indirimTutari"]);
                    urun.dukkanAdi = rdr["dukkanAdi"].ToString();
                    urun.xKoordinat = Convert.ToDecimal(rdr["xKoordinat"]);
                    urun.yKoordinat = Convert.ToDecimal(rdr["yKoordinat"]);
                    urun.stokAdet = Convert.ToInt16(rdr["stokAdet"]);
                    urun.indirimliFiyat = urun.fiyat - (urun.fiyat*(urun.indirimTutari/100));
                    urunler.Add(urun);
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return urunler;
        }

        public musteriUrun urunDon(int stokId,int dukkanId)
        {
            musteriUrun urun = new musteriUrun();
            try
            {
                cmd = new SqlCommand("SELECT * FROM musteriUrun WHERE dukkanId=@dukkanId AND stokId=@stokId", con);
                cmd.Parameters.AddWithValue("@dukkanId", dukkanId);
                cmd.Parameters.AddWithValue("@stokId", stokId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    urun.stokId = Convert.ToInt32(rdr["stokId"]);
                    urun.urunAdi = rdr["urunAdi"].ToString();
                    urun.kategoriAdi = rdr["kategoriAdi"].ToString();
                    urun.resimYolu = rdr["resimYolu"].ToString();
                    urun.resimAdi = rdr["resimAdi"].ToString();
                    urun.fiyat = Convert.ToDecimal(rdr["fiyat"]);
                    urun.indirimTutari = Convert.ToDecimal(rdr["indirimTutari"]);
                    urun.dukkanAdi = rdr["dukkanAdi"].ToString();
                    urun.xKoordinat = Convert.ToDecimal(rdr["xKoordinat"]);
                    urun.yKoordinat = Convert.ToDecimal(rdr["yKoordinat"]);
                    urun.stokAdet = Convert.ToInt16(rdr["stokAdet"]);
                    urun.indirimliFiyat = urun.fiyat - (urun.fiyat * (urun.indirimTutari / 100));
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return urun;

        }

        public List<urunListesi> sonEklenenler(decimal x, decimal y)
        {
            List<urunListesi> urunler = new List<urunListesi>();
            KategoriDbLayer kategoriDb = new KategoriDbLayer();
            List<Kategori> s = kategoriDb.kategoriListesi();
            for (int i = 0; i < s.Count(); i++)
            {
                try
                {
                    cmd = new SqlCommand("select u.urunId,u.urunAdi,u.urunDurum,u.resimYolu,u.resimAdi,u.kategoriAdi from urunListesi AS U INNER JOIN (select top (1) urunAdi,stokId from urunAra('',@x,@y)  where kategoriAdi=@kategoriAdi order by stokId DESC) AS B ON U.urunAdi=B.urunAdi", con);
                    cmd.Parameters.AddWithValue("@kategoriAdi", s[i].kategoriAdi);
                    cmd.Parameters.AddWithValue("@x", x);
                    cmd.Parameters.AddWithValue("@y", y);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        urunListesi urun = new urunListesi();
                        urun.urunId = Convert.ToInt32(rdr["urunId"]);
                        urun.urunAdi = rdr["urunAdi"].ToString();
                        urun.urunDurum = rdr["urunDurum"].ToString();
                        urun.resimYolu = rdr["resimYolu"].ToString();
                        urun.resimAdi = rdr["resimAdi"].ToString();
                        urun.kategoriAdi = rdr["kategoriAdi"].ToString();
                        urunler.Add(urun);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

            return urunler;
        }

    }
}