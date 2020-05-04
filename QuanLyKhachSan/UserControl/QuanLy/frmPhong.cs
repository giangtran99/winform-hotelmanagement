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
using DevExpress.XtraRichEdit.Model;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace QuanLyKhachSan.UserControl.QuanLy
{
    public partial class frmPhong : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccessContext db = new DataAccessContext();
        public frmPhong()
        {
            InitializeComponent();
        }
        void Showlist(string query)
        {
            dgvPhong.DataSource = null;
            DataTable dt = new DataTable();
            db.readDatathroughAdapter(query, dt);
            dgvPhong.DataSource = dt;
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {

            Showlist("select p.TenPhong,p.MaPhong,lp.TenLoai,lp.GiaThue,p.TrangThai,lp.MaLoai from Phong p , LoaiPhong lp where  p.MaLoai = lp.MaLoai");
            cbxTrangThai.Properties.Items.Add("Trống");
            cbxTrangThai.Properties.Items.Add("Có Khách");
            SqlCommand cmd = new SqlCommand("select * from LoaiPhong ", DataAccessContext.connection);
            var read = cmd.ExecuteReader();
            while (read.Read())
            {
                cbxLoaiPhong.Properties.Items.Add(read[1]);
            }
            read.Close();


        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {


            if (cbxTrangThai.Text.Length == 0)
            {
                if (cbxLoaiPhong.Text.Length == 0)
                {
                    if (txtMaPhong.Text.Length == 0)
                        Showlist("select p.TenPhong,p.MaPhong,lp.TenLoai,lp.GiaThue,p.TrangThai,lp.MaLoai from Phong p , LoaiPhong lp where  p.MaLoai = lp.MaLoai");
                    else
                        Showlist("select p.TenPhong,p.MaPhong,lp.TenLoai,lp.GiaThue,p.TrangThai,lp.MaLoai from Phong p , LoaiPhong lp where  p.MaLoai = lp.MaLoai and p.MaPhong = " + txtMaPhong.Text);

                }
                else
                {

                    string query = " select * from Phong p , LoaiPhong lp where  p.MaLoai = lp.MaLoai and lp.TenLoai like N'" + cbxLoaiPhong.Text + "%'  ";
                    DataTable dt = new DataTable();
                    db.readDatathroughAdapter(query, dt);
                    dgvPhong.DataSource = dt;
                }
            }
            else
            {

                int Status = cbxTrangThai.Text.Equals("Có Khách") ? Status = 1 : Status = 0;
                string query = "  select * from Phong p , LoaiPhong lp where  p.MaLoai = lp.MaLoai and p.TrangThai like '" + Status + "' and lp.TenLoai like N'%" + cbxLoaiPhong.Text + "%'  ";
                DataTable dt = new DataTable();
                db.readDatathroughAdapter(query, dt);
                dgvPhong.DataSource = dt;

            }
            cbxLoaiPhong.Text = "";
            cbxTrangThai.Text = "";
            txtMaPhong.Text = "";

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            SqlCommand saveCom = new SqlCommand(@"UPDATE PHONG
                                       SET MaLoai = @MaLoai ,
                                       TenPhong = @TenPhong
                                        WHERE MaPhong= @MaP", DataAccessContext.connection);

            saveCom.Parameters.Add("@MaLoai", SqlDbType.NVarChar).Value = "";
            saveCom.Parameters.Add("@MaP", SqlDbType.VarChar).Value = "";
            saveCom.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = "";


            int i = 0;
            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                i++;
                if (i <= dgvPhong.Rows.Count - 1)
                {
                    saveCom.Parameters["@MaP"].Value = row.Cells["MaPhong"].Value.ToString();
                    saveCom.Parameters["@MaLoai"].Value = row.Cells["MaLoai"].Value.ToString();
                    saveCom.Parameters["@TenPhong"].Value = row.Cells["TenPhong"].Value.ToString();
                    db.executeQuery(saveCom);
                }

            }
            Showlist("select p.TenPhong,p.MaPhong,lp.TenLoai,lp.GiaThue,p.TrangThai,lp.MaLoai from Phong p ,LoaiPhong lp where  p.MaLoai = lp.MaLoai");
            XtraMessageBox.Show("Lưu thành công");



        }
    }
}
