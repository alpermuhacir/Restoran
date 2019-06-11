using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EserRestorant
{
    class clsPersoneller
    {
        clsGenel clsGenel = new clsGenel();

        //We made definitions from the database
        #region Fields
        private int _PersonelID;
        private int _PersonelGorevID;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;//gerek yok...
        private bool _PersonelDurum;
        #endregion

        //Encapsulating our definitions
        #region Properties

        public int PersonelID
        {
            get => _PersonelID;
            set => _PersonelID = value;
        }

        public int PersonelGorevID
        {
            get => _PersonelGorevID;
            set => _PersonelGorevID = value;
        }

        public string PersonelAd
        {
            get => _PersonelAd;
            set => _PersonelAd = value;
        }

        public string PersonelSoyad
        {
            get => _PersonelSoyad;
            set => _PersonelSoyad = value;
        }

        public string PersonelParola
        {
            get => _PersonelParola;
            set => _PersonelParola = value;
        }

        //gerek yok...
        public string PersonelKullaniciAdi
        {
            get => _PersonelKullaniciAdi;
            set => _PersonelKullaniciAdi = value;
        }

        public bool PersonelDurum
        {
            get => _PersonelDurum;
            set => _PersonelDurum = value;
        }
        #endregion

        //Check our entry
        public bool personelEntryControl(string Password, int UserID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("Select * from PERSONELLER where ID=@Id and PAROLA=@Password", con);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserID;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;
        }

        //Get our information
        public void personelGetbyInformation(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("Select * from PERSONELLER", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                clsPersoneller p = new clsPersoneller();
                p._PersonelID = Convert.ToInt32(dr["ID"]);
                p._PersonelGorevID = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                p._PersonelDurum = Convert.ToBoolean(dr["DURUM"]);
                cb.Items.Add(p);
            }
            dr.Close();
            con.Close();
        }

        //Override our entry
        public override string ToString()
        {
            return PersonelAd + " " + PersonelSoyad;
        }

        public void personelBilgileriniGetirLV(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("Select PERSONELLER.* ,PERSONELGOREVLERI.GOREV From PERSONELLER " +
                                            "Inner Join PERSONELGOREVLERI on PERSONELGOREVLERI.ID = PERSONELLER.GOREVID" +
                                            " WHERE PERSONELLER.DURUM=0", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            int i = 0;

            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }
            dr.Close();
            con.Close();
        }//kontrol edildi...

        public void personelBilgileriniGetirFromIDLV(ListView lv, int perID)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("Select PERSONELLER.* ,PERSONELGOREVLERI.GOREV From Personeller " +
                                            "Inner Join PERSONELGOREVLERI on PERSONELGOREVLERI.ID = PERSONELLER.GOREVID" +
                                            " WHERE PERSONELLER.DURUM=0 and PERSONELLER.ID=@perID", con);

            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            int i = 0;

            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }
            dr.Close();
            con.Close();
        }//kontrol edildi...

        public string personelBilgiGetirIsim(int perId)
        {
            string sonuc = "";

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("Select AD + SOYAD From PERSONELLER " +
                                            "WHERE PERSONELLER.DURUM=0 and PERSONELLER.ID=@perId", con); // boşluk gelecek...
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();
            return sonuc;
        } // düzenleme...

        public bool personelSifreDegistir(int personelID, string pass)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("UPDATE PERSONELLER SET PAROLA = @pass WHERE ID=perId", con);

            cmd.Parameters.Add("perID", SqlDbType.Int).Value = personelID;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            return sonuc;
        }

        public bool personelEkle(clsPersoneller cp)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("INSERT INTO PERSONELLER(AD,SOYAD,GOREVID,PAROLA) VALUES (@AD,@SOYAD,@GOREVID,@PAROLA);", con);

            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevID;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            return sonuc;
        }//kontrol edildi...

        public bool personelGuncelle(clsPersoneller cp, int perId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("UPDATE PERSONELLER SET AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA,GOREVID=@GOREVID " +
                                            "WHERE ID = @perID", con);

            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;//...
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevID;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            return sonuc;
        }

        public bool personelSil(int perId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(clsGenel.conString);
            SqlCommand cmd = new SqlCommand("UPDATE PERSONELLER SET DURUM = 1 where ID = @perID", con);

            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            return sonuc;
        }//kontrol edildi...
    }
}
