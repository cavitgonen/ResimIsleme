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
            this.SuspendLayout();
            // 
            // btnkucult
            // 
            this.btnkucult.Location = new System.Drawing.Point(13, 10);
            this.btnkucult.Name = "btnkucult";
            this.btnkucult.Size = new System.Drawing.Size(193, 35);
            this.btnkucult.TabIndex = 0;
            this.btnkucult.Text = "İşlem Başlat";
            this.btnkucult.UseVisualStyleBackColor = true;
            this.btnkucult.Click += new System.EventHandler(this.btnkucult_Click);
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(14, 167);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(192, 54);
            this.txtList.TabIndex = 1;
            this.txtList.Text = "Bazı taranan formlara çevirme işlemi ilk yapıldığında ard arda 2 defa yapmak gere" +
    "kir.";
            this.txtList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton45Sag
            // 
            this.radioButton45Sag.AutoSize = true;
            this.radioButton45Sag.Location = new System.Drawing.Point(29, 120);
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
            this.radioButton45Sol.Location = new System.Drawing.Point(29, 141);
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
            this.chckkucult.Location = new System.Drawing.Point(29, 51);
            this.chckkucult.Name = "chckkucult";
            this.chckkucult.Size = new System.Drawing.Size(55, 17);
            this.chckkucult.TabIndex = 11;
            this.chckkucult.TabStop = true;
            this.chckkucult.Text = "Küçült";
            this.chckkucult.UseVisualStyleBackColor = true;
            // 
            // chckPDF
            // 
            this.chckPDF.AutoSize = true;
            this.chckPDF.Location = new System.Drawing.Point(29, 74);
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
            this.chckHeicJpg.Location = new System.Drawing.Point(29, 97);
            this.chckHeicJpg.Name = "chckHeicJpg";
            this.chckHeicJpg.Size = new System.Drawing.Size(88, 17);
            this.chckHeicJpg.TabIndex = 13;
            this.chckHeicJpg.TabStop = true;
            this.chckHeicJpg.Text = "HEIC => JPG";
            this.chckHeicJpg.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 232);
            this.Controls.Add(this.chckHeicJpg);
            this.Controls.Add(this.chckPDF);
            this.Controls.Add(this.chckkucult);
            this.Controls.Add(this.radioButton45Sol);
            this.Controls.Add(this.radioButton45Sag);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.btnkucult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resim İşlem";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

