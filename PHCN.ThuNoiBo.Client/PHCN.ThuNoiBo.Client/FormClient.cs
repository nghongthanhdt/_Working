using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PHCN.ThuNoiBo.Client
{

    public class UserLogin
    {
        public string TenDangNhap;
        public string MatKhau;
        public string HoTen;
        public string KhoaPhong;
    }

    public partial class FormClient : DevExpress.XtraEditors.XtraForm
    {

        DataTable dt = new DataTable();
        UserLogin userLogin = new UserLogin();

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
            // load file cấu hình đặt vào FormClient();

            txtConnectServer.Enabled = false;
            txtConnectUSerName.Enabled = false;
            txtConnectPassword.Enabled = false;
            txtAccountUserName.Enabled = false;
            txtAccountPassword.Enabled = false;
            checkboxAutoStart.Enabled = false;
            checkboxShowOnStart.Enabled = false;
            checkboxAutoGetMail.Enabled = false;
            txtAutoGetMailTimer.Enabled = false;
            btnCapNhatCauHinh.Text = "Cập nhật cấu hình";


            ClientConfig clientConfig = new ClientConfig();
            string path = "config.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            StreamReader reader = new StreamReader(path);
            clientConfig = (ClientConfig)serializer.Deserialize(reader);

            txtConnectServer.Text = clientConfig.ConnectServer;
            txtConnectUSerName.Text = clientConfig.ConnectUserName;
            txtConnectPassword.Text = clientConfig.ConnectPassword;
            txtAccountUserName.Text = clientConfig.AccountUserName;
            txtAccountPassword.Text = clientConfig.AccountPassword;
            checkboxAutoStart.Checked = clientConfig.AutoStart;
            checkboxShowOnStart.Checked = clientConfig.ShowOnStart;
            checkboxAutoGetMail.Checked = clientConfig.AutoGetMail;
            txtAutoGetMailTimer.Text = clientConfig.AutoGetMailTimer.ToString();

            reader.Close();


            // khóa các  text box
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

            bool login = false;

            string matKhauQuanTri = "";
            if (btnCapNhatCauHinh.Text == "Cập nhật cấu hình")
            {
                FormMatKhauAdmin f = new FormMatKhauAdmin();
                f.ShowDialog();
                matKhauQuanTri = f.matKhauQuanTri;
            } else
            {
                ClientConfig clientConfig = new ClientConfig();
                clientConfig.ConnectServer = txtConnectServer.Text;
                clientConfig.ConnectUserName = txtConnectUSerName.Text;
                clientConfig.ConnectPassword = txtConnectPassword.Text;
                clientConfig.AccountUserName = txtAccountUserName.Text;
                clientConfig.AccountPassword = txtAccountPassword.Text;
                clientConfig.AutoStart = checkboxAutoStart.Checked;
                clientConfig.ShowOnStart = checkboxShowOnStart.Checked;
                clientConfig.AutoGetMail = checkboxAutoGetMail.Checked;
                clientConfig.AutoGetMailTimer = int.Parse(txtAutoGetMailTimer.Text);



                // kết nối máy chủ

                string connectionString = "Data Source=" + txtConnectServer.Text + ";Initial Catalog=PHCN; User ID="+ txtConnectUSerName.Text + "; Password=" + txtConnectPassword.Text;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    
                    connection.Open();
                    //MessageBox.Show("Kết nối thành công!");                
                    
                    
                                  
                } catch (Exception ex)
                {
                    MessageBox.Show("Không thể kết nối đến máy chủ, vui lòng kiểm tra thông tin kết nối!");
                    return;
                }
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"select khoa.TenKhoa, nv.HoTen, nv.TenDangNhap, nv.MatKhau from NhanVien as nv
                                            inner join KhoaPhong as khoa on nv.MaKhoa = khoa.MaKhoa
                                            where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau";
                    cmd.Parameters.AddWithValue("@TenDangNhap", txtAccountUserName.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtAccountPassword.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !");
                        return;
                    } else
                    {


                        DataRow row = dt.Rows[0];
                        userLogin.TenDangNhap = row["TenDangNhap"].ToString();
                        userLogin.MatKhau = row["MatKhau"].ToString();
                        userLogin.HoTen = row["TenDangNhap"].ToString();
                        userLogin.KhoaPhong = row["TenKhoa"].ToString();

                        XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
                        serializer.Serialize(File.Create("config.xml"), clientConfig);


                        login = true;
                        MessageBox.Show("Kết nối thành công!");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                    return;
                }


                

            }



            // kiểm tra tài khoản
            if (matKhauQuanTri == "123")
            {
                txtConnectServer.Enabled = true;
                txtConnectUSerName.Enabled = true;
                txtConnectPassword.Enabled = true;
                txtAccountUserName.Enabled = true;
                txtAccountPassword.Enabled = true;
                checkboxAutoStart.Enabled = true;
                checkboxShowOnStart.Enabled = true;
                checkboxAutoGetMail.Enabled = true;
                txtAutoGetMailTimer.Enabled = true;
                btnCapNhatCauHinh.Text = "Lưu";
            }
            else
            {
                if (login == true)
                {
                    txtConnectServer.Enabled = false;
                    txtConnectUSerName.Enabled = false;
                    txtConnectPassword.Enabled = false;
                    txtAccountUserName.Enabled = false;
                    txtAccountPassword.Enabled = false;
                    checkboxAutoStart.Enabled = false;
                    checkboxShowOnStart.Enabled = false;
                    checkboxAutoGetMail.Enabled = false;
                    txtAutoGetMailTimer.Enabled = false;
                    btnCapNhatCauHinh.Text = "Cập nhật cấu hình";
                }


            }


        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtConnectServer.Enabled = false;
            txtConnectUSerName.Enabled = false;
            txtConnectPassword.Enabled = false;
            txtAccountUserName.Enabled = false;
            txtAccountPassword.Enabled = false;
            checkboxAutoStart.Enabled = false;
            checkboxShowOnStart.Enabled = false;
            checkboxAutoGetMail.Enabled = false;
            txtAutoGetMailTimer.Enabled = false;
            btnCapNhatCauHinh.Text = "Cập nhật cấu hình";

        }
    }
}
