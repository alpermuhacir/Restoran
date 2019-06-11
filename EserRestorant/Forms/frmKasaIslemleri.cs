using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;

namespace EserRestorant
{
    public partial class frmKasaIslemleri : Form
    {
        public frmKasaIslemleri()
        {
            InitializeComponent();
        }

        /*private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }*/

        /*private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Close();
            menu.Show();
        }*/

        private void frmKasaIslemleri_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dataSet12.DataTable2' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.dataTable2TableAdapter.Fill(this.dataSet12.DataTable2);
            // TODO: Bu kod satırı 'dataSet11.DataTable1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.dataTable1TableAdapter1.Fill(this.dataSet11.DataTable1);
            // TODO: Bu kod satırı 'dataSet11.DataTable1' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.dataTable1TableAdapter1.Fill(this.dataSet11.DataTable1);
            

            this.rpvAylik.RefreshReport();
            this.rpvGunluk.RefreshReport();
            rpvGunluk.Visible = false;
            lblAylikRapor.Text = "AYLIK RAPOR";
            this.rpvAylik.RefreshReport();
            this.rpvGunluk.RefreshReport();
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click_1(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Close();
            menu.Show();
        }

        private void btnAylikR_Click(object sender, EventArgs e)
        {
            lblAylikRapor.Text = "AYLIK RAPOR";
            rpvAylik.Visible = true;
            rpvGunluk.Visible = false;
        }

        private void btnZR_Click(object sender, EventArgs e)
        {
            lblAylikRapor.Text = "GÜNLÜK RAPOR";
            rpvAylik.Visible = false;
            rpvGunluk.Visible = true;
        }

       /* private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataTable2TableAdapter1.FillBy(this.dataSet11.DataTable2);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/

        /*private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataTable1TableAdapter1.FillBy2(this.dataSet11.DataTable1);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/
    }
}
