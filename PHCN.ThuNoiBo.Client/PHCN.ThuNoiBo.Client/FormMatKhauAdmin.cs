using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHCN.ThuNoiBo.Client
{
    public partial class FormMatKhauAdmin : Form
    {

        public string matKhauQuanTri = "";
        public FormMatKhauAdmin()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (txtMatKhauQuanTri.Text != "123")
            {
                MessageBox.Show("Mật khẩu không đúng!");
                return;
            }
            matKhauQuanTri = txtMatKhauQuanTri.Text;
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            matKhauQuanTri = "";
            this.Close();
        }
    }
}
