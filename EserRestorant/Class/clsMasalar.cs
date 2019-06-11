using System;
using System.Data;
using System.Data.SqlClient;

namespace EserRestorant
{
    class clsMasalar
    {

        #region Fields
        private int _ID;
        private int _KAPASITE;
        private int _SERVISTURU;
        private int _DURUM;
        private int _ONAY;
        #endregion

        #region Properties
        public int ID
        {
            get => _ID;
            set => _ID = value;
        }

        public int KAPASITE
        {
            get => _KAPASITE;
            set => _KAPASITE = value;
        }

        public int SERVISTURU
        {
            get => _SERVISTURU;
            set => _SERVISTURU = value;
        }

        public int DURUM
        {
            get => _DURUM;
            set => _DURUM = value;
        }

        public int ONAY
        {
            get => _ONAY;
            set => _ONAY = value;
        }
        #endregion

        clsGenel gnl = new clsGenel();
        public string SessionSum(int state, string masaId)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH,MASAID From ADISYON Right Join MASALAR on ADISYON.MASAID=MASALAR.ID Where MASALAR.DURUM=@durum and ADISYON.DURUM=0 and MASALAR.ID=@masaId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = Convert.ToInt32(masaId);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
                    //dt = Convert.ToDateTime(dr["@TARIH"]).ToString();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;
        }

        public int TableGetByNumber(string TableValue)
        {
            string aa = TableValue;
            int length = aa.Length;


            if (length > 8)
            {
                return Convert.ToInt32(aa.Substring(length - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(length - 1, 1));
            }


        }

        public bool TableGetByState(int ButtonName, int state)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM From MASALAR Where ID=@TableId and DURUM=@state", con);

            cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;
        }

        public void setChangeTableState(string ButtonName, int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("UPDATE MASALAR SET DURUM = @Durum where ID=@MasaNo", con);
            string masaNo = "";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string aa = ButtonName;
            int uzunluk = aa.Length;

            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            if (uzunluk > 8)
            {
                masaNo = aa.Substring(uzunluk - 2, 2);
            }
            else
            {
                masaNo = aa.Substring(uzunluk - 1, 1);
            }

            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = masaNo; //aa.Substring(uzunluk - 1, 1);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
    }
}
