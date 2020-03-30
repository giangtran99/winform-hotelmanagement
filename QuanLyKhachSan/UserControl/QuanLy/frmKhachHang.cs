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
        SqlCommandBuilder sqlCommand = null;

        SqlDataAdapter sqlAdapter = null;

        DataSet dataset = null;
        public void LoadData()
        {
            try
            {
                sqlAdapter = new SqlDataAdapter("SELECT MaKH 'Mã khách hàng', TenKH 'Họ và tên', SDT 'Số điện thoại' , 'Delete' AS [Thao tác] FROM KHACHHANG", DataAccessContext.connection);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);
                sqlAdapter.UpdateCommand = sqlCommand.GetUpdateCommand();
                sqlAdapter.DeleteCommand = sqlCommand.GetDeleteCommand();
                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "KHACHHANG");
                dGVTimKiem.DataSource = null;
                dGVTimKiem.DataSource = dataset.Tables["KHACHHANG"];
                for (int i = 0; i < dGVTimKiem.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dGVTimKiem[3, i] = linkCell;
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
                if (e.ColumnIndex == 3)
                {
                    string Task = dGVTimKiem.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGVTimKiem.Rows.RemoveAt(rowIndex);
                            dataset.Tables["KHACHHANG"].Rows[rowIndex].Delete();
                            sqlAdapter.Update(dataset, "KHACHHANG");
                        }
                    }
                    else
                    {
                        int r = e.RowIndex;
                        DataAccessContext dt = new DataAccessContext();
                        SqlCommand cmd = new SqlCommand("Update KHACHHANG SET TenKH = @TenKH, SDT = @SDT WHERE MaKH = @MaKH");
                        cmd.Parameters.Add("@MaKH", dGVTimKiem.Rows[r].Cells["Mã khách hàng"].Value);
                        cmd.Parameters.Add("@TenKH", dGVTimKiem.Rows[r].Cells["Họ và tên"].Value);
                        cmd.Parameters.Add("@SDT", dGVTimKiem.Rows[r].Cells["Số điện thoại"].Value);
                        dt.executeSelectQuery(cmd);
                        dGVTimKiem.Rows[e.RowIndex].Cells[3].Value = "Delete";
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
                dGVTimKiem[3, lastRow] = linkCell;
                nRow.Cells["Thao tác"].Value = "Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            string search = txbTimKiem.Text.Trim();
            DataAccessContext oop = new DataAccessContext();
            DataTable dataTable = new DataTable();

            oop.readDatathroughAdapter("SELECT MaKH 'Mã khách hàng', TenKH 'Họ và tên', SDT 'Số điện thoại' FROM KHACHHANG WHERE TenKH like N'%" + search + "%'  or SDT like '%" + search + "%' or MaKH like '%" + search + "%'", dataTable);
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

            oop.readDatathroughAdapter("SELECT MaKH 'Mã khách hàng', TenKH 'Họ và tên',  SDT 'Số điện thoại' FROM KHACHHANG", dataTable);
            dGVTimKiem.DataSource = dataTable;
        }
    }
}