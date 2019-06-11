using System;
using System.Data;
using System.Data.SqlClient;

namespace EserRestorant
{
    class clsPersonelHareketleri
    {
        clsGenel gnl = new clsGenel();

        #region Fields

        private int _ID;
        private int _PersonelID;
        private string _Islem;
        private DateTime _Tarih;
        private bool _Durum;

        #endregion

        #region Properties

        public int ID
        {
            get => _ID;
            set => _ID = value;
        }

        public int PersonelID
        {
            get => _PersonelID;
            set => _PersonelID = value;
        }

        public string Islem
        {
            get => _Islem;
            set => _Islem = value;
        }

        public DateTime Tarih
        {
            get => _Tarih;
            set => _Tarih = value;
        }

        public bool Durum
        {
            get => _Durum;
            set => _Durum = value;
        }

        #endregion

        public bool PersonelActionSave(clsPersonelHareketleri ph/*int personelID,string islem,DateTime tarih*/)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into PERSONELHAREKETLERI(PERSONELID,ISLEM,TARIH)Values(@personelID,@islem,@tarih)", con);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }

                cmd.Parameters.Add("@personelID", SqlDbType.Int).Value = ph._PersonelID;
                cmd.Parameters.Add("@islem", SqlDbType.VarChar).Value = ph._Islem;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = ph._Tarih;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;
        }
    }
}
