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
    public partial class frmDichVu : DevExpress.XtraEditors.XtraUserControl
    {
        DataAccessContext dichvu = new DataAccessContext();
        DataTable dtService = new DataTable();

        string serviceId, name, price;

        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng gõ tiếng việt không dấu. Xin cảm ơn!!!", "Thông báo.");
            //Lấy danh sách thông tin dịch vụ vào bảng bên cạnh
            SqlDataAdapter da = new SqlDataAdapter("select top 1000 MaDichVu, TENDV, GiaDichVu from DICHVU", DataAccessContext.connection);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridViewService.DataSource = dt;
        }

        private void dataGridViewService_Click(object sender, EventArgs e)
        {
            //Lấy danh sách thông tin dịch vụ vào bảng bên cạnh
            SqlDataAdapter da = new SqlDataAdapter("select top 1000 MaDichVu, TENDV, GiaDichVu from DICHVU", DataAccessContext.connection);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridViewService.DataSource = dt;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //thêm thông tin dịch vụ ver 1.0 (chưa có kiểm tra thông tin)
            SqlCommand add = new SqlCommand("insert DICHVU values ('" + txbName.Text + "','" + txbPrice.Text + "')");
            if (txbName.Text != "" && txbPrice.Text != "")
            {
                MessageBox.Show("Thêm thành công. Vui lòng click vào bảng Dịch Vụ bên cạnh để cập nhật!!! ", "Thông báo.");
                dichvu.executeQuery(add);
            }
            else
                MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại!!!", "Lỗi.");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //chỉnh sửa thông tin dịch vụ theo MaDichVu
            if (txbName.Text != "" && txbPrice.Text != "")
            {
                name = txbName.Text;
                price = txbPrice.Text;

                SqlCommand edit = new SqlCommand("Update DICHVU set TENDV = '" + @name + "', GiaDichVu = '" + price + "' where MaDichVu = '" + txbID.Text + "'");
                if (dichvu.executeQuery(edit) != 0)
                    MessageBox.Show("Chỉnh sửa thành công. Vui lòng click vào bảng Dịch vụ bên cạnh để cập nhật!!! ", "Thông báo.");
                else
                    MessageBox.Show("Chỉnh sửa thất bại. Vui lòng kiểm tra lại!!!", "Lỗi.");
            }
            else
                MessageBox.Show("Chỉnh sửa thất bại. Vui lòng kiểm tra lại!!!", "Lỗi.");

        }

        private void label5_Click(object sender, EventArgs e)
        {
            txbID.Clear();
            txbName.Clear();
            txbPrice.Clear();
            dtService.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SqlCommand delete = new SqlCommand("delete from DICHVU where MaDichVu = '" + txbID.Text + "'");
            if (txbID.Text != "" && txbName.Text != "" && txbPrice.Text != "")
            {
                MessageBox.Show("Xóa thành công. Vui lòng click vào bảng Dịch vụ bên cạnh để cập nhật!!! ", "Thông báo.");
                dichvu.executeQuery(delete);
            }
            else
                MessageBox.Show("Xóa thất bại. Vui lòng kiểm tra lại!!!", "Lỗi.");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            txbName.Clear();
            txbPrice.Clear();

            //ấn nút tìm kiếm để lấy thông tin dịch vụ theo MaDichVu
            string search = "select * from DICHVU where MaDichVu = '" + txbID.Text + "'";
            dichvu.readDatathroughAdapter(search, dtService);
            if (dtService.Rows.Count != 0 && txbName.Text == "" && txbPrice.Text == "")
            {
                MessageBox.Show("Tìm kiếm thành công!!", "Thông báo.");

                //lấy thông tin Dịch vụ từ dtb
                name = dtService.Rows[0]["TENDV"].ToString();
                price = dtService.Rows[0]["GiaDichVu"].ToString();

                //hiện thông tin DichVu
                txbName.Text = name;
                txbPrice.Text = price;
            }
            else
            {
                MessageBox.Show("Tìm kiếm thất bại. Vui lòng kiểm tra lại!!", "Lỗi.");
            }
        }

    }
}
