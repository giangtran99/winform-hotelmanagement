using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using QuanLyKhachSan.DAO;
namespace QuanLyKhachSan.UserControl.NghiepVu
{
    public partial class ThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        public string mahd,makh;
        public int tong;
        public ThanhToan()
        {
            InitializeComponent();
        }
        private void BtnTim_Click(object sender, EventArgs e)
        {

            try {
                SqlCommand cmd = new SqlCommand("select * from KHACHHANG where SDT = @sdt", DataAccessContext.connection);
                cmd.Parameters.Add("@sdt", txbSDT.Text);
                if (txbSDT.Text.Length != 0)
                {
                    var sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        makh = Convert.ToString((int)sqlReader["MaKH"]);
                        txbTen.Text = sqlReader["TenKH"] as string;
                        txbSĐT.Text = sqlReader["SDT"] as string;
                    }
                    sqlReader.Close();


                    SqlCommand cmd4 = new SqlCommand("SELECT SUM(GiaThue*SoDem) as Gia,HOADON.MaHoaDon FROM PHONG,LOAIPHONG,THUEPHONG,KHACHHANG,HOADON WHERE PHONG.MaPhong=THUEPHONG.MaPhong AND LOAIPHONG.MaLoai = PHONG.MaLoai AND THUEPHONG.MaKH = KHACHHANG.MaKH AND HOADON.MaHoaDon = THUEPHONG.MaHoaDon AND TinhTrangThanhToan = 0 AND KHACHHANG.MaKH = @makh GROUP BY HOADON.MaHoaDon", DataAccessContext.connection);
                    cmd4.Parameters.Add("@makh", makh);
                    var sqlReader1 = cmd4.ExecuteReader();
                    while (sqlReader1.Read())
                    {
                        mahd = Convert.ToString((int)sqlReader1["MaHoaDon"]);
                        tong = (int)sqlReader1["Gia"];
                    }
                    sqlReader1.Close();
                    SqlCommand cmd7 = new SqlCommand("SELECT SUM(GiaDichVu*SoLuong) as Gia FROM SuDungDichVu,DICHVU,KHACHHANG,HOADON WHERE SuDungDichVu.MaHoaDon=HOADON.MaHoaDon AND SuDungDichVu.MaDichVu = DICHVU.MaDichVu AND SuDungDichVu.MaKH = KHACHHANG.MaKH AND TinhTrangThanhToan = 0 AND HOADON.MaHoaDon = @mahd GROUP BY HOADON.MaHoaDon", DataAccessContext.connection);
                    cmd7.Parameters.Add("@mahd", mahd);
                    var sqlReader3 = cmd7.ExecuteReader();
                    while (sqlReader3.Read())
                    {
                        tong = tong + ((int)sqlReader3["Gia"]);
                    }
                    sqlReader3.Close();
                    SqlCommand cmd8 = new SqlCommand("SELECT SUM(GiaVatDung) as Gia FROM HOADON, PHONG, THUEPHONG, VATDUNG,KHACHHANG WHERE TinhTrang = N'hỏng' AND KHACHHANG.MaKH=THUEPHONG.MaKH AND VATDUNG.MaPhong=PHONG.MaPhong AND PHONG.MaPhong = THUEPHONG.MaPhong AND THUEPHONG.MaHoaDon = HOADON.MaHoaDon AND TinhTrangThanhToan = 0 AND HOADON.MaHoaDon = @mahd  GROUP BY HOADON.MaHoaDon", DataAccessContext.connection);
                    cmd8.Parameters.Add("@mahd", mahd);
                    var sqlReader8 = cmd8.ExecuteReader();

                    while (sqlReader8.Read())
                    {
                        tong = tong + ((int)sqlReader8["Gia"]);
                    }
                    sqlReader8.Close();
                    txbTongTien.Text = Convert.ToString(tong);
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
                    tong = 0;
                    string cmd1 = "SELECT TenPhong 'Tên Phòng',GiaThue 'Giá Thuê',TenLoai 'Loại Phòng',DatCoc 'Tiền Đặt Cọc',SoDem 'Số Đêm Thuê' FROM PHONG,LOAIPHONG,THUEPHONG,KHACHHANG,HOADON WHERE PHONG.MaPhong=THUEPHONG.MaPhong AND LOAIPHONG.MaLoai = PHONG.MaLoai AND THUEPHONG.MaKH = KHACHHANG.MaKH AND HOADON.MaHoaDon = THUEPHONG.MaHoaDon AND TinhTrangThanhToan = 0 AND HOADON.MaHoaDon =" + mahd;
                    DataAccessContext oop = new DataAccessContext();
                    DataTable dataTable = new DataTable();
                    oop.readDatathroughAdapter(cmd1, dataTable);
                    dGVThuePhong.DataSource = dataTable;

                    string cmd2 = "SELECT TENDV 'Tên dịch vụ',GiaDichVu 'Giá dịch vụ',SoLuong 'Số lượng' FROM SuDungDichVu,DICHVU,KHACHHANG,HOADON WHERE SuDungDichVu.MaHoaDon=HOADON.MaHoaDon AND SuDungDichVu.MaDichVu = DICHVU.MaDichVu AND SuDungDichVu.MaKH = KHACHHANG.MaKH AND TinhTrangThanhToan = 0 AND HOADON.MaHoaDon =" + mahd;
                    DataAccessContext oop1 = new DataAccessContext();
                    DataTable dataTable1 = new DataTable();
                    oop1.readDatathroughAdapter(cmd2, dataTable1);
                    dGVSuDungDV.DataSource = dataTable1;

                    string cmd3 = "SELECT TenVatDung 'Tên vật dụng',GiaVatDung 'Giá vật dụng' FROM HOADON, PHONG, THUEPHONG, VATDUNG,KHACHHANG WHERE TinhTrang = N'hỏng' AND KHACHHANG.MaKH=THUEPHONG.MaKH AND VATDUNG.MaPhong=PHONG.MaPhong AND PHONG.MaPhong = THUEPHONG.MaPhong AND THUEPHONG.MaHoaDon = HOADON.MaHoaDon AND TinhTrangThanhToan = 0 AND HOADON.MaHoaDon =" + mahd;
                    DataAccessContext oop2 = new DataAccessContext();
                    DataTable dataTable2 = new DataTable();
                    oop2.readDatathroughAdapter(cmd3, dataTable2);
                    dGVDenBu.DataSource = dataTable2;

                    tong = 0;
                    mahd = "";
                    makh = "";

                }

            }
         
