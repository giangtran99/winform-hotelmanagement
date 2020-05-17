using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyKhachSan.DAO;
using System.Data.SqlClient;
using QuanLyKhachSan.Form;

namespace QuanLyKhachSan
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        DataAccessContext db = new DataAccessContext();
        public frmDangNhap()
        {
           
            InitializeComponent();
        }

        private void checkButton2_CheckedChanged(object sender, EventArgs e)
        {
            frmDangKy dk = new frmDangKy();
            dk.Show();

        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {


            SqlCommand cmd = new SqlCommand("select COUNT(*) from NhanVien where TaiKhoan = @TaiKhoan and MatKhau = @MatKhau");
            cmd.Parameters.Add("@TaiKhoan", txtTaiKhoan.Text);
            cmd.Parameters.Add("@MatKhau", txtMatKhau.Text);
            int count = (int) db.executeSelectQuery(cmd);
            if(count == 1)
            {
                frmMain fMain = new frmMain();
                this.Hide();
                fMain.Show();
                
            }
            else { XtraMessageBox.Show("Chưa nhập đủ thông tin hoặc tài khoản không tồn tại !"); }
            
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
       
        }
    }
}