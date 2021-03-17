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
    public class StokDbLayer:DbConnection
    {
        public StokDbLayer()
        {
            this.tabloAdi = "Stok";
        }
    public void insertStokDb(Stok stok)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO Stok (urunId,stokAdet,fiyat,indirimTutari,dukkanId) VALUES(@urunId,@stokAdet,@fiyat,@indirimTutari,@dukkanId)", con);
                cmd.Parameters.AddWithValue("@urunId", stok.urunId);
                cmd.Parameters.AddWithValue("@stokAdet", stok.stokAdet);
                cmd.Parameters.AddWithValue("@fiyat", stok.fiyat);
                cmd.Parameters.AddWithValue("@indirimTutari", stok.indirimTutari);
                cmd.Parameters.AddWithValue("@dukkanId", stok.dukkanId);
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
        public void deleteStokDb(int stokId,int dukkanId)
        {
            try
            {
            cmd = new SqlCommand("DELETE FROM Stok WHERE stokId =@stokId AND dukkanId =@dukkanId ", con);
            cmd.Parameters.AddWithValue("@stokId",stokId);
            cmd.Parameters.AddWithValue("@dukkanId", dukkanId);
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

        public void updateStokDb(Stok s)
        {
            try
            {
                cmd = new SqlCommand("UPDATE Stok SET stokAdet = @stokAdet , fiyat = @fiyat ,indirimTutari = @indirimTutari WHERE stokId = @stokId AND dukkanId = @dukkanId ", con);
                cmd.Parameters.AddWithValue("@stokId", s.stokId);
                cmd.Parameters.AddWithValue("@dukkanId",s.dukkanId);
                cmd.Parameters.AddWithValue("@stokAdet", s.stokAdet);
                cmd.Parameters.AddWithValue("@fiyat", s.fiyat);
                cmd.Parameters.AddWithValue("@indirimTutari", s.indirimTutari);
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