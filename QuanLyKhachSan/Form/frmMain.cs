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
using QuanLyKhachSan.Form;

namespace QuanLyKhachSan
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMain()
        {
            this.KeyPreview = true;
            KeyDown += new KeyEventHandler(fluentDesignFormContainer1_KeyUp);
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

        private void fluentDesignFormContainer1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                    case Keys.F1:
                    DVTuto dv = new DVTuto();
                    dv.Show();
                    break;
                case Keys.F2:
                    KHTuto dv1 = new KHTuto();
                    dv1.Show();
                    break;
                case Keys.F3:
                    SDDVTuto dv2 = new SDDVTuto();
                    dv2.Show();
                    break;
                case Keys.F4:
                    ThuePhongTuto dv3 = new ThuePhongTuto();
                    dv3.Show();
                    break;
                case Keys.F5:
                    NDTuto dv4 = new NDTuto();
                    dv4.Show();
                    break;
                case Keys.F6:
                    VatDungTuto dv5 = new VatDungTuto();
                    dv5.Show();
                    break;
                case Keys.F7:
                    ThanhToanTuto dv6 = new ThanhToanTuto();
                    dv6.Show();
                    break;
                case Keys.F8:
                    DatPhongTuto dv7 = new DatPhongTuto();
                    dv7.Show();
                    break;
                case Keys.F9:
                    PhongTuto dv8 = new PhongTuto();
                    dv8.Show();
                    break;

            }
          
        
        }
    }
}
