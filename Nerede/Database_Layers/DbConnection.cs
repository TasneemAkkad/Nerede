using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Nerede.Database_Layers
{
    public abstract class DbConnection
    {
        protected string connectionString;
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected string tabloAdi;
        public DbConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            con = new SqlConnection(connectionString);
        }
        public int lastIndex()
        {
            cmd = new SqlCommand("EXEC SonKaydedilen @tablo", con);
            cmd.Parameters.AddWithValue("@tablo", tabloAdi);
            con.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;
        }
    }
}