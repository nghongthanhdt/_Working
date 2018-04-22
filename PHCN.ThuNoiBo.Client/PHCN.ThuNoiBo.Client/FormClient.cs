using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PHCN.ThuNoiBo.Client
{



    public partial class FormClient : DevExpress.XtraEditors.XtraForm
    {

        DataTable dt = new DataTable();

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
            
            modeXemCauHinh();
        }
        private void modeXemCauHinh()
        {
            txtConnectServer.Enabled = false;
            txtConnectUserName.Enabled = false;
            txtConnectPassword.Enabled = false;
            txtAccountUserName.Enabled = false;
            txtAccountPassword.Enabled = false;
            checkboxAutoStart.Enabled = false;
            checkboxShowOnStart.Enabled = false;
            checkboxAutoGetMail.Enabled = false;
            txtAutoGetMailTimer.Enabled = false;
            txtWebServer.Enabled = false;
            txtPort.Enabled = false;
            checkboxAutoStart.Enabled = false;
            checkboxShowOnStart.Enabled = false;
            checkboxAutoGetMail.Enabled = false;
            txtAutoGetMailTimer.Enabled = false;
            btnCapNhatCauHinh.Enabled = true;
            btnLuuCauHinh.Enabled = false;
            btnBoQua.Enabled = false;

            ClientConfig clientConfig = new ClientConfig();
            string path = "config.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            StreamReader reader = new StreamReader(path);
            clientConfig = (ClientConfig)serializer.Deserialize(reader);
            reader.Close();
            txtConnectServer.Text = clientConfig.ConnectServer;
            txtConnectUserName.Text = clientConfig.ConnectUserName;
            txtConnectPassword.Text = clientConfig.ConnectPassword;
            txtAccountUserName.Text = clientConfig.AccountUserName;
            txtAccountPassword.Text = clientConfig.AccountPassword;
            checkboxAutoStart.Checked = clientConfig.AutoStart;
            checkboxShowOnStart.Checked = clientConfig.ShowOnStart;
            checkboxAutoGetMail.Checked = clientConfig.AutoGetMail;
            txtAutoGetMailTimer.Text = clientConfig.AutoGetMailTimer.ToString();
            txtWebServer.Text = clientConfig.WebServer;
            txtPort.Text = clientConfig.Port;

            txtHoTen.Text = clientConfig.HoTen;
            txtTenKhoa.Text = clientConfig.TenKhoa;
            string md5Password = GetMd5(txtAccountPassword.Text).ToLower();
            txtLinkHopThu.Text = "http://" + txtWebServer.Text + ((txtPort.Text != "") ? (":" + txtPort.Text) : "") + "/ClientLogin/?TenDangNhap=" + txtAccountUserName.Text.ToLower() + "&MatKhau=" + md5Password;
            loadThongTinSauKhiDangNhap(clientConfig);
            
        }
        private void modeCapNhatCauHinh()
        {
            txtConnectServer.Enabled = true;
            txtConnectUserName.Enabled = true;
            txtConnectPassword.Enabled = true;
            txtAccountUserName.Enabled = true;
            txtAccountPassword.Enabled = true;
            checkboxAutoStart.Enabled = true;
            checkboxShowOnStart.Enabled = true;
            checkboxAutoGetMail.Enabled = true;
            txtAutoGetMailTimer.Enabled = true;
            txtWebServer.Enabled = true;
            txtPort.Enabled = true;
            btnLuuCauHinh.Enabled = true;
            btnCapNhatCauHinh.Enabled = false;
            btnBoQua.Enabled = true;
        }

        private void loadThongTinSauKhiDangNhap(ClientConfig clientConfig)
        {
            
            
            lblTenKhoa.Text = clientConfig.TenKhoa;
            lblHoTen.Text = clientConfig.HoTen;
            lblThongBao.Text = "Chưa có thư mới";
            lblThongBao.ForeColor = Color.Green;
            
            
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


            modeCapNhatCauHinh();
            
        }

        private void menuHienThu_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            bool login = false;
            ClientConfig clientConfig = new ClientConfig();
            clientConfig.ConnectServer = txtConnectServer.Text;
            clientConfig.ConnectUserName = txtConnectUserName.Text;
            clientConfig.ConnectPassword = txtConnectPassword.Text;
            clientConfig.AccountUserName = txtAccountUserName.Text;
            clientConfig.AccountPassword = txtAccountPassword.Text;
            clientConfig.AutoStart = checkboxShowOnStart.Checked;
            clientConfig.ShowOnStart = checkboxShowOnStart.Checked;
            clientConfig.AutoGetMail = checkboxAutoGetMail.Checked;
            clientConfig.AutoGetMailTimer = int.Parse(txtAutoGetMailTimer.Text);
            clientConfig.WebServer = txtWebServer.Text;
            clientConfig.Port = txtPort.Text;

            
            string md5Password = GetMd5(txtAccountPassword.Text).ToLower();
            // kết nối máy chủ

            // kết nối máy chủ

            string connectionString = "Data Source=" + clientConfig.ConnectServer+ ";Initial Catalog=PHCN; User ID=" + clientConfig.ConnectUserName + "; Password=" + clientConfig.ConnectPassword;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ, vui lòng kiểm tra thông tin kết nối!");
                return;
            }
            try
            {
                
                UserLogin userLogin = new UserLogin();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select khoa.TenKhoa, nv.HoTen, nv.TenDangNhap, nv.MatKhau, nv.NhanThu from NhanVien as nv
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
                }
                else
                {
                    DataRow row = dt.Rows[0];
                    if (row["NhanThu"].ToString().ToLower() == "false")
                    {
                        MessageBox.Show("Tài khoản \""+row["HoTen"]+"\" không được phép nhận thư, vui lòng liên hệ quản trị.");
                        return;
                    }
                    
                    userLogin.TenDangNhap = row["TenDangNhap"].ToString();
                    userLogin.MatKhau = row["MatKhau"].ToString();
                    userLogin.HoTen = row["HoTen"].ToString();
                    userLogin.KhoaPhong = row["TenKhoa"].ToString();

                    clientConfig.AccountUserName = row["TenDangNhap"].ToString();
                    clientConfig.AccountPassword = row["MatKhau"].ToString();
                    clientConfig.HoTen = row["HoTen"].ToString();
                    clientConfig.TenKhoa = row["TenKhoa"].ToString();
                    XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
                    var file = File.Create("config.xml");
                    serializer.Serialize(file, clientConfig);                    
                    file.Close();
                    
                    login = true;                    
                    MessageBox.Show("Chào mừng "+clientConfig.HoTen+", kết nối thành công!");
                    modeXemCauHinh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return;
            }

            connection.Close();
            // kiểm tra tài khoản

            
            
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static string GetMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void btnDenHopThu_Click(object sender, EventArgs e)
        {
            OpenLink(txtLinkHopThu.Text);
        }

        private void OpenLink(string sUrl)
        {
            try
            {
                System.Diagnostics.Process.Start(sUrl);
            }
            catch (Exception exc1)
            {
                // System.ComponentModel.Win32Exception is a known exception that occurs when Firefox is default browser.            // It actually opens the browser but STILL throws this exception so we can just ignore it.  If not this exception,
                // then attempt to open the URL in IE instead.
                if (exc1.GetType().ToString() != "System.ComponentModel.Win32Exception")
                {
                    MessageBox.Show("Lỗi hệ thống: " + exc1.Message);
                    try
                    {
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("IExplore.exe", sUrl);
                        System.Diagnostics.Process.Start(startInfo);
                        startInfo = null;
                    }
                    catch (Exception exc2)
                    {                        
                        MessageBox.Show("Lỗi hệ thống: " + exc2.Message);
                    }
                }
            }
        }

        private void btnThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            modeXemCauHinh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    public class UserLogin
    {
        public string TenDangNhap;
        public string MatKhau;
        public string HoTen;
        public string KhoaPhong;
    }
}
