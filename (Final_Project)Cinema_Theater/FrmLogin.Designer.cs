namespace _Final_Project_Cinema_Theater
{
    partial class FrmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnThoat = new System.Windows.Forms.Button();
            this.BtnDNhap = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnThoat);
            this.panel1.Controls.Add(this.BtnDNhap);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 168);
            this.panel1.TabIndex = 0;
            // 
            // BtnThoat
            // 
            this.BtnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnThoat.Location = new System.Drawing.Point(2, 121);
            this.BtnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.BtnThoat.Name = "BtnThoat";
            this.BtnThoat.Size = new System.Drawing.Size(84, 33);
            this.BtnThoat.TabIndex = 4;
            this.BtnThoat.Text = "Thoát";
            this.BtnThoat.UseVisualStyleBackColor = false;
            this.BtnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // BtnDNhap
            // 
            this.BtnDNhap.BackColor = System.Drawing.Color.Lime;
            this.BtnDNhap.Location = new System.Drawing.Point(267, 121);
            this.BtnDNhap.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDNhap.Name = "BtnDNhap";
            this.BtnDNhap.Size = new System.Drawing.Size(84, 33);
            this.BtnDNhap.TabIndex = 2;
            this.BtnDNhap.Text = "Đăng Nhập";
            this.BtnDNhap.UseVisualStyleBackColor = false;
            this.BtnDNhap.Click += new System.EventHandler(this.BtnDNhap_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtPassword);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(2, 60);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 56);
            this.panel3.TabIndex = 1;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(164, 15);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(186, 20);
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtUsername);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 53);
            this.panel2.TabIndex = 0;
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(164, 19);
            this.TxtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(186, 20);
            this.TxtUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Đăng Nhập";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(374, 188);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnThoat;
        private System.Windows.Forms.Button BtnDNhap;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUsername;
    }
}

