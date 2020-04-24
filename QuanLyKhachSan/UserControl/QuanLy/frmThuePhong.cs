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

namespace QuanLyKhachSan.UserControl
{
    public partial class frmThuePhong : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccessContext db = new DataAccessContext();
        public frmThuePhong()
        {
            InitializeComponent();
        }

        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            string query = "select p.TenPhong,kh.TenKH,kh.SDT,tp.NgayBatDauThue,tp.NgayTraPhong,tp.SoDem,hd.TinhTrangThanhToan,hd.MaHoaDon from HOADON hd,THUEPHONG tp,PHONG p ,KHACHHANG kh"+
              " where tp.MaPhong = p.MaPhong and kh.MaKH = tp.MaKH and hd.MaHoaDon = tp.MaHoaDon";
            DataTable dt = new DataTable();
            db.readDatathroughAdapter(query, dt);
            dgvThuePhong.DataSource = dt;

        }
    }
}
