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
    public class GirisDbLayer:DbConnection
    {
        public void insertGirisDb(Giris giris)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO Giris (kullaniciAdi,sifre,dukkanId) VALUES(@kullaniciAdi,@sifre,@dukkanId)", con);
                cmd.Parameters.AddWithValue("@kullaniciAdi", giris.kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", giris.sifre);
                cmd.Parameters.AddWithValue("@dukkanId", giris.dukkanId);
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

        public List<Giris> girisListesi()
        {
            List<Giris> girisList = new List<Giris>();
            try
            {
                cmd = new SqlCommand("SELECT * FROM Giris", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Giris giris = new Giris();
                    giris.dukkanId = Convert.ToInt32(rdr["dukkanId"]);
                    giris.kullaniciAdi = rdr["kullaniciAdi"].ToString();
                    giris.sifre = rdr["sifre"].ToString();
                    girisList.Add(giris);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
            return girisList;
        }
    }
}