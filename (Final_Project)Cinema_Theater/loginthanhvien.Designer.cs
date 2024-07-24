namespace datve11
{
    partial class loginthanhvien
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
            this.btnxacnhan = new System.Windows.Forms.Button();
            this.btndki = new System.Windows.Forms.Button();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnxacnhan
            // 
            this.btnxacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxacnhan.Location = new System.Drawing.Point(204, 123);
            this.btnxacnhan.Name = "btnxacnhan";
            this.btnxacnhan.Size = new System.Drawing.Size(101, 29);
            this.btnxacnhan.TabIndex = 18;
            this.btnxacnhan.Text = "Xác nhận";
            this.btnxacnhan.UseVisualStyleBackColor = true;
            this.btnxacnhan.Click += new System.EventHandler(this.btnxacnhan_Click_1);
            // 
            // btndki
            // 
            this.btndki.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndki.Location = new System.Drawing.Point(333, 123);
            this.btndki.Name = "btndki";
            this.btndki.Size = new System.Drawing.Size(101, 29);
            this.btndki.TabIndex = 17;
            this.btndki.Text = "Đăng Ký";
            this.btndki.UseVisualStyleBackColor = true;
            this.btndki.Click += new System.EventHandler(this.btndki_Click);
            // 
            // txthoten
            // 
            this.txthoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txthoten.Location = new System.Drawing.Point(188, 17);
            this.txthoten.Multiline = true;
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(292, 33);
            this.txthoten.TabIndex = 16;
            // 
            // txtsdt
            // 
            this.txtsdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtsdt.Location = new System.Drawing.Point(188, 64);
            this.txtsdt.Multiline = true;
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(292, 33);
            this.txtsdt.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(31, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(17, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Số Điện thoại:";
            // 
            // loginthanhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 168);
            this.Controls.Add(this.btnxacnhan);
            this.Controls.Add(this.btndki);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.txtsdt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "loginthanhvien";
            this.Text = "loginthanhvien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnxacnhan;
        private System.Windows.Forms.Button btndki;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.TextBox txtsdt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}