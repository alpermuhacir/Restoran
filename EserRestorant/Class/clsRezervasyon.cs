using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EserRestorant
{
    class clsRezervasyon
    {
        clsGenel gnl = new clsGenel();

        #region Fields
        private int _ID;
        private int _TableId;
        private int _ClientId;
        private DateTime _Date;
        private int _ClientCount;
        private string _Description;
        private int _AdditionId;
        #endregion

        #region Properties
        public int ID
        {
            get => _ID;
            set => _ID = value;
        }

        public int TableId
        {
            get => _TableId;
            set => _TableId = value;
        }

        public int ClientId
        {
            get => _ClientId;
            set => _ClientId = value;
        }

        public DateTime Date
        {
            get => _Date;
            set => _Date = value;
        }

        public int ClientCount
        {
            get => _ClientCount;
            set => _ClientCount = value;
        }

        public string Description
        {
            get => _Description;
            set => _Description = value;
        }

        public int AdditionId
        {
            get => _AdditionId;
            set => _AdditionId = value;
        }
        #endregion

        //MusteriId masa numarasına göre
        public int getByClientIdFromRezervasyon(int tableId)
        {
            int clientId = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 1 MUSTERIID from REZERVASYONLAR where MASAID=@masaid order by MUSTERIID Desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("masaid", SqlDbType.Int).Value = tableId;

                clientId = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return clientId;
        }

        //hesap kapatırken rezervasyonlu masayı da kapattık
        public bool rezervationclose(int adisyonID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update REZERVASYONLAR set DURUM = 0 where ADISYONID = @adisyonId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;
        }

        //Rezervasyonları Getir
        public void musteriIdGetirFromRezervasyon(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("SELECT REZERVASYONLAR.MUSTERIID,( AD + SOYAD ) AS MUSTERI FROM REZERVASYONLAR " +
                                             "INNER JOIN MUSTERILER ON REZERVASYONLAR.MUSTERIID=MUSTERILER.ID " +
                                             "WHERE REZERVASYONLAR.DURUM=0", conn);
            
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["MUSTERI"].ToString());
                i++;
            }

            dr.Close();
            conn.Dispose();
            conn.Close();
        }

        //Eski Rezervasyonları Getir
        public void eskiRezervasyonlariGetir(ListView lv, int mId)
        {
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("SELECT REZERVASYONLAR.MUSTERIID, AD, SOYAD, ADISYONID, TARIH FROM REZERVASYONLAR " +
                                             "INNER JOIN MUSTERILER ON REZERVASYONLAR.MUSTERIID=MUSTERILER.ID " +
                                             "WHERE REZERVASYONLAR.MUSTERIID=@mId AND REZERVASYONLAR.DURUM=0 ORDER BY REZERVASYONLAR.ID DESC", conn);

            comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["TARIH"].ToString());
                lv.Items[i].SubItems.Add(dr["ADISYONID"].ToString());
                i++;
            }

            dr.Close();
            conn.Dispose();
            conn.Close();
        }

        //En Son Rezervasyon Tarihini Getir
        public DateTime EnsonRezervasyonTarihi(int mId)
        {
            DateTime tar = new DateTime();
            tar = DateTime.Now;

            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("SELECT TARIH FROM REZERVASYONLAR " +
                                             "WHERE REZERVASYONLAR.MUSTERIID=@mId AND REZERVASYONLAR.DURUM=1 ORDER BY REZERVASYONLAR.ID DESC", conn);

            comm.Parameters.Add("mId", SqlDbType.Int).Value = mId;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            tar = Convert.ToDateTime(comm.ExecuteScalar());
            
            conn.Dispose();
            conn.Close();

            return tar;
        }

        //Açık Rezervasyonların Sayısını Getir
        public int acikRezervasyonSayisi()
        {
            int sonuc = 0;
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM REZERVASYONLAR WHERE REZERVASYONLAR.DURUM=0", conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                sonuc = Convert.ToInt32(comm.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }
            
            conn.Dispose();
            conn.Close();

            return sonuc;
        }
    }
}
