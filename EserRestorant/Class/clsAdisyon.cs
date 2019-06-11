using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EserRestorant
{
    class clsAdisyon
    {
        clsGenel gnl = new clsGenel();

        #region fields
        private int _ID;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _PersonelId;
        private int _Durum;
        private int _MasaId;
        #endregion

        #region Properties
        public int ID
        {
            get => _ID;
            set => _ID = value;
        }

        public int ServisTurNo
        {
            get => _ServisTurNo;
            set => _ServisTurNo = value;
        }

        public decimal Tutar
        {
            get => _Tutar;
            set => _Tutar = value;
        }

        public DateTime Tarih
        {
            get => _Tarih;
            set => _Tarih = value;
        }

        public int PersonelId
        {
            get => _PersonelId;
            set => _PersonelId = value;
        }

        public int Durum
        {
            get => _Durum;
            set => _Durum = value;
        }

        public int MasaId
        {
            get => _MasaId;
            set => _MasaId = value;
        } 
        #endregion


        //Açık olan masanın ID numarası
        public int getByAddition(int MasaId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From ADISYONLAR Where MASAID=@MasaId Order by ID desc", con);

            cmd.Parameters.Add("@MasaId",SqlDbType.Int).Value = MasaId;
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MasaId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return MasaId;
        }

        public bool setByAdditionNew(clsAdisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("INSERT INTO ADISYON(SERVISTURNO,TARIH,PERSONELID,MASAID,DURUM) VALUES(@ServisTurNo,@Tarih,@PersonelID,@MasaId,@Durum)",con);
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServisTurNo",SqlDbType.Int).Value = Bilgiler.ServisTurNo;

                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@Durum", SqlDbType.Bit).Value = 0;

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }

        public void adisyonkapat(int adisyonID, int durum)
        {
            //bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update ADISYON set DURUM = @durum where ID = @adisyonId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                cmd.Parameters.Add("durum", SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();
                //result = Convert.ToBoolean(cmd.ExecuteScalar());
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

            //return result;
        }

        public int paketAdisyonIdbulAdedi()
        {
            int miktar = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) as Sayi FROM ADISYON WHERE (DURUM = 0) AND (SERVISTURNO = 2)", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                miktar = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return miktar;
        } //kontrol edildi...

        public void acikPaketAdisyonlar(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select PAKETSIPARIS.MUSTERIID, MUSTERILER.AD + ' ' + MUSTERILER.SOYAD as Musteri, " +
                                            "ADISYON.ID as adisyonID from PAKETSIPARIS" +
                                            " inner join MUSTERILER on MUSTERILER.ID=PAKETSIPARIS.MUSTERIID " +
                                            "inner join ADISYON on ADISYON.ID = PAKETSIPARIS.ADISYONID where ADISYON.DURUM=0", con);

            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int sayac = 0;

                while (dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Musteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adisyonID"].ToString());
                    
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        } //kontrol edildi...

        public int musterininsonadisyonId(int musteriId)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT ADISYON.ID FROM ADISYON " +
                                            "INNER JOIN PAKETSIPARIS ON PAKETSIPARIS.ADISYONID=ADISYON.ID " +
                                            "WHERE PAKETSIPARIS.DURUM=0 AND ADISYON.DURUM=0 AND PAKETSIPARIS.MUSTERIID=@musteriId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;


                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        } //kontrol edildi...

        public void musteriDetaylar(ListView lv, int musteriId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT PAKETSIPARIS.MUSTERIID, PAKETSIPARIS.ADISYONID, MUSTERILER.AD, MUSTERILER.SOYAD, CONVERT(varchar(10), ADISYON.TARIH, 104)" +
                                            " AS TARIH FROM ADISYON INNER JOIN PAKETSIPARIS ON PAKETSIPARIS.ADISYONID = ADISYON.ID " +
                                            "INNER JOIN MUSTERILER ON MUSTERILER.ID = PAKETSIPARIS.MUSTERIID" +
                                            " WHERE ADISYON.SERVISTURNO = 2 AND PAKETSIPARIS.MUSTERIID = @musteriId", con);

            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
            SqlDataReader dr = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                int sayac = 0;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Close();
            }
        }//kontrol edildi...
    }
}
