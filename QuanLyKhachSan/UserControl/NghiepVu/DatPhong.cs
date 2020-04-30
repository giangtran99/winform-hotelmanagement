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
    public partial class DatPhong : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccessContext db = new DataAccessContext();
        public DatPhong()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from KHACHHANG where SDT = " + int.Parse(tbPhone.Text);
                object rs = db.executeSelectQuery(new SqlCommand(query));
                if (rs == null)
                {
                    query = "insert KHACHHANG(TenKH,SDT) values(N'" + tbName.Text + "','" + tbPhone.Text + "')";
                    db.executeQuery(new SqlCommand(query));


                }

                DateTime date = DateTime.Now;
                int maKh = 0, maHD = 0;
                query = "insert HOADON(NgayLapHoaDon,TinhTrangThanhToan,GhiChu) values('" + date.ToString().Split(' ')[0] + "',0,'" + date.ToString() + "')";
                db.executeQuery(new SqlCommand(query));

                query = "select * from KHACHHANG where SDT = '" + tbPhone.Text + "'";
              
                SqlConnection conn = new SqlConnection(db.GetStrConnect);
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    maKh = reader.GetInt32(0);
                }
                conn.Close();
                conn.Open();
                query = "select * from HOADON where GhiChu = '" + date.ToString() + "'";
                SqlCommand command2 = new SqlCommand(query, conn);
                SqlDataReader reader2 = command2.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader2.Read())
                {
                    maHD = reader2.GetInt32(0);
                }
                conn.Close();

                query = "select * from PHONG where MaPhong = '" + tbMaPhong.Text +"'";
                object rs3 = db.executeSelectQuery(new SqlCommand(query));
                if (rs3 == null)
                    throw new Exception("Không tồn tại phòng này. Vui lòng kiểm tra lại");
                query = "select * from PHONG where MaPhong = '" + tbMaPhong.Text + "' and TrangThai = 1";
                object rs2 = db.executeSelectQuery(new SqlCommand(query));
                if (rs2 != null)
                    throw new Exception("Phòng này đã được cho thuê. Vui lòng chọn phòng khác");

                query = "insert THUEPHONG(MaPhong,MaKH,MaHoaDon,NgayBatDauThue,NgayTraPhong,DatCoc,SoDem) values('" + tbMaPhong.Text + "'," + maKh + "," + maHD + ",'" + date.ToString().Split(' ')[0] + "','" + date.AddDays(int.Parse(tbSoDem.Value.ToString())).ToString().Split(' ')[0] + "'," + tbDatCoc.Text + "," + tbSoDem.Value + ")";
                db.executeQuery(new SqlCommand(query));
                query = "update PHONG set TrangThai = 1 where MaPhong = '"+tbMaPhong.Text+"'";
                db.executeQuery(new SqlCommand(query));
                XtraMessageBox.Show("Đặt phòng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
