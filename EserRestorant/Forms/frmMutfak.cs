using EserRestorant.Class;
using System;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class frmMutfak : Form
    {
        public frmMutfak()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Close();
            menu.Show();
        }

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            clsUrunCesitleri Anakategori = new clsUrunCesitleri();
            Anakategori.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;

            label4.Visible = false;
            txtArama.Visible = false;

            clsUrunler c = new clsUrunler();
            c.urunleriListele(lvGidaListesi);
        }

        private void Temizle()
        {
            txtGidaAdi.Clear();
            txtGidaFiyati.Clear();
            txtGidaFiyati.Text = string.Format("{0:##0.00}", 0);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyati.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı, Fiyatı ve Kategori Seçilmemiştir.", "Dikkat Bilgiler Eksik",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    clsUrunler c = new clsUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    c.Urunad = txtGidaAdi.Text;
                    c.Aciklama = "Ürün Eklendi";
                    c.Urunturno = urunturNo;
                    int sonuc = c.urunEkle(c);

                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Eklenmiştir");
                        //cbKategoriler_SelectedIndexChanged(sender, e);
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAd.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen Bir Kategori İsmi Girin.", "Dikkat Bilgiler Eksik",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    clsUrunCesitleri gida = new clsUrunCesitleri();
                    gida.KategoriAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                    int sonuc = gida.urunKategoriEkle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Eklenmiştir");
                        yenile();
                        Temizle();
                    }
                }
            }
        }

        private int urunturNo = 0;

        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsUrunler u = new clsUrunler();
            if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
            {
                u.urunleriListele(lvGidaListesi);
            }
            else
            {
                clsUrunCesitleri cesit = (clsUrunCesitleri)cbKategoriler.SelectedItem;
                urunturNo = cesit.UrunTurNo;
                u.urunleriListeleByUrunId(lvGidaListesi, urunturNo);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyati.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı, Fiyatı ve Kategori Seçilmemiştir.", "Dikkat Bilgiler Eksik",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    clsUrunler c = new clsUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    c.Urunad = txtGidaAdi.Text;
                    c.Urunid = Convert.ToInt32(txtUrunId.Text);
                    c.Urunturno = urunturNo;
                    c.Aciklama = "Ürün Güncellendi";
                    int sonuc = c.urunGuncelle(c);

                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Güncellenmiştir");
                        yenile();
                        //cbKategoriler_SelectedIndexChanged(sender, e);
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriId.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen Bir Kategori Seçiniz.", "Dikkat Bilgiler Eksik",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    clsUrunCesitleri gida = new clsUrunCesitleri();
                    gida.KategoriAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                    gida.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = gida.urunKategoriGuncelle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Güncellenmiştir");
                        gida.urunCesitleriniGetir(lvKategoriler);
                        Temizle();
                    }
                }
            }
        }

        private void lvGidaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGidaListesi.SelectedItems.Count > 0)
            {
                txtGidaAdi.Text = lvGidaListesi.SelectedItems[0].SubItems[3].Text;
                txtGidaFiyati.Text = lvGidaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunId.Text = lvGidaListesi.SelectedItems[0].SubItems[0].Text;
                //cbKategoriler.SelectedIndex = Convert.ToInt32 (txtUrunId.Text);
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
                txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtKategoriId.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                txtAciklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
                //cbKategoriler.SelectedIndex = Convert.ToInt32 (txtUrunId.Text);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (lvGidaListesi.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Ürünü silmek istediğinize emin misiniz.", "Dikkat Bilgiler Silinecek",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        clsUrunler c = new clsUrunler();
                        c.Urunid = Convert.ToInt32(txtUrunId.Text);
                        int sonuc = c.UrunSil(c, 1);

                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün Silinmiştir..");
                            cbKategoriler_SelectedIndexChanged(sender, e);
                            yenile();
                            Temizle();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ürünü silmek için bir ürün seçin.", "Dikkat Ürün Seçilmedi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (lvGidaListesi.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Ürünü silmek istediğinize emin misiniz.", "Dikkat Bilgiler Silinecek",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        clsUrunCesitleri uc = new clsUrunCesitleri();

                        int sonuc = uc.urunKategoriSil(Convert.ToInt32(txtKategoriId.Text));

                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün Silinmiştir..");
                            clsUrunler c = new clsUrunler();
                            c.Urunid = Convert.ToInt32(txtKategoriId.Text);
                            c.UrunSil(c, 0);
                            yenile();
                            Temizle();
                        }
                    }
                }
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            txtArama.Visible = true;
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                clsUrunler u = new clsUrunler();
                u.urunleriListeleByUrunAdi(lvGidaListesi, txtArama.Text);
            }
            else
            {
                clsUrunCesitleri uc = new clsUrunCesitleri();
                uc.urunCesitleriniGetir(lvKategoriler, txtArama.Text);
            }
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnakategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGidaListesi.Visible = true;
            yenile();
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = false;
            panelAnakategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGidaListesi.Visible = false;
            yenile();
            //clsUrunCesitleri uc = new clsUrunCesitleri();
            //uc.urunCesitleriniGetir(lvKategoriler);
        }

        private void yenile()
        {
            clsUrunCesitleri uc = new clsUrunCesitleri();
            uc.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            uc.urunCesitleriniGetir(lvKategoriler);

            clsUrunler c = new clsUrunler();
            c.urunleriListele(lvGidaListesi);

        }
    }
}
