using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class MusteriEkleme : Form
    {
        public MusteriEkleme()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin ad ve soyad alanlarını doldurunuz.");
                }
                else
                {
                    clsMusteriler c = new clsMusteriler();
                    bool sonuc = c.MusteriVarmi(txtTelefon.Text);
                    if (!sonuc)
                    {
                        c.Musteriad = txtMusteriAd.Text;
                        c.Musterisoyad = txtMusteriSoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Email = txtEmail.Text;
                        c.Adres = txtAdres.Text;
                        txtMusteriNo.Text = c.musteriEkle(c).ToString();
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Eklendi!");
                        }
                        else
                        {
                            MessageBox.Show("Müşüteri Eklenemedi!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir kayıt zaten mevcut!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon no giriniz.");
            }
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

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMusteriAra m = new frmMusteriAra();
            this.Close();
            m.Show();
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (clsGenel._musteriEkleme == 0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                clsGenel._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if (clsGenel._musteriEkleme == 1)
            {
                frmSiparis paketSiparis = new frmSiparis();
                clsGenel._musteriEkleme = 0;
                this.Close();
                paketSiparis.Show();
            }
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin ad ve soyad alanlarını doldurunuz.");
                }
                else
                {
                    clsMusteriler c = new clsMusteriler();
                    
                    c.Musteriad = txtMusteriAd.Text;
                    c.Musterisoyad = txtMusteriSoyad.Text;
                    c.Telefon = txtTelefon.Text;
                    c.Email = txtEmail.Text;
                    c.Adres = txtAdres.Text;
                    c.Musteriid = Convert.ToInt32(txtMusteriNo.Text);

                    bool sonuc = c.musteriBilgileriGuncelle(c);

                    if (sonuc)//!
                    {
                        
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Bilgileri Güncellendi!");
                        }
                        else
                        {
                            MessageBox.Show("Müşüteri Bilgileri Güncellenemedi!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir kayıt zaten mevcut!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon no giriniz.");
            }
        }

        private void MusteriEkleme_Load(object sender, EventArgs e)
        {
            if (clsGenel._musteriId > 0)
            {
                clsMusteriler c = new clsMusteriler();
                txtMusteriNo.Text = clsGenel._musteriId.ToString();
                c.musterilerigetirID(Convert.ToInt32(txtMusteriNo.Text), txtMusteriAd, txtMusteriSoyad,
                    txtTelefon, txtAdres, txtEmail);
            }
        }
    }
}
