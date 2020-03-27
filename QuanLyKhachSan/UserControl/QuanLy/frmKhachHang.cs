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
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraUserControl
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void TextBoxTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }
        SqlCommandBuilder sqlCommand = null;

        SqlDataAdapter sqlAdapter = null;

        DataSet dataset = null;
        public void LoadData()
        {
            try
            {
                sqlAdapter = new SqlDataAdapter("SELECT MaNV 'Mã nhân viên', HoTen 'Họ và tên', NgaySinh 'Ngày sinh', GioiTinh 'Giới tính', SDT 'Số điện thoại' , 'Delete' AS [Thao tác] FROM NHANVIEN", DataAccessContext.connection);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);
                sqlAdapter.UpdateCommand = sqlCommand.GetUpdateCommand();
                sqlAdapter.DeleteCommand = sqlCommand.GetDeleteCommand();
                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "NHANVIEN");
                dGVTimKiem.DataSource = null;
                dGVTimKiem.DataSource = dataset.Tables["NHANVIEN"];
                for (int i = 0; i < dGVTimKiem.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dGVTimKiem[5, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dGVTimKiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string Task = dGVTimKiem.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGVTimKiem.Rows.RemoveAt(rowIndex);
                            dataset.Tables["NHANVIEN"].Rows[rowIndex].Delete();
                            sqlAdapter.Update(dataset, "NHANVIEN");
                        }
                    }
                    else
                    {
                        int r = e.RowIndex;
                        DataAccessContext dt = new DataAccessContext();
                        SqlCommand cmd = new SqlCommand("Update NHANVIEN SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SDT = @SDT WHERE MaNV = @MaNV");
                        cmd.Parameters.Add("@MaNV", dGVTimKiem.Rows[r].Cells["Mã nhân viên"].Value);
                        cmd.Parameters.Add("@HoTen", dGVTimKiem.Rows[r].Cells["Họ và tên"].Value);
                        cmd.Parameters.Add("@NgaySinh", dGVTimKiem.Rows[r].Cells["Ngày sinh"].Value);
                        cmd.Parameters.Add("@GioiTinh", dGVTimKiem.Rows[r].Cells["Giới tính"].Value);
                        cmd.Parameters.Add("@SDT", dGVTimKiem.Rows[r].Cells["Số điện thoại"].Value);
                        dt.executeSelectQuery(cmd);
                        dGVTimKiem.Rows[e.RowIndex].Cells[5].Value = "Delete";
                        MessageBox.Show("Đã cập nhật thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dGVTimKiem_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int lastRow = e.RowIndex;
                DataGridViewRow nRow = dGVTimKiem.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dGVTimKiem[5, lastRow] = linkCell;
                nRow.Cells["Thao tác"].Value = "Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void XtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            string search = txbTimKiem.Text.Trim();
            DataAccessContext oop = new DataAccessContext();
            DataTable dataTable = new DataTable();

            oop.readDatathroughAdapter("SELECT MaNV 'Mã nhân viên', HoTen 'Họ và tên', NgaySinh 'Ngày sinh', GioiTinh 'Giới tính', SDT 'Số điện thoại' FROM NHANVIEN WHERE HoTen like N'%" + search + "%' or GioiTinh like N'%" + search + "%' or SDT like '%" + search + "%'", dataTable);
            dGVTimKiem.DataSource = dataTable;
        }

        private void XtraTabPage2_Paint_1(object sender, PaintEventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void XtraTabPage1_Paint(object sender, PaintEventArgs e)
        {
            DataAccessContext oop = new DataAccessContext();
            DataTable dataTable = new DataTable();

            oop.readDatathroughAdapter("SELECT MaNV 'Mã nhân viên', HoTen 'Họ và tên', NgaySinh 'Ngày sinh', GioiTinh 'Giới tính', SDT 'Số điện thoại' FROM NHANVIEN", dataTable);
            dGVTimKiem.DataSource = dataTable;
        }
    }
}