using System;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        #region OpenClose
        private void btnMasaSiparis_Click(object sender, EventArgs e)
        {
            Masa masa = new Masa();
            this.Close();
            masa.Show();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            frmRezervasyon rezervasyon = new frmRezervasyon();
            this.Close();
            rezervasyon.Show();
        }

        private void btnPaketServis_Click(object sender, EventArgs e)
        {
            frmPaketSiparis paketsiparis = new frmPaketSiparis();
            this.Close();
            paketsiparis.Show();
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            frmMusteriAra musteriler = new frmMusteriAra();
            this.Close();
            musteriler.Show();
        }

        private void btnKasaIslemleri_Click(object sender, EventArgs e)
        {
            frmKasaIslemleri kasaIslem = new frmKasaIslemleri();
            this.Close();
            kasaIslem.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            frmMutfak mutfak = new frmMutfak();
            this.Close();
            mutfak.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            frmRaporlar raporlar = new frmRaporlar();
            this.Close();
            raporlar.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmAyarlar ayarlar = new frmAyarlar();
            this.Close();
            ayarlar.Show();
        }

        private void btnKilit_Click(object sender, EventArgs e)
        {
            frmKilit kilit = new frmKilit();
            this.Close();
            kilit.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion
    }
}
