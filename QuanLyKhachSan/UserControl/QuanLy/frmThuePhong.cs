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
    public partial class frmThuePhong : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccessContext db = new DataAccessContext();
        public frmThuePhong()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvThuePhong.DataSource = null;
            string query = "select p.TenPhong,kh.TenKH,kh.SDT,kh.MaKH,tp.NgayBatDauThue,tp.NgayTraPhong,tp.SoDem,hd.TinhTrangThanhToan,hd.MaHoaDon,tp.DatCoc,p.MaPhong from HOADON hd,THUEPHONG tp,PHONG p ,KHACHHANG kh" +
             " where tp.MaPhong = p.MaPhong and kh.MaKH = hd.MaKH and hd.MaHoaDon = tp.MaHoaDon";
            DataTable dt = new DataTable();
            db.readDatathroughAdapter(query, dt);
            dgvThuePhong.DataSource = dt;
        }
        void AddItemforCbx()
        {
            //cbx Thong Ke khach Thue
            cbxTKKhachThue.Properties.Items.Add("Trong Tuần");
            cbxTKKhachThue.Properties.Items.Add("Trong Ngày");
            //cbx Tinh Trang Hoa don
            cbxTinhTrangHD.Properties.Items.Add("Đã Thanh Toán");
            cbxTinhTrangHD.Properties.Items.Add("Chưa Thanh Toán");

        }

        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            AddItemforCbx();
            LoadData();
        }
        void ClearTextBox()
        {
            cbxTinhTrangHD.Text = "";
            cbxTKKhachThue.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
        }

        private void xoasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {



            //Chi sua So Dem voi Dat Coc
            SqlCommand saveCom = new SqlCommand("UPDATE THUEPHONG SET SoDem = @SoDem,DatCoc = @DatCoc,NgayTraPhong = DATEADD(day, @SoDem,NgayBatDauThue) " +
                "WHERE MaHoaDon = @MaHoaDon and MaPhong = @MaPhong ");
            saveCom.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = "";
            saveCom.Parameters.Add("@MaPhong", SqlDbType.Int).Value = "";
            saveCom.Parameters.Add("@SoDem", SqlDbType.Int).Value = "";
            saveCom.Parameters.Add("@DatCoc", SqlDbType.Int).Value = "";

            int i = 0;
            foreach (DataGridViewRow row in dgvThuePhong.Rows)
            {
                i++;
                if (i <= dgvThuePhong.Rows.Count - 1)
                {
                    saveCom.Parameters["@MaHoaDon"].Value = row.Cells["MaHoaDon"].Value.ToString();
                    saveCom.Parameters["@MaPhong"].Value = row.Cells["MaPhong"].Value.ToString();
                    saveCom.Parameters["@SoDem"].Value = row.Cells["SoDem"].Value.ToString();
                    saveCom.Parameters["@DatCoc"].Value = row.Cells["DatCoc"].Value.ToString();
                    db.executeQuery(saveCom);
                }

            }
            LoadData();
            XtraMessageBox.Show("Lưu thành công");


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        string sThanhToan()
        {
            //Doi Trang Thai Thanh Toan tu chuoi sang so
            string sThanhToan = "";
            if (cbxTinhTrangHD.Text == "Đã Thanh Toán")
                sThanhToan = "1";
            else if (cbxTinhTrangHD.Text == "Chưa Thanh Toán")
                sThanhToan = "0";
            else sThanhToan = "";

            return sThanhToan;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {


            string query = "";
            if (cbxTKKhachThue.Text == "Trong Ngày")
            {
                query = "select p.TenPhong,kh.TenKH,kh.SDT,kh.MaKH,tp.NgayBatDauThue,tp.NgayTraPhong,tp.SoDem,hd.TinhTrangThanhToan,hd.MaHoaDon,tp.DatCoc,p.MaPhong from HOADON hd,THUEPHONG tp,PHONG p ,KHACHHANG kh" +
    " where tp.MaPhong = p.MaPhong and kh.MaKH = hd.MaKH and hd.MaHoaDon = tp.MaHoaDon and hd.TinhTrangThanhToan like '%" + sThanhToan() + "%'and NgayBatDauThue = CAST(GetDATE() as date)  ";
            }
            else if (cbxTKKhachThue.Text == "Trong Tuần")
            {
                query = "select p.TenPhong,kh.TenKH,kh.SDT,kh.MaKH,tp.NgayBatDauThue,tp.NgayTraPhong,tp.SoDem,hd.TinhTrangThanhToan,hd.MaHoaDon,tp.DatCoc,p.MaPhong from HOADON hd,THUEPHONG tp,PHONG p ,KHACHHANG kh" +
  " where tp.MaPhong = p.MaPhong and kh.MaKH = hd.MaKH and hd.MaHoaDon = tp.MaHoaDon and hd.TinhTrangThanhToan like '%" + sThanhToan() + "%'and DATEDIFF(day,NgayBatDauThue,CAST(GetDATE() as date)) <= 7   ";
            }
            else if (cbxTKKhachThue.Text == "")
            {
                query = "select p.TenPhong,kh.TenKH,kh.SDT,kh.MaKH,tp.NgayBatDauThue,tp.NgayTraPhong,tp.SoDem,hd.TinhTrangThanhToan,hd.MaHoaDon,tp.DatCoc,p.MaPhong from HOADON hd,THUEPHONG tp,PHONG p ,KHACHHANG kh" +
              " where tp.MaPhong = p.MaPhong and kh.MaKH = hd.MaKH and hd.MaHoaDon = tp.MaHoaDon and hd.TinhTrangThanhToan like '%" + sThanhToan() + "%'";
            }


            DataTable dt = new DataTable();
            db.readDatathroughAdapter(query, dt);
            dgvThuePhong.DataSource = dt;
            ClearTextBox();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvThuePhong.DataSource = null;
            string query = "select p.TenPhong,kh.TenKH,kh.SDT,kh.MaKH,tp.NgayBatDauThue,tp.NgayTraPhong,tp.SoDem,hd.TinhTrangThanhToan,hd.MaHoaDon,tp.DatCoc,p.MaPhong from HOADON hd,THUEPHONG tp,PHONG p ,KHACHHANG kh" +
            " where tp.MaPhong = p.MaPhong and kh.MaKH = hd.MaKH and hd.MaHoaDon = tp.MaHoaDon and kh.TenKH like N'%" + txtTenKH.Text + "%' and kh.SDT like N'%" + txtSDT.Text + "%' and kh.MaKH like '%" + txtMaKH.Text + "%'";
            DataTable dt = new DataTable();
            db.readDatathroughAdapter(query, dt);
            dgvThuePhong.DataSource = dt;
        }
    }
}
