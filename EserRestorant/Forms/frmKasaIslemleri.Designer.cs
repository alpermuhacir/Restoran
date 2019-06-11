namespace EserRestorant
{
    partial class frmKasaIslemleri
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet11BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet11 = new EserRestorant.DataSet1();
            this.dataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet12 = new EserRestorant.DataSet1();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnAylikR = new System.Windows.Forms.Button();
            this.btnZR = new System.Windows.Forms.Button();
            this.lblAylikRapor = new System.Windows.Forms.Label();
            this.rpvAylik = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTable1TableAdapter1 = new EserRestorant.DataSet1TableAdapters.DataTable1TableAdapter();
            this.rpvGunluk = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTable1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable2TableAdapter = new EserRestorant.DataSet1TableAdapters.DataTable2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.dataSet11BindingSource;
            // 
            // dataSet11BindingSource
            // 
            this.dataSet11BindingSource.DataSource = this.dataSet11;
            this.dataSet11BindingSource.Position = 0;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable2BindingSource
            // 
            this.dataTable2BindingSource.DataMember = "DataTable2";
            this.dataTable2BindingSource.DataSource = this.dataSet12;
            // 
            // dataSet12
            // 
            this.dataSet12.DataSetName = "DataSet1";
            this.dataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Location = new System.Drawing.Point(84, 417);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(61, 65);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click_1);
            // 
            // btnGeri
            // 
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeri.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGeri.Location = new System.Drawing.Point(12, 417);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(66, 65);
            this.btnGeri.TabIndex = 7;
            this.btnGeri.Text = "GERİ";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click_1);
            // 
            // btnAylikR
            // 
            this.btnAylikR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAylikR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAylikR.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAylikR.Location = new System.Drawing.Point(12, 140);
            this.btnAylikR.Name = "btnAylikR";
            this.btnAylikR.Size = new System.Drawing.Size(183, 95);
            this.btnAylikR.TabIndex = 8;
            this.btnAylikR.Text = "Aylık Rapor";
            this.btnAylikR.UseVisualStyleBackColor = true;
            this.btnAylikR.Click += new System.EventHandler(this.btnAylikR_Click);
            // 
            // btnZR
            // 
            this.btnZR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZR.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnZR.Location = new System.Drawing.Point(12, 261);
            this.btnZR.Name = "btnZR";
            this.btnZR.Size = new System.Drawing.Size(183, 95);
            this.btnZR.TabIndex = 9;
            this.btnZR.Text = "Z Raporu";
            this.btnZR.UseVisualStyleBackColor = true;
            this.btnZR.Click += new System.EventHandler(this.btnZR_Click);
            // 
            // lblAylikRapor
            // 
            this.lblAylikRapor.AutoSize = true;
            this.lblAylikRapor.BackColor = System.Drawing.Color.Transparent;
            this.lblAylikRapor.Font = new System.Drawing.Font("MS Outlook", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAylikRapor.Location = new System.Drawing.Point(491, 20);
            this.lblAylikRapor.Name = "lblAylikRapor";
            this.lblAylikRapor.Size = new System.Drawing.Size(141, 24);
            this.lblAylikRapor.TabIndex = 11;
            this.lblAylikRapor.Text = "AYLIK RAPOR";
            // 
            // rpvAylik
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTable1BindingSource;
            this.rpvAylik.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAylik.LocalReport.ReportEmbeddedResource = "EserRestorant.Report1.rdlc";
            this.rpvAylik.Location = new System.Drawing.Point(214, 66);
            this.rpvAylik.Name = "rpvAylik";
            this.rpvAylik.ServerReport.BearerToken = null;
            this.rpvAylik.Size = new System.Drawing.Size(768, 416);
            this.rpvAylik.TabIndex = 12;
            // 
            // dataTable1TableAdapter1
            // 
            this.dataTable1TableAdapter1.ClearBeforeFill = true;
            // 
            // rpvGunluk
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.dataTable2BindingSource;
            this.rpvGunluk.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvGunluk.LocalReport.ReportEmbeddedResource = "EserRestorant.Gunluk.rdlc";
            this.rpvGunluk.Location = new System.Drawing.Point(214, 66);
            this.rpvGunluk.Name = "rpvGunluk";
            this.rpvGunluk.ServerReport.BearerToken = null;
            this.rpvGunluk.Size = new System.Drawing.Size(768, 416);
            this.rpvGunluk.TabIndex = 13;
            // 
            // dataTable1BindingSource1
            // 
            this.dataTable1BindingSource1.DataMember = "DataTable1";
            this.dataTable1BindingSource1.DataSource = this.dataSet11BindingSource;
            // 
            // dataTable2TableAdapter
            // 
            this.dataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // frmKasaIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(994, 502);
            this.Controls.Add(this.rpvGunluk);
            this.Controls.Add(this.rpvAylik);
            this.Controls.Add(this.lblAylikRapor);
            this.Controls.Add(this.btnZR);
            this.Controls.Add(this.btnAylikR);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKasaIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKasaIslemleri";
            this.Load += new System.EventHandler(this.frmKasaIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnAylikR;
        private System.Windows.Forms.Button btnZR;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Label lblAylikRapor;
        //private DataSet1TableAdapters.DataTable2TableAdapter DataTable2TableAdapter;
        private System.Windows.Forms.BindingSource dataSet11BindingSource;
        private DataSet1 dataSet11;
        private Microsoft.Reporting.WinForms.ReportViewer rpvAylik;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private DataSet1TableAdapters.DataTable1TableAdapter dataTable1TableAdapter1;
        private Microsoft.Reporting.WinForms.ReportViewer rpvGunluk;
        private System.Windows.Forms.BindingSource dataTable1BindingSource1;
        private DataSet1 dataSet12;
        private System.Windows.Forms.BindingSource dataTable2BindingSource;
        private DataSet1TableAdapters.DataTable2TableAdapter dataTable2TableAdapter;
    }
}