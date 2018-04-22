using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

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



        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {



            
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
            {
                notifyIconMain.Visible = true;
                notifyIconMain.BalloonTipTitle = "Bệnh viện Phục hồi chức năng Đồng Tháp";
                notifyIconMain.BalloonTipText = "Hệ thống thư nội bộ";
                notifyIconMain.ShowBalloonTip(500);
            }
            


        }

        private void btnCapNhatCauHinh_Click(object sender, EventArgs e)
        {

            ClientConfig clientConfig = new ClientConfig();
            clientConfig.ConnectServer = txtConnectServer.Text;
            clientConfig.ConnectUserName = txtConnectUSerName.Text;
            clientConfig.ConnectPassword = txtConnectPassword.Text;
            clientConfig.AccountUserName = txtAccountUserName.Text;
            clientConfig.AccountPassword = txtAccountPassword.Text;
            clientConfig.AutoStart = checkboxShowOnStart.Checked;
            clientConfig.ShowOnStart = checkboxShowOnStart.Checked;
            clientConfig.AutoGetMail = checkboxAutoGetMail.Checked;
            clientConfig.AutoGetMailTimer = int.Parse(txtAutoGetMailTimer.Text);

            // kết nối máy chủ
            // kiểm tra tài khoản

            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            serializer.Serialize(File.Create("config.xml"), clientConfig);
            
        }
    }
}
