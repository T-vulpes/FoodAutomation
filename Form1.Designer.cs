
namespace yemekotomasyonu
{
    partial class Form1
    {


        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Button4 = new System.Windows.Forms.Button();
            this.sifre = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Controls.Add(this.txtKullaniciAdi);
            this.Panel1.Controls.Add(this.Button3);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.Button4);
            this.Panel1.Controls.Add(this.sifre);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Location = new System.Drawing.Point(159, 169);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(642, 232);
            this.Panel1.TabIndex = 12;
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(295, 34);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(199, 26);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // Button3
            // 
            this.Button3.BackColor = System.Drawing.Color.PeachPuff;
            this.Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.ForeColor = System.Drawing.Color.Black;
            this.Button3.Location = new System.Drawing.Point(478, 143);
            this.Button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(147, 62);
            this.Button3.TabIndex = 2;
            this.Button3.Text = "Giriş Yap";
            this.Button3.UseVisualStyleBackColor = false;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(159, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 57);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre:";
            // 
            // Button4
            // 
            this.Button4.BackColor = System.Drawing.Color.PeachPuff;
            this.Button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button4.ForeColor = System.Drawing.Color.Black;
            this.Button4.Location = new System.Drawing.Point(295, 143);
            this.Button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(147, 62);
            this.Button4.TabIndex = 2;
            this.Button4.Text = "Kayıt Ol";
            this.Button4.UseVisualStyleBackColor = false;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // sifre
            // 
            this.sifre.Location = new System.Drawing.Point(295, 79);
            this.sifre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sifre.Name = "sifre";
            this.sifre.PasswordChar = '*';
            this.sifre.Size = new System.Drawing.Size(199, 26);
            this.sifre.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(4, 9);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(271, 57);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Kullanıcı Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PeachPuff;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Century", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(160, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(641, 64);
            this.label1.TabIndex = 13;
            this.label1.Text = "YEMEK OTOMASYONU";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(927, 526);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label label1;
    }
}

