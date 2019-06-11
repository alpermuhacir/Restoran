using System;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class frmGiris : Form
    {


        public frmGiris()
        {
            InitializeComponent();
        }

        // 
        private void frmGiris_Load(object sender, EventArgs e)
        {
            clsPersoneller p = new clsPersoneller();
            p.personelGetbyInformation(cmbKullaniciAdi);
        }

        //
        private void btnGiris_Click(object sender, EventArgs e)
        {
            clsGenel gnl = new clsGenel();
            clsPersoneller p = new clsPersoneller();
            bool result = p.personelEntryControl(txtSifre.Text, clsGenel._PersonelID);

            if (result)
            {
                clsPersonelHareketleri ch = new clsPersonelHareketleri();
                ch.PersonelID = clsGenel._PersonelID;
                ch.Islem = "Personel Giriş Yaptı";
                ch.Tarih = DateTime.Now;
                ch.PersonelActionSave(ch);

                this.Hide();
                frmMenu menu = new frmMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //Check our combobox when start the form.
        private void cmbKullaniciAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPersoneller p = (clsPersoneller)cmbKullaniciAdi.SelectedItem;
            clsGenel._PersonelID = p.PersonelID;
            clsGenel._GorevID = p.PersonelGorevID;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}