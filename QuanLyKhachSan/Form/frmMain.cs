using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyKhachSan.UserControl;
using QuanLyKhachSan.UserControl.QuanLy;
using QuanLyKhachSan.UserControl.NghiepVu;

namespace QuanLyKhachSan
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void celeVatDung_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            frmVatDung vd = new frmVatDung();
            panel.Controls.Add(vd);
        }

        private void celeKhachHang_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            frmKhachHang kh = new frmKhachHang();
            panel.Controls.Add(kh);

        }

        private void NG_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            frmNguoiDung nd = new frmNguoiDung();
            panel.Controls.Add(nd);
        }

        private void celePhong_Click(object sender, EventArgs e)
        {

            panel.Controls.Clear();
            frmPhong p = new frmPhong();
            panel.Controls.Add(p);
        }

        private void celeThuePhong_Click(object sender, EventArgs e)
        {

            panel.Controls.Clear();
            frmThuePhong tp = new frmThuePhong();
            panel.Controls.Add(tp);
        }

        private void celeDichVu_Click(object sender, EventArgs e)
        {

            panel.Controls.Clear();
            frmSuDungDichVu sddv = new frmSuDungDichVu();
            panel.Controls.Add(sddv);
        }

        private void celeThanhToan_Click(object sender, EventArgs e)
        {

            panel.Controls.Clear();
            ThanhToan tt = new ThanhToan();
            panel.Controls.Add(tt);
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

            panel.Controls.Clear();
            DatPhong dp = new DatPhong();
            panel.Controls.Add(dp);
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

            panel.Controls.Clear();
            frmHuongDan hd = new frmHuongDan();
            panel.Controls.Add(hd);
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
           
        }

        private void clebDichVu_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            frmDichVu dv = new frmDichVu();
            panel.Controls.Add(dv);
        }

        private void celeDangXuat(object sender, EventArgs e)
        {
            frmDangNhap fDK = new frmDangNhap();
            fDK.Show();
            this.Hide();
        }

       
    }
}
