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
using System.Data.SqlClient;

namespace QuanLyKhachSan.UserControl
{
    public partial class frmVatDung : DevExpress.XtraEditors.XtraUserControl
    {
        DAO.DataAccessContext db = new DAO.DataAccessContext();
        public frmVatDung()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RefeshList()
        {
            DataTable dttbLoad = new DataTable();
            string query = "Select * From VATDUNG";
            db.readDatathroughAdapter(query, dttbLoad);
            dgvVatDung.DataSource = dttbLoad;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "Select * From VATDUNG where MaPhong LIKE '%" + tbMaPhong.Text + "%'" +
                " and MaVatDung LIKE N'%" + tbMaVatDung.Text + "%'" +
                " and TinhTrang LIKE N'%" + tbTinhTrang.Text + "%'" +
                " and GiaVatDung LIKE N'%" + tbGia.Text + "%'" +
                " and TenVatDung LIKE N'%" + tbTenVatDung.Text + "%'";
                DataTable dttb = new DataTable();
                db.readDatathroughAdapter(query, dttb);
                dgvVatDung.DataSource = dttb;
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Xảy ra lỗi. Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVatDung_Load(object sender, EventArgs e)
        {
            DataTable dttbLoad = new DataTable();
            string query = "Select * From VATDUNG";
            db.readDatathroughAdapter(query, dttbLoad);
            dgvVatDung.DataSource = dttbLoad;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbMaPhong.Text == "" || tbTenVatDung.Text == "" || tbGia.Text == "" || tbTinhTrang.Text == "")
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin !");
                }
                string sql = "SELECT * FROM VATDUNG Where MaVatDung = '" + tbMaVatDung.Text + "' ";
                DataTable dttb = new DataTable();
                db.readDatathroughAdapter(sql, dttb);
                if (dttb.Rows.Count > 0)
                {
                    throw new Exception("Mã vật dụng đã tồn tại. Vui lòng thử lại !");
                }
                else
                {
                    string query = "Insert Into VATDUNG(TenVatDung,TinhTrang,GiaVatDung,MaPhong) values ('" +
                    tbTenVatDung.Text + "', '" + tbTinhTrang.Text + "', '" +
                    tbGia.Text + "','" + tbMaPhong.Text + "' )";
                    SqlCommand insertCom = new SqlCommand(query);
                    db.executeQuery(insertCom);
                    XtraMessageBox.Show("Thêm thông tin thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.RefeshList();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi trong quá trình thêm. Vui lòng thử lại !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVatDung.RowCount == 0)
                {
                    btnXoa.Enabled = false;
                }
                else if (XtraMessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Chỉ mục hiện tại
                    int selectIndex = dgvVatDung.SelectedRows[0].Index;
                    string MaVatDung = Convert.ToString(dgvVatDung[0, selectIndex].Value);
                    //query
                    string sql = "DELETE FROM VATDUNG Where MaVatDung = '" + MaVatDung + "' ;";
                    SqlCommand deteRow = new SqlCommand(sql);
                    db.executeQuery(deteRow);
                    //Remove khỏi datagird
                    dgvVatDung.Rows.RemoveAt(selectIndex);
                    //dgvXoaNV.DataSource = dttbLoad;
                    this.RefeshList();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand saveCom = new SqlCommand(@"UPDATE VATDUNG
                                       SET TenVatDung = @TenVatDung , 
                                            TinhTrang = @TinhTrang,
                                            GiaVatDung = @GiaVatDung,
                                            MaPhong = @MaPhong
                                        WHERE MaVatDung = @MaVatDung");
                saveCom.Parameters.Add("@MaVatDung", SqlDbType.Int).Value = 0;
                saveCom.Parameters.Add("@TenVatDung", SqlDbType.NVarChar).Value = "";
                saveCom.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = "";
                saveCom.Parameters.Add("@GiaVatDung", SqlDbType.Int).Value = 0;
                saveCom.Parameters.Add("@MaPhong", SqlDbType.Int).Value = 0;

                foreach (DataGridViewRow row in dgvVatDung.Rows)
                {
                    if (row.Cells["MaVatDung"].Value != null)
                    {
                        saveCom.Parameters["@MaVatDung"].Value = Convert.ToInt32(row.Cells["MaVatDung"].Value);
                        saveCom.Parameters["@TenVatDung"].Value = row.Cells["TenVatDung"].Value.ToString();
                        saveCom.Parameters["@TinhTrang"].Value = row.Cells["TinhTrang"].Value.ToString();
                        saveCom.Parameters["@GiaVatDung"].Value = Convert.ToInt32(row.Cells["GiaVatDung"].Value);
                        saveCom.Parameters["@MaPhong"].Value = Convert.ToInt32(row.Cells["MaPhong"].Value);
                        db.executeQuery(saveCom);
                    }

                }
                XtraMessageBox.Show("Lưu thông tin thành công !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.RefeshList();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại !", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
