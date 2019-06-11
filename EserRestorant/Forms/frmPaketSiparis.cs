using System;
using System.Collections;
using System.Windows.Forms;

namespace EserRestorant
{
    public partial class frmPaketSiparis : Form
    {
        public frmPaketSiparis()
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

        //Hesap İşlemleri
        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;



                default:
                    MessageBox.Show("Sayi Girin.");
                    break;
            }
        }

        int tableId; int AdditionId;
        private void frmPaketSiparis_Load(object sender, EventArgs e)
        {
            lblMasaNo.Text = clsGenel._ButtonValue;

            clsMasalar ms = new clsMasalar();
            tableId = ms.TableGetByNumber(clsGenel._ButtonName);
            if (ms.TableGetByState(tableId, 2) == true || ms.TableGetByState(tableId, 4) == true)
            {
                clsAdisyon Ad = new clsAdisyon();
                AdditionId = Ad.getByAddition(tableId);

                clsSiparis orders = new clsSiparis();
                orders.getByOrder(lvSiparisler, AdditionId);
            }


            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
        }

        clsUrunCesitleri Uc = new clsUrunCesitleri();

        #region UrunCesitleri
        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnAnaYemek1);
        }

        private void btnIcecekler2_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnIcecekler2);
        }

        private void btnTatlilar3_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnTatlilar3);
        }

        private void btnSalata4_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnSalata4);
        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnFastFood5);
        }

        private void btnCorba6_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnCorba6);
        }

        private void btnMakarna7_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnMakarna7);
        }

        private void btnAraSicak8_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnAraSicak8);
        }
        #endregion

        int sayac = 0; int sayac2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }

            if (lvMenu.Items.Count > 0)
            {
                sayac = lvSiparisler.Items.Count;
                //sayac = lvMenu.Items.Count;

                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);

                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal
                    (lvMenu.SelectedItems[0].SubItems[1].Text) *
                    Convert.ToDecimal(txtAdet.Text)).ToString());

                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());

                lvYeniEklenenler.Items.Add(AdditionId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(tableId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;

                txtAdet.Text = "";
            }
        }

        ArrayList silinenler = new ArrayList();
        private void btnSiparis_Click(object sender, EventArgs e)
        {
            /*
             1-Masa Boş
             2-Masa Dolu
             3-Masa Rezerve
             4-Dolu Rezerve
             */

            clsMasalar masa = new clsMasalar();
            Masa ms = new Masa();//form
            clsAdisyon newAddition = new clsAdisyon();
            clsSiparis saveOrder = new clsSiparis();

            bool sonuc = false;

            if (masa.TableGetByState(tableId, 1) == true)
            {
                newAddition.ServisTurNo = 1;
                //clsGenel._ServisTurNo = 1;//btnOdeme_Click de kullandık
                newAddition.PersonelId = 1;
                newAddition.MasaId = tableId;
                newAddition.Tarih = DateTime.Now;

                sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(clsGenel._ButtonName, 2);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.MasaId = tableId;
                        saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }

                    this.Close();
                    ms.Show();
                }
                else if (masa.TableGetByState(tableId, 2) == true || masa.TableGetByState(tableId, 4) == true)
                {
                    //clsGenel._ServisTurNo = 1;//btnOdeme_Click de kullandık
                    if (lvYeniEklenenler.Items.Count > 0)
                    {
                        for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                        {
                            saveOrder.MasaId = tableId;
                            saveOrder.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                            saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                            saveOrder.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                            saveOrder.setSaveOrder(saveOrder);
                        }
                        //clsGenel._AdisyonId = Convert.ToString(newAddition.getByAddition(tableId));
                    }

                    if (silinenler.Count > 0)
                    {
                        foreach (string item in silinenler)
                        {
                            saveOrder.setDeleteOrder(Convert.ToInt32(item));
                        }
                    }
                    this.Close();
                    ms.Show();
                }
                else if (masa.TableGetByState(tableId, 3) == true)
                {
                    //clsGenel._ServisTurNo = 1;//btnOdeme_Click de kullandık
                    newAddition.ServisTurNo = 1;
                    newAddition.PersonelId = 1;
                    newAddition.MasaId = tableId;
                    newAddition.Tarih = DateTime.Now;

                    sonuc = newAddition.setByAdditionNew(newAddition);
                    masa.setChangeTableState(clsGenel._ButtonName, 4);

                    if (lvSiparisler.Items.Count > 0)
                    {
                        for (int i = 0; i < lvSiparisler.Items.Count; i++)
                        {
                            saveOrder.MasaId = tableId;
                            saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                            saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                            saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                            saveOrder.setSaveOrder(saveOrder);
                        }

                        this.Close();
                        ms.Show();
                    }
                }
            }
        }

        private void lvSiparisler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSiparisler.Items.Count > 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    clsSiparis saveOrder = new clsSiparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[4].Text));
                }
            }
            else
            {
                for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                {
                    if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                    {
                        lvYeniEklenenler.Items.RemoveAt(i);
                    }
                }
            }

            lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (txtAra.Text == "")
            {
                txtAra.Text = "";
            }
            else
            {
                clsUrunCesitleri cu = new clsUrunCesitleri();
                cu.getByProductSearch(lvMenu, Convert.ToInt32(txtAra.Text));
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            clsGenel._ServisTurNo = 1;
            clsGenel._AdisyonId = AdditionId.ToString();
            frmBill frm = new frmBill();
            this.Close();
            frm.Show();
        }

        private void lvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
