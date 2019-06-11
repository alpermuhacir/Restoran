namespace EserRestorant
{
    partial class frmRaporlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRaporlar));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.grpMenuBaslik = new System.Windows.Forms.GroupBox();
            this.btnAraSicak = new System.Windows.Forms.Button();
            this.btnAnaYemek = new System.Windows.Forms.Button();
            this.btnCorba = new System.Windows.Forms.Button();
            this.btnTatlilar = new System.Windows.Forms.Button();
            this.btnSalata = new System.Windows.Forms.Button();
            this.btnFastFood = new System.Windows.Forms.Button();
            this.btnIcecekler = new System.Windows.Forms.Button();
            this.btnMakarna = new System.Windows.Forms.Button();
            this.gbIstatistik = new System.Windows.Forms.GroupBox();
            this.lvIstatistik = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adedi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRapor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnTumUrunler = new System.Windows.Forms.Button();
            this.grpMenuBaslik.SuspendLayout();
            this.gbIstatistik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(287, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç Tarihi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(344, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bitiş Tarihi :";
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.CalendarFont = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBaslangic.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtBaslangic.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dtBaslangic.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dtBaslangic.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dtBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBaslangic.Location = new System.Drawing.Point(489, 12);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(339, 29);
            this.dtBaslangic.TabIndex = 1;
            // 
            // dtBitis
            // 
            this.dtBitis.CalendarFont = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBitis.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtBitis.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dtBitis.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dtBitis.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dtBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBitis.Location = new System.Drawing.Point(489, 54);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(339, 29);
            this.dtBitis.TabIndex = 1;
            // 
            // grpMenuBaslik
            // 
            this.grpMenuBaslik.BackColor = System.Drawing.Color.Transparent;
            this.grpMenuBaslik.Controls.Add(this.btnAraSicak);
            this.grpMenuBaslik.Controls.Add(this.btnAnaYemek);
            this.grpMenuBaslik.Controls.Add(this.btnCorba);
            this.grpMenuBaslik.Controls.Add(this.btnTatlilar);
            this.grpMenuBaslik.Controls.Add(this.btnSalata);
            this.grpMenuBaslik.Controls.Add(this.btnFastFood);
            this.grpMenuBaslik.Controls.Add(this.btnIcecekler);
            this.grpMenuBaslik.Controls.Add(this.btnMakarna);
            this.grpMenuBaslik.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpMenuBaslik.Location = new System.Drawing.Point(12, 62);
            this.grpMenuBaslik.Name = "grpMenuBaslik";
            this.grpMenuBaslik.Size = new System.Drawing.Size(247, 370);
            this.grpMenuBaslik.TabIndex = 2;
            this.grpMenuBaslik.TabStop = false;
            this.grpMenuBaslik.Text = "Menü";
            // 
            // btnAraSicak
            // 
            this.btnAraSicak.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAraSicak.BackgroundImage")));
            this.btnAraSicak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAraSicak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAraSicak.Location = new System.Drawing.Point(124, 282);
            this.btnAraSicak.Name = "btnAraSicak";
            this.btnAraSicak.Size = new System.Drawing.Size(103, 73);
            this.btnAraSicak.TabIndex = 1;
            this.btnAraSicak.UseVisualStyleBackColor = true;
            this.btnAraSicak.Click += new System.EventHandler(this.btnAraSicak_Click);
            // 
            // btnAnaYemek
            // 
            this.btnAnaYemek.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnaYemek.BackgroundImage")));
            this.btnAnaYemek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnaYemek.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnaYemek.Location = new System.Drawing.Point(15, 45);
            this.btnAnaYemek.Name = "btnAnaYemek";
            this.btnAnaYemek.Size = new System.Drawing.Size(103, 73);
            this.btnAnaYemek.TabIndex = 8;
            this.btnAnaYemek.UseVisualStyleBackColor = true;
            this.btnAnaYemek.Click += new System.EventHandler(this.btnAnaYemek_Click);
            // 
            // btnCorba
            // 
            this.btnCorba.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCorba.BackgroundImage")));
            this.btnCorba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCorba.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCorba.Location = new System.Drawing.Point(124, 203);
            this.btnCorba.Name = "btnCorba";
            this.btnCorba.Size = new System.Drawing.Size(103, 73);
            this.btnCorba.TabIndex = 2;
            this.btnCorba.UseVisualStyleBackColor = true;
            this.btnCorba.Click += new System.EventHandler(this.btnCorba_Click);
            // 
            // btnTatlilar
            // 
            this.btnTatlilar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTatlilar.BackgroundImage")));
            this.btnTatlilar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTatlilar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTatlilar.Location = new System.Drawing.Point(15, 124);
            this.btnTatlilar.Name = "btnTatlilar";
            this.btnTatlilar.Size = new System.Drawing.Size(103, 73);
            this.btnTatlilar.TabIndex = 7;
            this.btnTatlilar.UseVisualStyleBackColor = true;
            this.btnTatlilar.Click += new System.EventHandler(this.btnTatlilar_Click);
            // 
            // btnSalata
            // 
            this.btnSalata.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalata.BackgroundImage")));
            this.btnSalata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalata.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalata.Location = new System.Drawing.Point(124, 124);
            this.btnSalata.Name = "btnSalata";
            this.btnSalata.Size = new System.Drawing.Size(103, 73);
            this.btnSalata.TabIndex = 3;
            this.btnSalata.UseVisualStyleBackColor = true;
            this.btnSalata.Click += new System.EventHandler(this.btnSalata_Click);
            // 
            // btnFastFood
            // 
            this.btnFastFood.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFastFood.BackgroundImage")));
            this.btnFastFood.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFastFood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFastFood.Location = new System.Drawing.Point(15, 203);
            this.btnFastFood.Name = "btnFastFood";
            this.btnFastFood.Size = new System.Drawing.Size(103, 73);
            this.btnFastFood.TabIndex = 6;
            this.btnFastFood.UseVisualStyleBackColor = true;
            this.btnFastFood.Click += new System.EventHandler(this.btnFastFood_Click);
            // 
            // btnIcecekler
            // 
            this.btnIcecekler.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIcecekler.BackgroundImage")));
            this.btnIcecekler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcecekler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIcecekler.Location = new System.Drawing.Point(124, 45);
            this.btnIcecekler.Name = "btnIcecekler";
            this.btnIcecekler.Size = new System.Drawing.Size(103, 73);
            this.btnIcecekler.TabIndex = 4;
            this.btnIcecekler.UseVisualStyleBackColor = true;
            this.btnIcecekler.Click += new System.EventHandler(this.btnIcecekler_Click);
            // 
            // btnMakarna
            // 
            this.btnMakarna.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMakarna.BackgroundImage")));
            this.btnMakarna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMakarna.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMakarna.Location = new System.Drawing.Point(15, 282);
            this.btnMakarna.Name = "btnMakarna";
            this.btnMakarna.Size = new System.Drawing.Size(103, 73);
            this.btnMakarna.TabIndex = 5;
            this.btnMakarna.UseVisualStyleBackColor = true;
            this.btnMakarna.Click += new System.EventHandler(this.btnMakarna_Click);
            // 
            // gbIstatistik
            // 
            this.gbIstatistik.BackColor = System.Drawing.Color.Transparent;
            this.gbIstatistik.Controls.Add(this.lvIstatistik);
            this.gbIstatistik.Controls.Add(this.chRapor);
            this.gbIstatistik.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbIstatistik.Location = new System.Drawing.Point(292, 107);
            this.gbIstatistik.Name = "gbIstatistik";
            this.gbIstatistik.Size = new System.Drawing.Size(681, 421);
            this.gbIstatistik.TabIndex = 2;
            this.gbIstatistik.TabStop = false;
            // 
            // lvIstatistik
            // 
            this.lvIstatistik.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.Adedi});
            this.lvIstatistik.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvIstatistik.Location = new System.Drawing.Point(640, 79);
            this.lvIstatistik.Name = "lvIstatistik";
            this.lvIstatistik.Size = new System.Drawing.Size(10, 10);
            this.lvIstatistik.TabIndex = 1;
            this.lvIstatistik.UseCompatibleStateImageBehavior = false;
            this.lvIstatistik.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Urun Adı";
            // 
            // chRapor
            // 
            this.chRapor.BackColor = System.Drawing.Color.Transparent;
            this.chRapor.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chRapor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chRapor.Legends.Add(legend1);
            this.chRapor.Location = new System.Drawing.Point(6, 32);
            this.chRapor.Name = "chRapor";
            this.chRapor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Label = "Satislar";
            series1.Legend = "Legend1";
            series1.Name = "Satislar";
            this.chRapor.Series.Add(series1);
            this.chRapor.Size = new System.Drawing.Size(669, 383);
            this.chRapor.TabIndex = 0;
            this.chRapor.Text = "chart1";
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Location = new System.Drawing.Point(84, 526);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(61, 65);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeri.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGeri.Location = new System.Drawing.Point(12, 526);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(66, 65);
            this.btnGeri.TabIndex = 4;
            this.btnGeri.Text = "GERİ";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnTumUrunler
            // 
            this.btnTumUrunler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTumUrunler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTumUrunler.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTumUrunler.Location = new System.Drawing.Point(84, 438);
            this.btnTumUrunler.Name = "btnTumUrunler";
            this.btnTumUrunler.Size = new System.Drawing.Size(183, 82);
            this.btnTumUrunler.TabIndex = 9;
            this.btnTumUrunler.Text = "Tüm Ürünler";
            this.btnTumUrunler.UseVisualStyleBackColor = true;
            this.btnTumUrunler.Click += new System.EventHandler(this.btnTumUrunler_Click);
            // 
            // frmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(996, 603);
            this.Controls.Add(this.btnTumUrunler);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.gbIstatistik);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.grpMenuBaslik);
            this.Controls.Add(this.dtBitis);
            this.Controls.Add(this.dtBaslangic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRaporlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRaporlar";
            this.grpMenuBaslik.ResumeLayout(false);
            this.gbIstatistik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.GroupBox grpMenuBaslik;
        private System.Windows.Forms.GroupBox gbIstatistik;
        private System.Windows.Forms.Button btnAraSicak;
        private System.Windows.Forms.Button btnAnaYemek;
        private System.Windows.Forms.Button btnCorba;
        private System.Windows.Forms.Button btnTatlilar;
        private System.Windows.Forms.Button btnSalata;
        private System.Windows.Forms.Button btnFastFood;
        private System.Windows.Forms.Button btnIcecekler;
        private System.Windows.Forms.Button btnMakarna;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.ListView lvIstatistik;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader Adedi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chRapor;
        private System.Windows.Forms.Button btnTumUrunler;
    }
}