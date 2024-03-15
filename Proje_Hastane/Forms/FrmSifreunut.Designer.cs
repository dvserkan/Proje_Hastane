
namespace Proje_Hastane
{
    partial class FrmSifreunut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSifreunut));
            this.BtnDegistir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Txtmail = new System.Windows.Forms.TextBox();
            this.Labels = new System.Windows.Forms.Label();
            this.MskTC = new System.Windows.Forms.MaskedTextBox();
            this.Lblözel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnDegistir
            // 
            this.BtnDegistir.BackColor = System.Drawing.Color.White;
            this.BtnDegistir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDegistir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnDegistir.Location = new System.Drawing.Point(104, 92);
            this.BtnDegistir.Name = "BtnDegistir";
            this.BtnDegistir.Size = new System.Drawing.Size(160, 33);
            this.BtnDegistir.TabIndex = 3;
            this.BtnDegistir.Text = "Mail Gönder";
            this.BtnDegistir.UseVisualStyleBackColor = false;
            this.BtnDegistir.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mail:";
            // 
            // Txtmail
            // 
            this.Txtmail.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtmail.Location = new System.Drawing.Point(104, 61);
            this.Txtmail.Name = "Txtmail";
            this.Txtmail.Size = new System.Drawing.Size(224, 25);
            this.Txtmail.TabIndex = 2;
            // 
            // Labels
            // 
            this.Labels.AutoSize = true;
            this.Labels.Location = new System.Drawing.Point(61, 27);
            this.Labels.Name = "Labels";
            this.Labels.Size = new System.Drawing.Size(37, 22);
            this.Labels.TabIndex = 14;
            this.Labels.Text = "TC:";
            // 
            // MskTC
            // 
            this.MskTC.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MskTC.Location = new System.Drawing.Point(104, 24);
            this.MskTC.Mask = "00000000000";
            this.MskTC.Name = "MskTC";
            this.MskTC.Size = new System.Drawing.Size(139, 25);
            this.MskTC.TabIndex = 1;
            this.MskTC.ValidatingType = typeof(int);
            // 
            // Lblözel
            // 
            this.Lblözel.AutoSize = true;
            this.Lblözel.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Lblözel.Location = new System.Drawing.Point(12, 9);
            this.Lblözel.Name = "Lblözel";
            this.Lblözel.Size = new System.Drawing.Size(37, 12);
            this.Lblözel.TabIndex = 26;
            this.Lblözel.Text = "label1";
            this.Lblözel.Visible = false;
            // 
            // FrmSifreunut
            // 
            this.AcceptButton = this.BtnDegistir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(366, 149);
            this.Controls.Add(this.Lblözel);
            this.Controls.Add(this.MskTC);
            this.Controls.Add(this.Labels);
            this.Controls.Add(this.Txtmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnDegistir);
            this.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimizeBox = false;
            this.Name = "FrmSifreunut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ŞİFREMİ UNUTTUM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDegistir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txtmail;
        private System.Windows.Forms.Label Labels;
        private System.Windows.Forms.MaskedTextBox MskTC;
        private System.Windows.Forms.Label Lblözel;
    }
}