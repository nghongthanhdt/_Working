using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHCN.ThuNoiBo.Client
{
    public partial class FormClient : DevExpress.XtraEditors.XtraForm
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabCauHinh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormClient_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIconMain.Visible = true;
                notifyIconMain.BalloonTipTitle = "Bệnh viện Phục hồi chức năng Đồng Tháp";
                notifyIconMain.BalloonTipText = "Hệ thống thư nội bộ";
                notifyIconMain.ShowBalloonTip(500);
                this.Hide();
            }            

        }



        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show(); //Hiển thị Form
            this.WindowState = FormWindowState.Normal; //Trở về trạng thái bình thường
            this.Activate();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }
    }
}
