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

namespace QuanLyKhachSan
{
    
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        private string sex = "";
        DataAccessContext db = new DataAccessContext();
        public frmDangKy()
        {
            InitializeComponent();
        }
        bool isComfirmPassword()
        {
            bool result;
            if (txtMatKhau.Text.Equals(txtXacNhanMatKhau.Text))
                result = true;
            else
                result = false;
            return result;
        }
        bool isEmptyInfo()
        {
            bool result;
            if (txtXacNhanMatKhau.Text.Equals("") || txtMatKhau.Text.Equals("") || txtTenNV.Text.Equals("") ||
                txtSDT.Text.Equals("") || sex.Equals("") || txtTaiKhoan.Text.Equals(""))
                result = true;
            else
                result = false;
            return result;
        }
        bool Duplicate()
        {
            bool result;
            SqlCommand cmd = new SqlCommand("select * from NHANVIEN where TaiKhoan = '"+txtTaiKhoan.Text+"'");
            var num = db.executeSelectQuery(cmd);
            if (num != null )
                result = true;
            else
                result = false;
            return result;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            sex = radiogroupSex.Text.Equals("True") ? "Nam" : "Nu";
            if (!isEmptyInfo())
            {
                if(isComfirmPassword())
                { 
                    if(!Duplicate())
                    {
                        SqlCommand cmd = new SqlCommand("INSERT [dbo].[NHANVIEN] ([TaiKhoan], [MatKhau], [HoTen], [NgaySinh], [GioiTinh], [SDT]) VALUES ( N'" + txtTaiKhoan.Text + "', " +
                                        "N'" + txtMatKhau.Text + "', N'" + txtTenNV.Text + "', CAST(N'" + dateTimeNgaySinh.Value + "' AS Date), N'" + sex + "', N'" + txtSDT.Text + "')");
                        db.executeQuery(cmd);
                        XtraMessageBox.Show("Tạo hồ sơ thành công");
                    }
                    else { XtraMessageBox.Show("Tên Tài khoản đã tồn tại", "Lỗi Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
              
                }    
                else
                { 
                    XtraMessageBox.Show("Xác nhận mật khẩu sai", "Lỗi Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else  
            {
                XtraMessageBox.Show("Chưa nhâp đủ thông tin !","Lỗi Người Dùng",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }
     
           
        }
    }
}