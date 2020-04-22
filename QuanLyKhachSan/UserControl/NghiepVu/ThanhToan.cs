using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using QuanLyKhachSan.DAO;
namespace QuanLyKhachSan.UserControl.NghiepVu
{
    public partial class ThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        public string mahd;
        public ThanhToan()
        {
            InitializeComponent();
        }
        private void BtnTim_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where SDT = @sdt",DataAccessContext.connection);
            cmd.Parameters.Add("@sdt", txbSDT.Text);
            var sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                txbTen.Text = sqlReader["TenKH"] as string;
                txbSĐT.Text = sqlReader["SDT"] as string;
            }
            sqlReader.Close();
            SqlCommand cmd4 = new SqlCommand("SELECT SUM(GiaThue)+SUM(GiaDichVu)+SUM(GiaVatDung) as GiaThue1,HOADON.MaHoaDon FROM HOADON, SuDungDichVu, PHONG, THUEPHONG, KHACHHANG, DICHVU, VATDUNG, LOAIPHONG WHERE KHACHHANG.MaKH = SuDungDichVu.MaKH AND KHACHHANG.MaKH = THUEPHONG.MaKH AND PHONG.MaPhong = THUEPHONG.MaPhong AND THUEPHONG.MaHoaDon = HOADON.MaHoaDon AND DICHVU.MaDichVu = SuDungDichVu.MaDichVu AND PHONG.MaLoai = LOAIPHONG.MaLoai  AND TinhTrangThanhToan = 0 AND KHACHHANG.SDT = " + txbSĐT.Text+"GROUP BY HOADON.MaHoaDon", DataAccessContext.connection);
            var sqlReader1 = cmd4.ExecuteReader();
            while (sqlReader1.Read())
            {
                mahd= Convert.ToString((int)sqlReader1["MaHoaDon"]);
                txbTongTien.Text = Convert.ToString((int)sqlReader1["GiaThue1"]);
            }  
            sqlReader1.Close();
            if (mahd != null)
            {
                SqlCommand cmd5 = new SqlCommand("SELECT SUM(DatCoc) as Coc FROM THUEPHONG WHERE MaHoaDon = " + mahd, DataAccessContext.connection);
                var sqlReader2 = cmd5.ExecuteReader();
                while (sqlReader2.Read())
                {
                    txbTongTien.Text = Convert.ToString(Convert.ToInt32(txbTongTien.Text) - (int)sqlReader2["Coc"]);
                }
                sqlReader2.Close();
            }
            string cmd1 = "SELECT TenPhong 'Tên Phòng',GiaThue 'Giá Thuê' FROM HOADON, SuDungDichVu, PHONG, THUEPHONG, KHACHHANG, DICHVU, VATDUNG, LOAIPHONG WHERE KHACHHANG.MaKH = SuDungDichVu.MaKH AND KHACHHANG.MaKH = THUEPHONG.MaKH AND PHONG.MaPhong = THUEPHONG.MaPhong AND THUEPHONG.MaHoaDon = HOADON.MaHoaDon AND DICHVU.MaDichVu = SuDungDichVu.MaDichVu AND PHONG.MaLoai = LOAIPHONG.MaLoai AND TinhTrangThanhToan = 0 AND KHACHHANG.SDT =" + txbSĐT.Text;
            DataAccessContext oop = new DataAccessContext();
            DataTable dataTable = new DataTable();
            oop.readDatathroughAdapter(cmd1, dataTable);
            dGVThuePhong.DataSource = dataTable;

            string cmd2 = "SELECT TENDV 'Tên dịch vụ',GiaDichVu 'Giá dịch vụ' FROM HOADON, SuDungDichVu, PHONG, THUEPHONG, KHACHHANG, DICHVU, VATDUNG, LOAIPHONG WHERE KHACHHANG.MaKH = SuDungDichVu.MaKH AND KHACHHANG.MaKH = THUEPHONG.MaKH AND PHONG.MaPhong = THUEPHONG.MaPhong AND THUEPHONG.MaHoaDon = HOADON.MaHoaDon AND DICHVU.MaDichVu = SuDungDichVu.MaDichVu AND VATDUNG.MaPhong = PHONG.MaPhong AND TinhTrangThanhToan = 0  AND PHONG.MaLoai = LOAIPHONG.MaLoai AND KHACHHANG.SDT =" + txbSĐT.Text;
            DataAccessContext oop1 = new DataAccessContext();
            DataTable dataTable1 = new DataTable();
            oop.readDatathroughAdapter(cmd2, dataTable1);
            dGVSuDungDV.DataSource = dataTable1;

            string cmd3 = "SELECT TenVatDung 'Tên vật dụng',GiaVatDung 'Giá vật dụng' FROM HOADON, SuDungDichVu, PHONG, THUEPHONG, KHACHHANG, DICHVU, VATDUNG, LOAIPHONG WHERE KHACHHANG.MaKH = SuDungDichVu.MaKH AND KHACHHANG.MaKH = THUEPHONG.MaKH AND PHONG.MaPhong = THUEPHONG.MaPhong AND THUEPHONG.MaHoaDon = HOADON.MaHoaDon AND DICHVU.MaDichVu = SuDungDichVu.MaDichVu AND VATDUNG.MaPhong = PHONG.MaPhong AND TinhTrangThanhToan = 0 AND PHONG.MaLoai = LOAIPHONG.MaLoai AND KHACHHANG.SDT =" + txbSĐT.Text;
            DataAccessContext oop2 = new DataAccessContext();
            DataTable dataTable2 = new DataTable();
            oop.readDatathroughAdapter(cmd3, dataTable2);
            dGVDenBu.DataSource = dataTable2;
            }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            DataAccessContext db = new DataAccessContext();
            if (txbTongTien.Text.Equals("")!=true)
            {
                SqlCommand cmd = new SqlCommand("UPDATE HOADON SET TinhTrangThanhToan = 1 WHERE MaHoaDon = @hd ");
                cmd.Parameters.Add("@hd", mahd);
                db.executeSelectQuery(cmd);
                XtraMessageBox.Show("Thanh toán thành công!");
            }
        }
    }
}
