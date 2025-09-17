namespace resimkucult
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnkucult = new System.Windows.Forms.Button();
            this.txtList = new System.Windows.Forms.TextBox();
            this.radioButton45Sag = new System.Windows.Forms.RadioButton();
            this.radioButton45Sol = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chckkucult = new System.Windows.Forms.RadioButton();
            this.chckPDF = new System.Windows.Forms.RadioButton();
            this.chckHeicJpg = new System.Windows.Forms.RadioButton();
            this.chckBmptoJpg = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBilgisayarAdi = new System.Windows.Forms.TextBox();
            this.txtPaylasimAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.btnAyarKaydet = new System.Windows.Forms.Button();
            this.chckDosyaMod = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnkucult
            // 
            this.btnkucult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkucult.Location = new System.Drawing.Point(12, 231);
            this.btnkucult.Name = "btnkucult";
            this.btnkucult.Size = new System.Drawing.Size(398, 37);
            this.btnkucult.TabIndex = 0;
            this.btnkucult.Text = "Başlat";
            this.btnkucult.UseVisualStyleBackColor = true;
            this.btnkucult.Click += new System.EventHandler(this.btnkucult_Click);
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(13, 274);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(398, 54);
            this.txtList.TabIndex = 1;
            this.txtList.Text = "Bazı taranan formlara çevirme işlemi ilk yapıldığında ard arda 2 defa yapmak gere" +
    "kir.";
            this.txtList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton45Sag
            // 
            this.radioButton45Sag.AutoSize = true;
            this.radioButton45Sag.Location = new System.Drawing.Point(30, 75);
            this.radioButton45Sag.Name = "radioButton45Sag";
            this.radioButton45Sag.Size = new System.Drawing.Size(128, 17);
            this.radioButton45Sag.TabIndex = 5;
            this.radioButton45Sag.TabStop = true;
            this.radioButton45Sag.Text = "45 derece Sağa Çevir";
            this.radioButton45Sag.UseVisualStyleBackColor = true;
            // 
            // radioButton45Sol
            // 
            this.radioButton45Sol.AutoSize = true;
            this.radioButton45Sol.Location = new System.Drawing.Point(30, 101);
            this.radioButton45Sol.Name = "radioButton45Sol";
            this.radioButton45Sol.Size = new System.Drawing.Size(126, 17);
            this.radioButton45Sol.TabIndex = 6;
            this.radioButton45Sol.TabStop = true;
            this.radioButton45Sol.Text = "45 Derece Sola Çevir";
            this.radioButton45Sol.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // chckkucult
            // 
            this.chckkucult.AutoSize = true;
            this.chckkucult.Location = new System.Drawing.Point(30, 26);
            this.chckkucult.Name = "chckkucult";
            this.chckkucult.Size = new System.Drawing.Size(87, 17);
            this.chckkucult.TabIndex = 11;
            this.chckkucult.TabStop = true;
            this.chckkucult.Text = "Resim Sıkıştır";
            this.chckkucult.UseVisualStyleBackColor = true;
            // 
            // chckPDF
            // 
            this.chckPDF.AutoSize = true;
            this.chckPDF.Location = new System.Drawing.Point(287, 26);
            this.chckPDF.Name = "chckPDF";
            this.chckPDF.Size = new System.Drawing.Size(84, 17);
            this.chckPDF.TabIndex = 12;
            this.chckPDF.TabStop = true;
            this.chckPDF.Text = "PDF => JPG";
            this.chckPDF.UseVisualStyleBackColor = true;
            // 
            // chckHeicJpg
            // 
            this.chckHeicJpg.AutoSize = true;
            this.chckHeicJpg.Location = new System.Drawing.Point(287, 100);
            this.chckHeicJpg.Name = "chckHeicJpg";
            this.chckHeicJpg.Size = new System.Drawing.Size(88, 17);
            this.chckHeicJpg.TabIndex = 13;
            this.chckHeicJpg.TabStop = true;
            this.chckHeicJpg.Text = "HEIC => JPG";
            this.chckHeicJpg.UseVisualStyleBackColor = true;
            // 
            // chckBmptoJpg
            // 
            this.chckBmptoJpg.AutoSize = true;
            this.chckBmptoJpg.Location = new System.Drawing.Point(287, 63);
            this.chckBmptoJpg.Name = "chckBmptoJpg";
            this.chckBmptoJpg.Size = new System.Drawing.Size(86, 17);
            this.chckBmptoJpg.TabIndex = 14;
            this.chckBmptoJpg.TabStop = true;
            this.chckBmptoJpg.Text = "BMP => JPG";
            this.chckBmptoJpg.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chckBmptoJpg);
            this.panel1.Controls.Add(this.chckkucult);
            this.panel1.Controls.Add(this.radioButton45Sol);
            this.panel1.Controls.Add(this.chckHeicJpg);
            this.panel1.Controls.Add(this.radioButton45Sag);
            this.panel1.Controls.Add(this.chckPDF);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 197);
            this.panel1.TabIndex = 15;
            // 
            // txtBilgisayarAdi
            // 
            this.txtBilgisayarAdi.Enabled = false;
            this.txtBilgisayarAdi.Location = new System.Drawing.Point(93, 339);
            this.txtBilgisayarAdi.Name = "txtBilgisayarAdi";
            this.txtBilgisayarAdi.Size = new System.Drawing.Size(124, 20);
            this.txtBilgisayarAdi.TabIndex = 16;
            // 
            // txtPaylasimAdi
            // 
            this.txtPaylasimAdi.Enabled = false;
            this.txtPaylasimAdi.Location = new System.Drawing.Point(93, 368);
            this.txtPaylasimAdi.Name = "txtPaylasimAdi";
            this.txtPaylasimAdi.Size = new System.Drawing.Size(124, 20);
            this.txtPaylasimAdi.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(21, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Bilgisayar Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(24, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Paylaşım Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(256, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Parola";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(229, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Kullanıcı Adı";
            // 
            // txtParola
            // 
            this.txtParola.Enabled = false;
            this.txtParola.Location = new System.Drawing.Point(298, 368);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(112, 20);
            this.txtParola.TabIndex = 21;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Enabled = false;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(298, 339);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(112, 20);
            this.txtKullaniciAdi.TabIndex = 20;
            // 
            // btnAyarKaydet
            // 
            this.btnAyarKaydet.Enabled = false;
            this.btnAyarKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarKaydet.Location = new System.Drawing.Point(13, 394);
            this.btnAyarKaydet.Name = "btnAyarKaydet";
            this.btnAyarKaydet.Size = new System.Drawing.Size(397, 27);
            this.btnAyarKaydet.TabIndex = 24;
            this.btnAyarKaydet.Text = "Kaydet";
            this.btnAyarKaydet.UseVisualStyleBackColor = true;
            this.btnAyarKaydet.Click += new System.EventHandler(this.btnAyarKaydet_Click);
            // 
            // chckDosyaMod
            // 
            this.chckDosyaMod.AutoSize = true;
            this.chckDosyaMod.Location = new System.Drawing.Point(170, 213);
            this.chckDosyaMod.Name = "chckDosyaMod";
            this.chckDosyaMod.Size = new System.Drawing.Size(86, 17);
            this.chckDosyaMod.TabIndex = 25;
            this.chckDosyaMod.Text = "Dosya Modu";
            this.chckDosyaMod.UseVisualStyleBackColor = true;
            this.chckDosyaMod.Click += new System.EventHandler(this.chckDosyaMod_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 427);
            this.Controls.Add(this.chckDosyaMod);
            this.Controls.Add(this.btnAyarKaydet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaylasimAdi);
            this.Controls.Add(this.txtBilgisayarAdi);
            this.Controls.Add(this.btnkucult);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medya İşlem ve Dönüştürücü";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnkucult;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.RadioButton radioButton45Sag;
        private System.Windows.Forms.RadioButton radioButton45Sol;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton chckkucult;
        private System.Windows.Forms.RadioButton chckPDF;
        private System.Windows.Forms.RadioButton chckHeicJpg;
        private System.Windows.Forms.RadioButton chckBmptoJpg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBilgisayarAdi;
        private System.Windows.Forms.TextBox txtPaylasimAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnAyarKaydet;
        private System.Windows.Forms.CheckBox chckDosyaMod;
    }
}

