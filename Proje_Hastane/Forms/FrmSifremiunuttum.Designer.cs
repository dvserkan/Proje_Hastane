
namespace Proje_Hastane.Forms
{
    partial class FrmSifremiunuttum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSifremiunuttum));
            this.TxtÖzelkods = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtYenisifre = new System.Windows.Forms.TextBox();
            this.Lblsifre = new System.Windows.Forms.Label();
            this.Txtözelkod = new System.Windows.Forms.Label();
            this.Txttctası = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtÖzelkods
            // 
            this.TxtÖzelkods.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.TxtÖzelkods.Location = new System.Drawing.Point(136, 51);
            this.TxtÖzelkods.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.TxtÖzelkods.Name = "TxtÖzelkods";
            this.TxtÖzelkods.Size = new System.Drawing.Size(136, 25);
            this.TxtÖzelkods.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Özel Kod:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(136, 131);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 30);
            this.button1.TabIndex = 22;
            this.button1.Text = "Şifre Değiştir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtYenisifre
            // 
            this.TxtYenisifre.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.TxtYenisifre.Location = new System.Drawing.Point(136, 88);
            this.TxtYenisifre.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.TxtYenisifre.Name = "TxtYenisifre";
            this.TxtYenisifre.Size = new System.Drawing.Size(136, 25);
            this.TxtYenisifre.TabIndex = 21;
            // 
            // Lblsifre
            // 
            this.Lblsifre.AutoSize = true;
            this.Lblsifre.Location = new System.Drawing.Point(28, 87);
            this.Lblsifre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lblsifre.Name = "Lblsifre";
            this.Lblsifre.Size = new System.Drawing.Size(96, 22);
            this.Lblsifre.TabIndex = 23;
            this.Lblsifre.Text = "Yeni Şifre:";
            // 
            // Txtözelkod
            // 
            this.Txtözelkod.AutoSize = true;
            this.Txtözelkod.Location = new System.Drawing.Point(13, 13);
            this.Txtözelkod.Name = "Txtözelkod";
            this.Txtözelkod.Size = new System.Drawing.Size(64, 22);
            this.Txtözelkod.TabIndex = 25;
            this.Txtözelkod.Text = "label2";
            this.Txtözelkod.Visible = false;
            // 
            // Txttctası
            // 
            this.Txttctası.AutoSize = true;
            this.Txttctası.Location = new System.Drawing.Point(88, 13);
            this.Txttctası.Name = "Txttctası";
            this.Txttctası.Size = new System.Drawing.Size(64, 22);
            this.Txttctası.TabIndex = 26;
            this.Txttctası.Text = "label2";
            this.Txttctası.Visible = false;
            // 
            // FrmSifremiunuttum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(314, 186);
            this.Controls.Add(this.Txttctası);
            this.Controls.Add(this.Txtözelkod);
            this.Controls.Add(this.TxtÖzelkods);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtYenisifre);
            this.Controls.Add(this.Lblsifre);
            this.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "FrmSifremiunuttum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ŞİFRE GÜNCELLE";
            this.Load += new System.EventHandler(this.FrmSifremiunuttum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtÖzelkods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtYenisifre;
        private System.Windows.Forms.Label Lblsifre;
        public System.Windows.Forms.Label Txtözelkod;
        public System.Windows.Forms.Label Txttctası;
    }
}