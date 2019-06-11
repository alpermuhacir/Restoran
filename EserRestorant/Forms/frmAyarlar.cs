using System;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Close();
            menu.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            clsPersoneller cp = new clsPersoneller();
            clsPersonelGorev cpg = new clsPersonelGorev();

            string gorev = cpg.PersonelGorevTanim(clsGenel._GorevID);

            if (gorev == "Mudur")
            {
                cp.personelGetbyInformation(cbPersonel);
                cpg.PersonelGorevGetir(cbGorevi);
                cp.personelBilgileriniGetirLV(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnKaydet.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;

                lblBilgi.Text = "Mevki : Müdür / Yetki : Sınırsız / Kullanıcı : " +
                                cp.personelBilgiGetirIsim(clsGenel._PersonelID);
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                lblBilgi.Text = "Mevki : Müdür / Yetki : Sınırlı / Kullanıcı : " + cp.personelBilgiGetirIsim(clsGenel._PersonelID);
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text.Trim() != "" || txtYeniSifreTekrar.Text.Trim() != "")
            {
                if (txtYeniSifre.Text == txtYeniSifreTekrar.Text)
                {
                    if (txtUserId.Text != "")
                    {
                        clsPersoneller c = new clsPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(txtUserId.Text), txtYeniSifre.Text);

                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleştirilmiştir...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçin!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil!");
                }
            }
            else
            {
                MessageBox.Show("Şifreler Uyuşmamaktadır!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textSifre.Text.Trim() != "" || textYeniSifre.Text.Trim() != "")
            {
                if (textYeniSifre.Text == textSifre.Text)
                {
                    if (clsGenel._PersonelID.ToString() != "")
                    {
                        clsPersoneller c = new clsPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(clsGenel._PersonelID), textYeniSifre.Text);

                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleştirilmiştir...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçin!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil!");
                }
            }
            else
            {
                MessageBox.Show("Şifreler Uyuşmamaktadır!");
            }
        }

        private void cbGorevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPersonelGorev c = (clsPersonelGorev)cbGorevi.SelectedItem;
            txtGorevId2.Text = Convert.ToString(c.PersonelGorevId);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = false;
            btnKaydet.Enabled = true;
            btnBilgiDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;
        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPersoneller c = (clsPersoneller)cbPersonel.SelectedItem;
            txtPersonelID.Text = Convert.ToString(c.PersonelID);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Silmek İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    clsPersoneller c = new clsPersoneller();
                    bool sonuc = c.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));

                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarı İle Silinmiştir.");
                        c.personelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Silinirken Bir Hata İle Karşılaşıldı!");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Kayıt Seçiniz!");
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Trim() != "" & txtSoyad.Text.Trim() != "" & txtSifre.Text.Trim() != "" & txtSifreTekrar.Text.Trim() != "" & txtGorevId2.Text.Trim() != "")
            {
                if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length >= 4 || txtSifreTekrar.Text.Length >= 4))
                {
                    clsPersoneller c = new clsPersoneller();
                    c.PersonelAd = txtAd.Text.Trim();
                    c.PersonelSoyad = txtSoyad.Text.Trim();
                    c.PersonelParola = txtSifre.Text.Trim();
                    c.PersonelGorevID = Convert.ToInt32(txtGorevId2.Text);
                    bool sonuc = c.personelEkle(c);

                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarı İle Eklenmiştir.");
                        c.personelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Eklenirken Bir Hata Oluşmuştur.");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil!");
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");
            }
        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (txtAd.Text != "" || txtSoyad.Text != "" || txtSifre.Text != "" || txtSifreTekrar.Text != "" ||
                    txtGorevId2.Text != "")
                {
                    if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) &&
                        (txtSifre.Text.Length > 5 || txtYeniSifreTekrar.Text.Length > 5))
                    {
                        clsPersoneller c = new clsPersoneller();
                        c.PersonelAd = txtAd.Text.Trim();
                        c.PersonelSoyad = txtSoyad.Text.Trim();
                        c.PersonelParola = txtSifre.Text.Trim();
                        c.PersonelGorevID = Convert.ToInt32(txtGorevId2.Text);
                        bool sonuc = c.personelGuncelle(c, Convert.ToInt32(txtPersonelID.Text));

                        if (sonuc)
                        {
                            MessageBox.Show("Kayıt Başarı İle Eklenmiştir.");
                            c.personelBilgileriniGetirLV(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Eklenirken Bir Hata Oluşmuştur.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Aynı Değil!");
                    }
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız!");
                }
            }
            else
            {
                MessageBox.Show("Önce Bir Kayıt Seçin.");
            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                btnSil.Enabled = true;

                txtPersonelID.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                cbGorevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;

                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                btnSil.Enabled = false;
            }
        }
    }
}
