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
<<<<<<< HEAD


            
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }


        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Activate the form.
            this.Show();


            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormClient_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible != true)
=======
            if (FormWindowState.Minimized == this.WindowState)
>>>>>>> parent of 7cc184d... 19/04/2018
            {
                notifyIconMain.Visible = true;
                notifyIconMain.BalloonTipTitle = "Bệnh viện Phục hồi chức năng Đồng Tháp";
                notifyIconMain.BalloonTipText = "Hệ thống thư nội bộ";
                notifyIconMain.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIconMain.Visible = false;
                this.Show();
                this.Activate();
            }

        }

<<<<<<< HEAD
        private void btnCapNhatCauHinh_Click(object sender, EventArgs e)

=======


        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
>>>>>>> parent of 7cc184d... 19/04/2018
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.Activate();
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
