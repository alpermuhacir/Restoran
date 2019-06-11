using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace EserRestorant
{
    public partial class frmMusteriAra : Form
    {
        public frmMusteriAra()
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
        
        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme m = new MusteriEkleme();
            clsGenel._musteriEkleme = 1;

            m.btnMusteriGuncelle.Visible = false;
            m.btnEkle.Visible = true;

            m.Show();
        }

        private void frmMusteriAra_Load(object sender, EventArgs e)
        {
            clsMusteriler c = new clsMusteriler();
            c.musterileriGetir(lvMusteriler);
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            /*if (clsGenel._musteriEkleme == 0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                clsGenel._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if(clsGenel._musteriEkleme == 1)
            {
                frmSiparis frm = new frmSiparis();
                clsGenel._musteriEkleme = 0;
                this.Close();
                frm.Show();
            }*/
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                MusteriEkleme frm = new MusteriEkleme();
                clsGenel._musteriEkleme = 1;
                clsGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);

                frm.btnEkle.Visible = false;
                frm.btnMusteriGuncelle.Visible = true;

                this.Close();
                frm.Show();
            }
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            clsMusteriler c = new clsMusteriler();
            c.MusteriGetirAd(lvMusteriler, txtMusteriAd.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            clsMusteriler c = new clsMusteriler();
            c.musterigetirSoyad(lvMusteriler, txtSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            clsMusteriler c = new clsMusteriler();
            c.musterigetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if (txtAdisyonId.Text != "")
            {
                clsGenel._AdisyonId = Convert.ToString(txtAdisyonId.Text);
                clsPaketler c = new clsPaketler();

                bool sonuc = c.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonId.Text));

                if (sonuc)
                {
                    frmBill frm = new frmBill();
                    clsGenel._ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdisyonId.Text + "Böyle Bir Adisyon Bulunamadı!");
                }
            }
            else
            {
                MessageBox.Show("Aramak istediğiniz adisyonu yazınız.");
            }
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol frm = new frmSiparisKontrol();
            this.Close();
            frm.Show();
        }
    }
}
