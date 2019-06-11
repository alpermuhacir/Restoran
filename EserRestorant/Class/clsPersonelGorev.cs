using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EserRestorant
{
    class clsPersonelGorev
    {
        clsGenel gnl = new clsGenel();

        #region Properties
        private int _personelGorevId;
        private string _tanim;
        #endregion

        #region Fields
        public int PersonelGorevId { get => _personelGorevId; set => _personelGorevId = value; }
        public string Tanim { get => _tanim; set => _tanim = value; }
        #endregion

        public void PersonelGorevGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from PERSONELGOREVLERI", con);

            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    clsPersonelGorev c = new clsPersonelGorev();
                    c._personelGorevId = Convert.ToInt32(dr["ID"].ToString());
                    c._tanim = dr["GOREV"].ToString();
                    cb.Items.Add(c);
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            dr.Close();
            con.Close();
        }

        public string PersonelGorevTanim(int per)
        {
            string sonuc = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select GOREV from PERSONELGOREVLERI where ID=@perId", con);

            cmd.Parameters.Add("perId", SqlDbType.Int).Value = per;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            con.Close();

            return sonuc;
        }

        public override string ToString()
        {
            return _tanim;
        }
    }
}
