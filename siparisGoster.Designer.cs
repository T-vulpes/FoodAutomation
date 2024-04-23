
namespace yemekotomasyonu
{
    partial class siparisGoster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(siparisGoster));
            this.islem = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // islem
            // 
            this.islem.AutoSize = true;
            this.islem.BackColor = System.Drawing.SystemColors.Info;
            this.islem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.islem.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.islem.Location = new System.Drawing.Point(97, 25);
            this.islem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.islem.Name = "islem";
            this.islem.Size = new System.Drawing.Size(15, 20);
            this.islem.TabIndex = 39;
            this.islem.Text = "-";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Label2.Location = new System.Drawing.Point(18, 22);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 26);
            this.Label2.TabIndex = 38;
            this.Label2.Text = "İşlem:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(120, 218);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(728, 29);
            this.label9.TabIndex = 37;
            this.label9.Text = "Siparişlerini daha detaylı görmek için tabloda olanları tıklayın!";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Label3.Location = new System.Drawing.Point(322, 22);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 26);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "ID No:";
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 20;
            this.ListBox1.Location = new System.Drawing.Point(22, 67);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(980, 144);
            this.ListBox1.TabIndex = 33;
            // 
            // DataGridView1
            // 
            this.DataGridView1.BackgroundColor = System.Drawing.Color.Thistle;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataGridView1.Location = new System.Drawing.Point(22, 253);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 62;
            this.DataGridView1.Size = new System.Drawing.Size(980, 231);
            this.DataGridView1.TabIndex = 32;
            this.DataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.BackColor = System.Drawing.SystemColors.Info;
            this.id.Location = new System.Drawing.Point(404, 27);
            this.id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(14, 20);
            this.id.TabIndex = 31;
            this.id.Text = "-";
            // 
            // siparisGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1023, 529);
            this.Controls.Add(this.islem);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.id);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "siparisGoster";
            this.Text = "siparisGoster";
            this.Load += new System.EventHandler(this.siparisGoster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label islem;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Label id;
    }
}