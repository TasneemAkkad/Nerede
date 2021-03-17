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
    public class DukkanDbLayer : DbConnection
    {
        public DukkanDbLayer()
        {
            this.tabloAdi = "Dukkan";
        }
        public List<Dukkan> dukkanDbList()
        {
            List<Dukkan> dukkanList = new List<Dukkan>();
            try
            {
                cmd = new SqlCommand("SELECT * FROM Dukkan", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Dukkan dukkan = new Dukkan();
                    dukkan.dukkanId = Convert.ToInt32(rdr["dukkanId"]);
                    dukkan.dukkanAdi = rdr["dukkanAdi"].ToString();
                    dukkan.koordinatId = Convert.ToInt32(rdr["koordinatId"]);
                    dukkanList.Add(dukkan);
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
            return dukkanList;

        }

        public void insertDukkanDb(Dukkan dukkan)
        {
            try
            {
                this.cmd = new SqlCommand("INSERT INTO Dukkan (dukkanAdi,koordinatId) VALUES(@dukkanAdi,@koordinatId)", con);
                this.cmd.Parameters.AddWithValue("@dukkanAdi", dukkan.dukkanAdi);
                this.cmd.Parameters.AddWithValue("@koordinatId", dukkan.koordinatId);
                this.con.Open();
                this.cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                this.con.Close();
            }

        }
    }


}