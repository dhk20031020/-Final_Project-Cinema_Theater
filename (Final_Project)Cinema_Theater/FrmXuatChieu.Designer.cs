namespace _Final_Project_Cinema_Theater
{
    partial class FrmXuatChieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXuatChieu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.ToolTripSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.DtpGioChieu = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtGiaVe = new System.Windows.Forms.TextBox();
            this.LblNgayChieu = new System.Windows.Forms.Label();
            this.TxtIDLC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CbPhongChieu = new System.Windows.Forms.ComboBox();
            this.CbTenPhim = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DsXuatChieu = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DsXuatChieu)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Turquoise;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripThem,
            this.toolStripSua,
            this.toolStripXoa,
            this.ToolTripSearch,
            this.toolStripSeparator1,
            this.TxtSearch});
            this.toolStrip1.Location = new System.Drawing.Point(2, 21);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(592, 25);
            this.toolStrip1.TabIndex = 146;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripThem
            // 
            this.toolStripThem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripThem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripThem.Image")));
            this.toolStripThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripThem.Name = "toolStripThem";
            this.toolStripThem.Size = new System.Drawing.Size(41, 22);
            this.toolStripThem.Text = "Thêm";
            this.toolStripThem.Click += new System.EventHandler(this.toolStripThem_Click);
            // 
            // toolStripSua
            // 
            this.toolStripSua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSua.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSua.Image")));
            this.toolStripSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSua.Name = "toolStripSua";
            this.toolStripSua.Size = new System.Drawing.Size(30, 22);
            this.toolStripSua.Text = "Sửa";
            this.toolStripSua.Click += new System.EventHandler(this.toolStripSua_Click);
            // 
            // toolStripXoa
            // 
            this.toolStripXoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripXoa.Image = ((System.Drawing.Image)(resources.GetObject("toolStripXoa.Image")));
            this.toolStripXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXoa.Name = "toolStripXoa";
            this.toolStripXoa.Size = new System.Drawing.Size(31, 22);
            this.toolStripXoa.Text = "Xoá";
            this.toolStripXoa.Click += new System.EventHandler(this.toolStripXoa_Click);
            // 
            // ToolTripSearch
            // 
            this.ToolTripSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolTripSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolTripSearch.Image = ((System.Drawing.Image)(resources.GetObject("ToolTripSearch.Image")));
            this.ToolTripSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolTripSearch.Name = "ToolTripSearch";
            this.ToolTripSearch.Size = new System.Drawing.Size(31, 22);
            this.ToolTripSearch.Text = "Tìm";
            this.ToolTripSearch.Click += new System.EventHandler(this.ToolTripSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(150, 25);
            this.TxtSearch.Tag = "Nhập nội dung cần tìm";
            // 
            // DtpGioChieu
            // 
            this.DtpGioChieu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpGioChieu.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpGioChieu.Location = new System.Drawing.Point(130, 92);
            this.DtpGioChieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DtpGioChieu.Name = "DtpGioChieu";
            this.DtpGioChieu.Size = new System.Drawing.Size(114, 22);
            this.DtpGioChieu.TabIndex = 141;
            this.DtpGioChieu.UseWaitCursor = true;
            this.DtpGioChieu.ValueChanged += new System.EventHandler(this.DtpGioChieu_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(63, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 139;
            this.label10.Text = "Giá Vé";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 136;
            this.label1.Text = "Thời Gian Chiếu";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.TxtGiaVe);
            this.groupBox2.Controls.Add(this.LblNgayChieu);
            this.groupBox2.Controls.Add(this.TxtIDLC);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CbPhongChieu);
            this.groupBox2.Controls.Add(this.CbTenPhim);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Controls.Add(this.DtpGioChieu);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(596, 164);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Xuất Chiếu";
            // 
            // TxtGiaVe
            // 
            this.TxtGiaVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGiaVe.Location = new System.Drawing.Point(130, 130);
            this.TxtGiaVe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtGiaVe.Name = "TxtGiaVe";
            this.TxtGiaVe.Size = new System.Drawing.Size(113, 21);
            this.TxtGiaVe.TabIndex = 162;
            // 
            // LblNgayChieu
            // 
            this.LblNgayChieu.AutoSize = true;
            this.LblNgayChieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNgayChieu.Location = new System.Drawing.Point(269, 97);
            this.LblNgayChieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblNgayChieu.Name = "LblNgayChieu";
            this.LblNgayChieu.Size = new System.Drawing.Size(0, 15);
            this.LblNgayChieu.TabIndex = 161;
            // 
            // TxtIDLC
            // 
            this.TxtIDLC.Location = new System.Drawing.Point(130, 55);
            this.TxtIDLC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtIDLC.Name = "TxtIDLC";
            this.TxtIDLC.Size = new System.Drawing.Size(113, 26);
            this.TxtIDLC.TabIndex = 160;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 159;
            this.label3.Text = "ID Lịch Chiếu";
            // 
            // CbPhongChieu
            // 
            this.CbPhongChieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPhongChieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbPhongChieu.FormattingEnabled = true;
            this.CbPhongChieu.Location = new System.Drawing.Point(350, 60);
            this.CbPhongChieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CbPhongChieu.Name = "CbPhongChieu";
            this.CbPhongChieu.Size = new System.Drawing.Size(181, 23);
            this.CbPhongChieu.TabIndex = 150;
            this.CbPhongChieu.SelectedIndexChanged += new System.EventHandler(this.CbPhongChieu_SelectedIndexChanged);
            // 
            // CbTenPhim
            // 
            this.CbTenPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTenPhim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbTenPhim.FormattingEnabled = true;
            this.CbTenPhim.Location = new System.Drawing.Point(326, 128);
            this.CbTenPhim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CbTenPhim.Name = "CbTenPhim";
            this.CbTenPhim.Size = new System.Drawing.Size(205, 23);
            this.CbTenPhim.TabIndex = 149;
            this.CbTenPhim.SelectedIndexChanged += new System.EventHandler(this.CbTenPhim_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(259, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 131;
            this.label7.Text = "Tên Phim";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(269, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 14);
            this.label5.TabIndex = 127;
            this.label5.Text = "Phòng Chiếu";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Red;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(596, 422);
            this.splitContainer1.SplitterDistance = 164;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox1.Controls.Add(this.DsXuatChieu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(596, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Phim";
            // 
            // DsXuatChieu
            // 
            this.DsXuatChieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DsXuatChieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DsXuatChieu.Location = new System.Drawing.Point(2, 15);
            this.DsXuatChieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DsXuatChieu.Name = "DsXuatChieu";
            this.DsXuatChieu.RowHeadersWidth = 51;
            this.DsXuatChieu.RowTemplate.Height = 24;
            this.DsXuatChieu.Size = new System.Drawing.Size(592, 238);
            this.DsXuatChieu.TabIndex = 0;
            this.DsXuatChieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DsXuatChieu_CellClick);
            this.DsXuatChieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DsXuatChieu_CellContentClick);
            // 
            // FrmXuatChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 422);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmXuatChieu";
            this.Text = "Thông Tin Xuất Chiếu";
            this.Load += new System.EventHandler(this.FrmXuatChieu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DsXuatChieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton toolStripThem;
        private System.Windows.Forms.ToolStripButton toolStripSua;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolTripSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox TxtSearch;
        private System.Windows.Forms.DateTimePicker DtpGioChieu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DsXuatChieu;
        private System.Windows.Forms.ComboBox CbTenPhim;
        private System.Windows.Forms.ComboBox CbPhongChieu;
        private System.Windows.Forms.TextBox TxtIDLC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtGiaVe;
        private System.Windows.Forms.Label LblNgayChieu;
    }
}