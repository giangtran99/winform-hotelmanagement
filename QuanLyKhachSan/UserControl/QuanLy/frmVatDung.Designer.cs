namespace QuanLyKhachSan.UserControl
{
    partial class frmVatDung
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvVatDung = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaPhong = new System.Windows.Forms.ComboBox();
            this.tbMaVatDung = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTinhTrang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGia = new System.Windows.Forms.TextBox();
            this.tbTenVatDung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatDung)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVatDung
            // 
            this.dgvVatDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVatDung.Location = new System.Drawing.Point(244, 153);
            this.dgvVatDung.Name = "dgvVatDung";
            this.dgvVatDung.Size = new System.Drawing.Size(518, 342);
            this.dgvVatDung.TabIndex = 0;
            this.dgvVatDung.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Phòng";
            // 
            // tbMaPhong
            // 
            this.tbMaPhong.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbMaPhong.FormattingEnabled = true;
            this.tbMaPhong.Location = new System.Drawing.Point(6, 73);
            this.tbMaPhong.Name = "tbMaPhong";
            this.tbMaPhong.Size = new System.Drawing.Size(175, 24);
            this.tbMaPhong.TabIndex = 2;
            // 
            // tbMaVatDung
            // 
            this.tbMaVatDung.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbMaVatDung.FormattingEnabled = true;
            this.tbMaVatDung.Location = new System.Drawing.Point(6, 162);
            this.tbMaVatDung.Name = "tbMaVatDung";
            this.tbMaVatDung.Size = new System.Drawing.Size(175, 24);
            this.tbMaVatDung.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.Location = new System.Drawing.Point(36, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Vật Dụng";
            // 
            // tbTinhTrang
            // 
            this.tbTinhTrang.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbTinhTrang.FormattingEnabled = true;
            this.tbTinhTrang.Location = new System.Drawing.Point(9, 424);
            this.tbTinhTrang.Name = "tbTinhTrang";
            this.tbTinhTrang.Size = new System.Drawing.Size(175, 24);
            this.tbTinhTrang.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label3.Location = new System.Drawing.Point(50, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tình Trạng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label4.Location = new System.Drawing.Point(67, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Giá";
            // 
            // tbGia
            // 
            this.tbGia.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbGia.Location = new System.Drawing.Point(9, 331);
            this.tbGia.Name = "tbGia";
            this.tbGia.Size = new System.Drawing.Size(175, 24);
            this.tbGia.TabIndex = 8;
            // 
            // tbTenVatDung
            // 
            this.tbTenVatDung.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbTenVatDung.Location = new System.Drawing.Point(7, 249);
            this.tbTenVatDung.Name = "tbTenVatDung";
            this.tbTenVatDung.Size = new System.Drawing.Size(175, 24);
            this.tbTenVatDung.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label5.Location = new System.Drawing.Point(36, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tên Vật Dụng";
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Location = new System.Drawing.Point(244, 73);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(106, 44);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Location = new System.Drawing.Point(379, 73);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(106, 44);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Location = new System.Drawing.Point(511, 73);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(106, 44);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Location = new System.Drawing.Point(656, 73);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(106, 44);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu thay đổi";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmVatDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.tbTenVatDung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbGia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTinhTrang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMaVatDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMaPhong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvVatDung);
            this.Name = "frmVatDung";
            this.Size = new System.Drawing.Size(1249, 498);
            this.Load += new System.EventHandler(this.frmVatDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVatDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tbMaPhong;
        private System.Windows.Forms.ComboBox tbMaVatDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tbTinhTrang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGia;
        private System.Windows.Forms.TextBox tbTenVatDung;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
    }
}
