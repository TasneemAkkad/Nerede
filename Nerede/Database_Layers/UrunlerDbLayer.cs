using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nerede.Models.Tables;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Nerede.Database_Layers
{
    public class UrunlerDbLayer:DbConnection
    {
        public UrunlerDbLayer()
        {
            this.tabloAdi = "Urunler";
        }
        public void insertUrunlerDb(Urunler urun)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO Urunler (urunAdi,kategoriId,resimId,urunAciklama) VALUES(@urunAdi,@kategoriId,@resimId,@urunAciklama)", con);
                cmd.Parameters.AddWithValue("@urunAdi", urun.urunAdi);
                cmd.Parameters.AddWithValue("@kategoriId", urun.kategoriId);
                cmd.Parameters.AddWithValue("@resimId", urun.resimId);
                cmd.Parameters.AddWithValue("@urunAciklama", urun.urunAciklama);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }

        }

       
        public string urunAdiBul(int id)
        {
            cmd = new SqlCommand("Select urunAdi From Urunler WHERE urunId=@uid", con);
            cmd.Parameters.AddWithValue("@uid", id);
            con.Open();
            string urunAdi = cmd.ExecuteScalar().ToString();
            con.Close();
            return urunAdi;
        }

        public bool urunListesiUrunVarmı(string uAdi)
        {
            List<Urunler> urunList = new List<Urunler>();
            try
            {
                cmd = new SqlCommand("SELECT * FROM Urunler where urunAdi=@uAdi", con);
                cmd.Parameters.AddWithValue("@uAdi", uAdi);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Urunler urun = new Urunler();
                    urun.urunId = Convert.ToInt32(rdr["urunId"]);
                    urunList.Add(urun);
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
            bool rtrn;
            if (urunList.Count() > 0)
            {
                rtrn = false;
            }
            else
            {
                rtrn = true;
            }
            return rtrn;
        }
    }
}