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
    public class LokasyonDbLayer:DbConnection
    {
        public LokasyonDbLayer()
        {
            this.tabloAdi = "Lokasyon";
        }
        public void insertLokasyonDb(Lokasyon lokasyon)
        {
            try
            {
                this.cmd = new SqlCommand("INSERT INTO Lokasyon (xKoordinat,yKoordinat) VALUES(@xKoordinat,@yKoordinat)", con);
                this.cmd.Parameters.AddWithValue("@xKoordinat", lokasyon.xKoordinat);
                this.cmd.Parameters.AddWithValue("@yKoordinat", lokasyon.yKoordinat);
                this.con.Open();
                this.cmd.ExecuteNonQuery();
                this.con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.con.Close();
            }

        }
    }
}