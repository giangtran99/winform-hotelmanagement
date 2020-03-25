using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyKhachSan.DAO;

namespace QuanLyKhachSan
{
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        DataAccessContext db = new DataAccessContext();
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}