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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnkucult
            // 
            this.btnkucult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkucult.Location = new System.Drawing.Point(12, 233);
            this.btnkucult.Name = "btnkucult";
            this.btnkucult.Size = new System.Drawing.Size(398, 35);
            this.btnkucult.TabIndex = 0;
            this.btnkucult.Text = "Başlat";
            this.btnkucult.UseVisualStyleBackColor = true;
            this.btnkucult.Click += new System.EventHandler(this.btnkucult_Click);
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(13, 273);
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
            this.panel1.Size = new System.Drawing.Size(398, 213);
            this.panel1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 339);
            this.Controls.Add(this.txtList);
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
    }
}

