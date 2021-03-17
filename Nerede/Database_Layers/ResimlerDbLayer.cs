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
    public class ResimlerDbLayer:DbConnection
    {
        public ResimlerDbLayer()
        {
            this.tabloAdi = "Resimler";
        }
        public void insertResimlerDb(Resimler resim)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO Resimler (resimAdi,resimYolu) VALUES(@resimAdi,@resimYolu)", con);
                cmd.Parameters.AddWithValue("@resimAdi", resim.resimAdi);
                cmd.Parameters.AddWithValue("@resimYolu", resim.resimYolu);
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
    }
}