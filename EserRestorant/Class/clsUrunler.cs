using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EserRestorant.Class
{
    class clsUrunler
    {
        clsGenel gnl = new clsGenel();

        #region Fields
        private int _urunid;
        private int _urunturno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;
        #endregion

        #region Properties
        public int Urunid { get => _urunid; set => _urunid = value; }
        public int Urunturno { get => _urunturno; set => _urunturno = value; }
        public string Urunad { get => _urunad; set => _urunad = value; }
        public decimal Fiyat { get => _fiyat; set => _fiyat = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; } 
        #endregion

        //ürün adına göre listeleme...
        public void urunleriListeleByUrunAdi(ListView lv, string urunadi)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM URUNLER WHERE DURUM = 0 and URUNAD like '&'+ urunAdi +'&'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = urunadi;
            
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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(String.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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
        }

        //ürün ekle
        public int urunEkle(clsUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("INSERT INTO URUNLER(URUNAD,KATEGORIID,ACIKLAMA,FIYAT)" +
                                            " VALUES(@urunAd,@katId,@aciklama,@fiyat);", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        }

        //ürünler ve kategorileri listele...
        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT URUNLER.* , KATEGORI FROM URUNLER " +
                                            "INNER JOIN KATEGORILER ON KATEGORILER.ID = URUNLER.KATEGORIID WHERE URUNLER.DURUM = 0", con);
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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(String.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
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
        }

        //urunleri güncelle
        public int urunGuncelle(clsUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update URUNLER set URUNAD=@urunad, KATEGORIID=@katID, ACIKLAMA=@aciklama, FIYAT=@fiyat where ID=@urunID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katID", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        }

        //urunleri sil
        public int UrunSil(clsUrunler u, int kat)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            //SqlCommand cmd = new SqlCommand("Update URUNLER set ID=1 where DURUM=@urunID", con);
            //SqlCommand cmd = new SqlCommand("Update URUNLER set DURUM=1 where ID=@urunID", con);

            string sql = "Update URUNLER set DURUM=1 where ";
            if (kat == 0)
            {
                sql += "KATEGORIID = @urunID";
            }
            else
            {
                sql += "ID = @urunID";
            }

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                /*cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katID", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;*/

                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        }

        //ürünID ye göre listeleme...
        public void urunleriListeleByUrunId(ListView lv, int urunId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM URUNLER WHERE DURUM = 0 and ID = urunID'", con);
            SqlCommand cmd = new SqlCommand("SELECT URUNLER.* , KATEGORI FROM URUNLER " +
                                            "INNER JOIN KATEGORILER ON KATEGORILER.ID = URUNLER.KATEGORIID WHERE URUNLER.DURUM = 0 and URUNLER.KATEGORIID=@urunID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = urunId;

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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(String.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    sayac++;

                    /*lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(String.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    sayac++;*/
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

        //bütün ürün kategorilerini 2 tarih arası getir
        public void urunleriListeleIstatistiklereGore(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select top 10 dbo.URUNLER.URUNAD, SUM(dbo.SATISLAR.ADET) as adeti " +
                                            "from dbo.KATEGORILER inner join dbo.URUNLER on dbo.KATEGORILER.ID = dbo.URUNLER.KATEGORIID " +
                                            "inner join dbo.SATISLAR on dbo.URUNLER.ID = dbo.SATISLAR.URUNID " +
                                            "inner join dbo.ADISYON on dbo.SATISLAR.ADISYONID = dbo.ADISYON.ID " +
                                            "where (CONVERT(datetime, TARIH, 104) BETWEEN CONVERT(datetime, @Baslangic, 104) AND CONVERT(datetime, @Bitis, 104)) " +
                                            "group by dbo.URUNLER.URUNAD order by adeti desc", con);

            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();

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
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
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

        //belli kategoriye ait ürünleri listeliyor
        public void urunleriListeleIstatistiklereGoreUrunId(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis,int urunkatId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select top 10 dbo.URUNLER.URUNAD, SUM(dbo.SATISLAR.ADET) as adeti " +
                                            "from dbo.KATEGORILER inner join dbo.URUNLER on dbo.KATEGORILER.ID = dbo.URUNLER.KATEGORIID " +
                                            "inner join dbo.SATISLAR on dbo.URUNLER.ID = dbo.SATISLAR.URUNID " +
                                            "inner join dbo.ADISYON on dbo.SATISLAR.ADISYONID = dbo.ADISYON.ID " +
                                            "where (CONVERT(datetime, TARIH, 104) BETWEEN CONVERT(datetime, @Baslangic, 104) AND CONVERT(datetime, @Bitis, 104)) AND (dbo.URUNLER.KATEGORIID=@katId) " +
                                            "group by dbo.URUNLER.URUNAD order by adeti desc", con);

            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunkatId;

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
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
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
    }
}
