using System;
using System.Drawing;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class frmSiparisKontrol : Form
    {
        public frmSiparisKontrol()
        {
            InitializeComponent();
        }

        private void frmSiparisKontrol_Load(object sender, EventArgs e)
        {
            clsAdisyon c = new clsAdisyon();
            int butonSayisi = c.paketAdisyonIdbulAdedi();
            c.acikPaketAdisyonlar(lvMusteriler);
            int alt = 50;
            int sol = 1;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi)));

            for (int i = 1; i <= butonSayisi; i++)
            {
                Button btn = new Button();

                btn.AutoSize = false;
                btn.Size = new Size(179, 80);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;//[i]
                btn.Text = lvMusteriler.Items[i - 1].SubItems[1].Text;//[i]
                btn.Font = new Font(btn.Font.FontFamily.Name, 18);
                btn.Location = new Point(sol, alt);
                this.Controls.Add(btn);

                sol += btn.Width + 5;

                if (i == 2)
                {
                    sol = 1;
                    alt += 50;
                }
                btn.Click += new EventHandler(dinamikMetod);
                btn.MouseEnter += new EventHandler(dinamikMetod2);
            }
        }

        protected void dinamikMetod(object sender, EventArgs e)
        {
            clsAdisyon c = new clsAdisyon();
            Button dinamikButon = (sender as Button);
            frmBill frm = new frmBill();
            clsGenel._ServisTurNo = 2;
            clsGenel._AdisyonId = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikButon.Name)));

            frm.Show();
        } //kontrol edildi...

        protected void dinamikMetod2(object sender, EventArgs e)
        {
            Button dinamikButon = (sender as Button);
            clsAdisyon c = new clsAdisyon();
            c.musteriDetaylar(lvMusteriDetaylari, Convert.ToInt32(dinamikButon.Name));
            sonSiparisTarihi();
            lvSatisDetaylari.Items.Clear();

            clsSiparis s = new clsSiparis();

            clsGenel._ServisTurNo = 2;
            clsGenel._AdisyonId = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikButon.Name)));
            lblGenelToplam.Text = s.GenelToplamBul(Convert.ToInt32(dinamikButon.Name)).ToString() + " TL";
        } //kontrol edildi...

        void sonSiparisTarihi()
        {
            if (lvMusteriDetaylari.Items.Count > 0)
            {
                int s = lvMusteriDetaylari.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetaylari.Items[s - 1].SubItems[3].Text;
                txtToplamTutar.Text = s + "Adet";
            }
        } // kontrol edildi...

        void toplam()
        {
            int kayitSayisi = lvSatisDetaylari.Items.Count;
            decimal toplam = 0;

            for (int i = 0; i < kayitSayisi; i++)
            {
                toplam += Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[2].Text) *
                    Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[3].Text);

                /*toplam += Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[3].Text) *
                          Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[3].Text);*/
            }

            lblToplamSiparis.Text = toplam.ToString() + " TL";
        } //kontrol edildi...

        private void lvMusteriDetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMusteriDetaylari.SelectedItems.Count > 0)
            {
                clsSiparis c = new clsSiparis();
                c.adisyonpaketsiparisDetaylari(lvSatisDetaylari, Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[4].Text));
                // c.adisyonpaketsiparisDetaylari(lvMusteriDetaylari, Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[4].Text));
                toplam();
                lblGenelToplam.Text =
                    c.GenelToplamBul(Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[0].Text)).ToString() +
                    " TL";
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
            frmMusteriAra frm = new frmMusteriAra();
            this.Close();
            frm.Show();
        }
    }
}