            catch(SqlException)
            {
                dGVThuePhong.DataSource = null;
                dGVSuDungDV.DataSource = null;
                dGVDenBu.DataSource = null;
                txbTen.Text = "";
                txbSĐT.Text = "";
                XtraMessageBox.Show("Khách Hàng Đã Thanh Toán hoặc SĐT không tồn tại");
            }


        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            DataAccessContext db = new DataAccessContext();
          
            if (txbTongTien.Text.Equals("")!=true)
            {
                //Lấy maKH
                string _makh = "";
                SqlCommand cmd7 = new SqlCommand("select KHACHHANG.MaKH from KHACHHANG where SDT = @sdt", DataAccessContext.connection);
                cmd7.Parameters.Add("@sdt", txbSDT.Text);
                if (txbSDT.Text.Length != 0)
                {
                    var sqlReader = cmd7.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        _makh = Convert.ToString((int)sqlReader["MaKH"]);

                    }
                    sqlReader.Close();
                }

                    //Lấy maHD
                    string _mahd = "";
                    
                SqlCommand cmd4 = new SqlCommand("SELECT HOADON.MaHoaDon FROM PHONG,LOAIPHONG,THUEPHONG,KHACHHANG,HOADON WHERE PHONG.MaPhong=THUEPHONG.MaPhong AND LOAIPHONG.MaLoai = PHONG.MaLoai AND THUEPHONG.MaKH = KHACHHANG.MaKH AND HOADON.MaHoaDon = THUEPHONG.MaHoaDon AND TinhTrangThanhToan = 0 AND KHACHHANG.MaKH = @makh GROUP BY HOADON.MaHoaDon", DataAccessContext.connection);
                cmd4.Parameters.Add("@makh", _makh);
                var sqlReader1 = cmd4.ExecuteReader();
                while (sqlReader1.Read())
                {
                    _mahd = Convert.ToString((int)sqlReader1["MaHoaDon"]);
                }
                sqlReader1.Close();

                //Đưa tất cả TinhTrang các Phòng của hóa đơn này về 0
                SqlCommand cmd1 = new SqlCommand("UPDATE PHONG"+ 
                                 " set TrangThai = 0"+
                             " from PHONG p, THUEPHONG tp, HOADON hd"
                           +" WHERE hd.MaHoaDon = tp.MaHoaDon and p.MaPhong = tp.MaPhong"
                         +" and hd.TinhTrangThanhToan = 0 and hd.MaHoaDon = @hd ");
                cmd1.Parameters.Add("@hd", _mahd);
              

                //Đưa tất cả  TinhTrang các Vật dụng của hóa đơn này = 'Đã đền'
                SqlCommand cmd2 = new SqlCommand("UPDATE VATDUNG" 
                     + " set TinhTrang = N'Đã đền'"
                     + " from PHONG p, THUEPHONG tp, HOADON hd, VATDUNG vd"
                   + " WHERE hd.MaHoaDon = tp.MaHoaDon and p.MaPhong = tp.MaPhong and vd.MaPhong = p.MaPhong"
                      +" and hd.TinhTrangThanhToan = 0 and hd.MaHoaDon = @hd and vd.TinhTrang = N'hỏng'");
                cmd2.Parameters.Add("@hd", _mahd);
                

                //Đưa hóa đơn về TinhTrang đã thanh toán
                SqlCommand cmd = new SqlCommand("UPDATE HOADON SET TinhTrangThanhToan = 1 WHERE MaHoaDon = @hd ");
                cmd.Parameters.Add("@hd", _mahd);
                db.executeSelectQuery(cmd1);
                db.executeSelectQuery(cmd2);
                db.executeSelectQuery(cmd);
             
                XtraMessageBox.Show("Thanh toán thành công!");
            }
            else { XtraMessageBox.Show("Thanh toán thất b"); }
        }
    }
}
