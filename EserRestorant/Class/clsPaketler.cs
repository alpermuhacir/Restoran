using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace EserRestorant
{
    class clsPaketler
    {
        clsGenel gnl = new clsGenel();

        #region MyRegion
        private int _ID;
        private int _AdditionID;
        private int _ClientID;
        private string _Description;
        private int _State;
        private int __PaytypeId;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int AdditionID { get => _AdditionID; set => _AdditionID = value; }
        public int ClientID { get => _ClientID; set => _ClientID = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int State { get => _State; set => _State = value; }
        public int PaytypeId { get => __PaytypeId; set => __PaytypeId = value; } 
        #endregion

        //paket servisi açma
        public bool OrderServiceOpen(clsPaketler order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("INSERT INTO PAKETSIPARIS(ADISYONID,MUSTERIID,ODEMETURID,ACIKLAMA) VALUES (@ADISYONID,@MUSTERIID,@ODEMETURID,@ACIKLAMA)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = order._AdditionID;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = order._ClientID;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = order.__PaytypeId;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = order._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

        //paket servis kapatma
        public void OrderServiceClose(int AdditionID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update PAKETSIPARIS set PAKETSIPARIS.DURUM = 1 WHERE PAKETSIPARIS.ADISYONID = @AdditionID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdditionID", SqlDbType.Int).Value = AdditionID;

                Convert.ToBoolean(cmd.ExecuteNonQuery());
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
        }

        //açılan adisyon ve paket siparişe ait ön girilen ödeme tür ID
        public int OdemeTurIdGetir(int adisyonId)
        {
            int odemeTurID = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT PAKETSIPARIS.ODEMETURID" +
                                            " FROM PAKETSIPARIS INNER JOIN ADISYON ON PAKETSIPARIS.ADISYONID = ADISYON.ID" +
                                            "WHERE ADISYON.ID = @adisyonId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonId;

                odemeTurID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                //throw;//sıkıntı
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return odemeTurID;
        }

        //sipariş kontrol için müşteriye ait açık olan en son adisyon nosunu getirme
        //bir müşteriye ait 2 tane siparişin açık olamayacağını belirttik
        public int musteriSonAdisyonIDGetir(int musteriID)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT ADISYON.ID" +
                                            " FROM ADISYON INNER JOIN PAKETSIPARIS ON PAKETSIPARIS.ADISYONID = ADISYON.ID" +
                                            "WHERE (ADISYON.DURUM = 0) and (PAKETSIPARIS.DURUM = 0) and (PAKETSIPARIS.MUSTERIID=@musteriID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@musteriID", SqlDbType.Int).Value = musteriID;

                no = Convert.ToInt32(cmd.ExecuteScalar());
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

            return no;
        }

        //müşteri arama ekranında adisyon bul butonu, adisyon açık mı değil mi kontrol...
        public bool getCheckOpenAdditionID(int additionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ADISYON WHERE (DURUM = 0) AND (ID = @additionID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@additionID", SqlDbType.Int).Value = additionID;
                
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
    }
}
