using System;
using System.Drawing;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class frmBill : Form
    {
        public frmBill()
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

        clsSiparis cs = new clsSiparis();
        int odemeTuru;

        private void frmBill_Load(object sender, EventArgs e)
        {
            gbIndirim.Visible = false;
            if (chkIndirim.Checked)
            {
                gbIndirim.Visible = false;
            }
            else
            {
                gbIndirim.Visible = true;
            }

            if (clsGenel._ServisTurNo == 1)
            {
                lblAdisyonId.Text = clsGenel._AdisyonId;
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));

                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }

                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);
                }

                if (chkIndirim.Checked)
                {
                    gbIndirim.Visible = false;
                }
                else
                {
                    gbIndirim.Visible = true;
                }
                txtIndirimTutari.Clear();
            }
            else if (clsGenel._ServisTurNo == 2)
            {
                lblAdisyonId.Text = clsGenel._AdisyonId;
                clsPaketler pc = new clsPaketler();

                odemeTuru = pc.OdemeTurIdGetir(Convert.ToInt32(lblAdisyonId.Text));

                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));

                if (odemeTuru == 1)
                {
                    rbNakit.Checked = true;
                }
                else if (odemeTuru == 2)
                {
                    rbKrediKarti.Checked = true;
                }
                else if (odemeTuru == 3)
                {
                    rbTicket.Checked = true;
                }

                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 1; i <= lvUrunler.Items.Count; i++) //for(int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);//sorun görüldü.
                    }
                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);
                }

                if (chkIndirim.Checked)
                {
                    gbIndirim.Visible = false;
                }
                else
                {
                    gbIndirim.Visible = true;
                }

                txtIndirimTutari.Clear();
            }
        }

        private void txtIndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtIndirimTutari/*lblIndirim*/.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {
                    try
                    {
                        lblIndirim.Text = string.Format("{0:0.000}", Convert.ToDecimal(txtIndirimTutari.Text));
                    }
                    catch (Exception)
                    {
                        lblIndirim.Text = string.Format("{0:0.000}", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim Tutarı Toplam Tutardan Fazla Olamaz !!!");
                }
            }
            catch (Exception)
            {
                lblIndirim.Text = string.Format("{0:0.000}", 0);
            }

        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndirim.Checked)
            {
                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else
            {
                gbIndirim.Visible = false;
                txtIndirimTutari.Clear();
            }
        }

        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text) > 0)
            {
                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(lblIndirim.Text/*txtIndirimTutari.Text*/);
                lblOdenecek.Text = string.Format("{0:0.000}", odenecek);
            }

            decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
            lblKdv.Text = string.Format("{0:0.000}", kdv);
        }

        clsMasalar masalar = new clsMasalar();
        clsRezervasyon rezerve = new clsRezervasyon();

        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            if (clsGenel._ServisTurNo == 1)
            {
                int masaid = masalar.TableGetByNumber(clsGenel._ButtonName);
                int musteriId = 0;

                if (masalar.TableGetByState(masaid, 4) == true)
                {
                    musteriId = rezerve.getByClientIdFromRezervasyon(masaid);
                }
                else
                {
                    musteriId = 1;
                }

                int odemeTurId = 0;

                if (rbKrediKarti.Checked)
                {
                    odemeTurId = 2;
                }
                if (rbNakit.Checked)
                {
                    odemeTurId = 1;
                }
                if (rbTicket.Checked)
                {
                    odemeTurId = 3;
                }

                clsOdeme odeme = new clsOdeme();

                //ADISYONID,ODEMETURID,MUSTERIID,ARATOPLAM,KDVTUTARI,TOPLAMTUTAR,INDIRIM

                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTurId;
                odeme.MusteriId = musteriId;
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKdv.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);

                if (result)
                {
                    MessageBox.Show("Hesap Kapatılmıştır.");
                    masalar.setChangeTableState(Convert.ToString(masaid), 1);

                    clsRezervasyon c = new clsRezervasyon();
                    c.rezervationclose(Convert.ToInt32(lblAdisyonId.Text));

                    clsAdisyon a = new clsAdisyon();
                    a.adisyonkapat(Convert.ToInt32(lblAdisyonId.Text), 0);

                    this.Close();
                    Masa frm = new Masa();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap Kapatılırken Bir Hata Oluştu. Lütfen Yetkililere Bildiriniz.");
                }
            }//paket sipariş
            else if (clsGenel._ServisTurNo == 2)
            {
                clsOdeme odeme = new clsOdeme();

                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTuru;
                odeme.MusteriId = 1; //rezerve.getByClientIdFromRezervasyon(masaid); //paket sipariş ID
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKdv.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);

                if (result)
                {
                    MessageBox.Show("hesap kapatılmıştır...");

                    clsAdisyon a = new clsAdisyon();
                    a.adisyonkapat(Convert.ToInt32(lblAdisyonId.Text), 1);

                    clsPaketler p = new clsPaketler();
                    p.OrderServiceClose(Convert.ToInt32(lblAdisyonId.Text));



                    this.Close();
                    Masa frm = new Masa();//changing
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap Kapatılırken Bir Hata Oluştu...");
                }
            }
        }


        //hesap özeti fişi yazdırma
        #region Fiş Yazdırma
        private void btnHesapOzeti_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        //fiş bilgileri...
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("ESER RESTORANT", Baslik, sb, 350, 100, st);

            e.Graphics.DrawString("---------------------------", altBaslik, sb, 350, 120, st);
            e.Graphics.DrawString(" Ürün Adı                   Adet              Fiyat", altBaslik, sb, 150, 250, st);
            e.Graphics.DrawString("--------------------------------------------------------  ", altBaslik, sb, 150, 280, st);

            for (int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, icerik, sb, 150, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, icerik, sb, 350, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[3].Text, icerik, sb, 445, 300 + i * 30, st);
            }

            e.Graphics.DrawString("--------------------------------------------------------  ", altBaslik, sb, 150,
                300 + 30 * lvUrunler.Items.Count, st);
            e.Graphics.DrawString("İndirim Tutarı      :--------------- " + lblIndirim.Text + "  TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 1), st);
            e.Graphics.DrawString("KDV Tutarı           :--------------- " + lblKdv.Text + "  TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutar       :--------------- " + lblToplamTutar.Text + "  TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutar  :--------------- " + lblOdenecek.Text + "  TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 4), st);
            // printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[10];
        }
        #endregion
    }
}
