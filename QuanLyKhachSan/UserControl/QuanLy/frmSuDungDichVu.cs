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

namespace QuanLyKhachSan.UserControl.QuanLy
{
    public partial class frmSuDungDichVu : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccessContext db = new DataAccessContext();

        public frmSuDungDichVu()
        {
            InitializeComponent();
        }

        private void frmSuDungDichVu_Load(object sender, EventArgs e)
        {
            cbxTinhTrangHD.Properties.Items.Add("Đã Thanh Toán");
            cbxTinhTrangHD.Properties.Items.Add("Chưa Thanh Toán");

            SqlConnection conn = new SqlConnection(db.GetStrConnect);
            SqlCommand load = new SqlCommand("select MaDichVu from DICHVU", conn);

            conn.Open();

            SqlDataReader reader = load.ExecuteReader();
            while (reader.Read())
            {
                cbxMaDV.Properties.Items.Add(reader.GetInt32(0));
            }

            conn.Close();
            loadData();
        }

        void clearTB()
        {
            txtSDT.Text = "";
            txtMaHD.Text = "";
            txtMaKH.Text = "";
            cbxTinhTrangHD.Text = "";
        }

        void loadData()
        {
            string load = "select kh.TenKH,kh.SDT,sddv.MaHoaDon,kh.MaKH,sddv.MaDichVu,sddv.SoLuong,hd.TinhTrangThanhToan,dv.GiaDichVu,dv.TENDV " +
                "from SuDungDichVu sddv,KHACHHANG kh,HOADON hd,DICHVU dv " +
                "where hd.MaKH = kh.MaKH and dv.MaDichVu = sddv.MaDichVu and hd.MaHoaDon = sddv.MaHoaDon";
            DataTable dt = new DataTable();

            db.readDatathroughAdapter(load, dt);
            dgvSDDichVu.DataSource = dt;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgvSDDichVu.DataSource = null;

            string search = "select * from SuDungDichVu sddv,KHACHHANG kh,HOADON hd,DICHVU dv" +
                      " where  dv.MaDichVu = sddv.MaDichVu and hd.MaHoaDon = sddv.MaHoaDon and hd.MaKH = kh.MaKH " +
                      " and kh.MaKH like '%" + txtMaKH.Text + "%' and hd.MaHoaDon like N'%" + txtMaHD.Text + "%' and hd.TinhTrangThanhToan like '%" + sThanhToan() + "%'" +
                      " and kh.SDT like '%" + txtSDT.Text + "%'";
            DataTable dt = new DataTable();

            db.readDatathroughAdapter(search, dt);
            dgvSDDichVu.DataSource = dt;
            clearTB();
        }

        string sThanhToan()
        {
            //đổi trạng thái tình trạng hóa đơn từ chuỗi sang số
            string sThanhToan = "";

            if (cbxTinhTrangHD.Text == "Đã Thanh Toán")
            {
                sThanhToan = "1";
            }
            else if (cbxTinhTrangHD.Text == "Chưa Thanh Toán")
            {
                sThanhToan = "0";
            }
            else
            {
                sThanhToan = "";
            } 

            return sThanhToan;
        }

        bool isEmpty()
        {
            bool result;

            if (txtMaKH.Text.Equals("") || txtMaHD.Text.Equals("") || cbxMaDV.Text.Equals("") || numberricSoLuong.Value == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEmpty())
                {
                    XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin bao gồm: Mã Khách hàng, Mã Hóa Đơn, Mã Dịch Vụ và Số lượng (Lưu ý: phải khác 0)", "Thông báo.");
                }
                else
                {
                    SqlCommand insert1 = new SqlCommand("INSERT into SuDungDichVu(MaDichVu,MaHoaDon,SoLuong,NgayDungDichVu) " +
                        "VALUES ('" + cbxMaDV.Text + "','" + txtMaHD.Text + "','" + numberricSoLuong.Value + "',CAST('" + DateTime.Now.ToString() + "' AS DATE))");
                    /*SqlCommand insert2 = new SqlCommand("INSERT into HOADON(MaKH,MaHoaDon,SoLuong) " +
                        "VALUES ('" + txtMaKH.Text + "','" + txtMaHD.Text + "','" + numberricSoLuong.Value + "')");*/

                    db.executeSelectQuery(insert1);
                    XtraMessageBox.Show("Thêm thành công.", "Thông báo.");
                }
                loadData();
            }
            catch
            {
                XtraMessageBox.Show("Khách hàng đã sử dụng dịch vụ này trong ngày.Quay lại vào ngày mai");
            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand(@"UPDATE SuDungDichVu SET SoLuong = @SoLuong WHERE MaHoaDon = @MaHD and MaDichVu = @MaDichVu");

            update.Parameters.Add("@SoLuong", SqlDbType.NVarChar).Value = "";
            update.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = "";
            update.Parameters.Add("@MaDichVu", SqlDbType.NVarChar).Value = "";

            int i = 0;
            foreach (DataGridViewRow row in dgvSDDichVu.Rows)
            {
                i++;
                if (i <= dgvSDDichVu.Rows.Count - 1)
                {

                    update.Parameters["@SoLuong"].Value = row.Cells["SoLuong"].Value.ToString();
                    update.Parameters["@MaHD"].Value = row.Cells["MaHoaDon"].Value.ToString();
                    update.Parameters["@MaDichVu"].Value = row.Cells["MaDichVu"].Value.ToString();
                    db.executeQuery(update);
                }
            }
            XtraMessageBox.Show("Chỉnh sửa thành công.", "Thông báo.");
            loadData();
        }

        void XoatheoMaNV(int MaHD, int MaDV)
        {
            SqlCommand delete = new SqlCommand("DELETE FROM SuDungDichVu WHERE MaHoaDon = " + MaHD + " and MaDichVu = " + MaDV);
            db.executeSelectQuery(delete);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int selectIndex = dgvSDDichVu.SelectedRows[0].Index;
            int MaDV = (int)dgvSDDichVu[0, selectIndex].Value;
            int MaHD = (int)dgvSDDichVu[1, selectIndex].Value;

            XoatheoMaNV(MaHD, MaDV);
            dgvSDDichVu.Rows.RemoveAt(dgvSDDichVu.SelectedRows[0].Index);

            XtraMessageBox.Show("Xóa thành công.", "Thông báo.");
            loadData();
        }

        private void cbxMaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(db.GetStrConnect);
            SqlCommand cmd = new SqlCommand("select * from DICHVU where MaDichVu like '%" + cbxMaDV.Text + "%'", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtGiaDV.Text = reader.GetInt32(2).ToString();
                txtTenDV.Text = reader.GetString(1);
            }
            conn.Close();
        }
    }
}
