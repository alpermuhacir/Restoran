using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EserRestorant.Class;

namespace EserRestorant
{
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
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

        private void btnAnaYemek_Click(object sender, EventArgs e)
        {
            Istatistik("Ana Yemekler Grafiği", 1, Color.Red);
        }

        private void btnIcecekler_Click(object sender, EventArgs e)
        {
            Istatistik("İçecekler Grafiği", 2, Color.Orange);
        }

        private void Istatistik(string gfName,int KatId, Color renk)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = renk;
            clsUrunler u = new clsUrunler();
            lvIstatistik.Items.Clear();
            u.urunleriListeleIstatistiklereGoreUrunId(lvIstatistik, dtBaslangic, dtBitis, KatId);
            gbIstatistik.Text = gfName;

            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text,
                        lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterecek Herhangi Bir İstatistik Bulunamadı. Başka Bir Tarih Aralığı Seçin");
            }
        }

        private void btnTumUrunler_Click(object sender, EventArgs e)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = Color.GreenYellow;
            clsUrunler u = new clsUrunler();
            lvIstatistik.Items.Clear();
            u.urunleriListeleIstatistiklereGore(lvIstatistik, dtBaslangic, dtBitis);
            gbIstatistik.Text = "TÜM ÜRÜNLER";

            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text,
                        lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterecek Herhangi Bir İstatistik Bulunamadı. Başka Bir Tarih Aralığı Seçin");
            }
        }

        private void btnTatlilar_Click(object sender, EventArgs e)
        {
            Istatistik("Tatlılar Grafiği", 3, Color.Blue);
        }

        private void btnSalata_Click(object sender, EventArgs e)
        {
            Istatistik("Salatalar Grafiği", 4, Color.Green);
        }

        private void btnFastFood_Click(object sender, EventArgs e)
        {
            Istatistik("FastFood Grafiği", 5, Color.DarkBlue);
        }

        private void btnCorba_Click(object sender, EventArgs e)
        {
            Istatistik("Çorbalar Grafiği", 6, Color.GreenYellow);
        }

        private void btnMakarna_Click(object sender, EventArgs e)
        {
            Istatistik("Makarnalar Grafiği", 7, Color.Purple);
        }

        private void btnAraSicak_Click(object sender, EventArgs e)
        {
            Istatistik("Ara Sıcaklar Grafiği", 8, Color.DarkGoldenrod);
        }
    }
}
