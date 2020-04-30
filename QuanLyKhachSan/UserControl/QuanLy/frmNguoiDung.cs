using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyKhachSan.DAO;
using System.Data.SqlClient;

namespace QuanLyKhachSan.UserControl
{
    public partial class frmNguoiDung : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccessContext db = new DataAccessContext();
        public frmNguoiDung()
        {
            InitializeComponent();
        }
        void ClearDataGridView()
        {
            dgvNhanVien.DataSource = null;
         
        }
        void ClearTextBox()
        {
            txtSDT.Text = "";
            txtTenNV.Text = "";
            txtTaiKhoan.Text = "";
        }
 
        void XoabyMaNV(int MaNV)
        {
            SqlCommand _cmd = new SqlCommand("UPDATE HOADON SET MaNV = NULL WHERE MaNV = " + MaNV);
            db.executeSelectQuery(_cmd);
            SqlCommand cmd = new SqlCommand("DELETE FROM NHANVIEN WHERE MaNV = " + MaNV);
            db.executeSelectQuery(cmd);
        }
        void LoadData()
        {
            DataTable dt = new DataTable();
            string query = "select * from NHANVIEN";
            db.readDatathroughAdapter(query, dt);
            dgvNhanVien.DataSource = dt;
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            ClearDataGridView();
            LoadData();
             
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
            DataTable dt = new DataTable();
            string query = "select * from NHANVIEN where TaiKhoan like '%"+txtTaiKhoan.Text+"%' " +
                "and HoTen like N'%"+txtTenNV.Text+"%' and SDT like '%"+txtSDT.Text+"%' ";
            db.readDatathroughAdapter(query, dt);
            dgvNhanVien.DataSource = dt;
            ClearTextBox();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int selectIndex = dgvNhanVien.SelectedRows[0].Index;
            int MaNV = (int) dgvNhanVien[0, selectIndex].Value;
            XoabyMaNV(MaNV);
            dgvNhanVien.Rows.RemoveAt(dgvNhanVien.SelectedRows[0].Index);



        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlCommand saveCom = new SqlCommand(@"UPDATE NHANVIEN
                                       SET HoTen = @TenNV , 
                                           TaiKhoan = @TK ,MatKhau = @MK,
                                           NgaySinh = @NgSinh,GioiTinh = @GioiTinh,SDT = @SDT
                                           WHERE MaNV = @MaNV");

            saveCom.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = "";
            saveCom.Parameters.Add("@TK", SqlDbType.VarChar).Value = "";
            saveCom.Parameters.Add("@MK", SqlDbType.VarChar).Value = "";
            saveCom.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = "";
            saveCom.Parameters.Add("@GioiTinh", SqlDbType.VarChar).Value = "";
            saveCom.Parameters.Add("@NgSinh", SqlDbType.VarChar).Value = "";
            saveCom.Parameters.Add("@SDT", SqlDbType.VarChar).Value = "";

            int i = 0;
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                i++;
                if (i <= dgvNhanVien.Rows.Count - 1)
                {
                    saveCom.Parameters["@TenNV"].Value = row.Cells["HoTen"].Value.ToString();
                    saveCom.Parameters["@TK"].Value = row.Cells["TaiKhoan"].Value.ToString();
                    saveCom.Parameters["@MK"].Value = row.Cells["MatKhau"].Value.ToString();
                    saveCom.Parameters["@MaNV"].Value = row.Cells["MaNV"].Value.ToString();
                    saveCom.Parameters["@NgSinh"].Value = row.Cells["NgaySinh"].Value.ToString();
                    saveCom.Parameters["@GioiTinh"].Value = row.Cells["GioiTinh"].Value.ToString();
                    saveCom.Parameters["@SDT"].Value = row.Cells["SDT"].Value.ToString();
                    db.executeQuery(saveCom);
                }


            }
            XtraMessageBox.Show("Lưu thành công");
            LoadData();
        }
    }
}
