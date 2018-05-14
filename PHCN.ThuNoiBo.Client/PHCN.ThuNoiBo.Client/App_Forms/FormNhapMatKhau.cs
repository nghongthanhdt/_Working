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

namespace PHCN.ThuNoiBo.Client.App_Forms
{
    public partial class FormNhapMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public FormNhapMatKhau()
        {
            InitializeComponent();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}