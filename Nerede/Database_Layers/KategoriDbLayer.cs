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
    public class KategoriDbLayer:DbConnection
    {
        public List<Kategori> kategoriListesi()
        {
            List<Kategori> kategoriList = new List<Kategori>();
            try
            {
                cmd = new SqlCommand("SELECT * FROM Kategori", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Kategori kategori = new Kategori();
                    kategori.kategoriId= Convert.ToInt32(rdr["kategoriId"]);
                    kategori.kategoriAdi = rdr["kategoriAdi"].ToString();
                    kategoriList.Add(kategori);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
            return kategoriList;
        }
    }
}
