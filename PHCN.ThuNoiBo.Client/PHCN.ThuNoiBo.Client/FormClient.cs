
using Microsoft.Win32;
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
        DataTable dtThamSoHeThong = new DataTable();
        string _ConnnectionString = "";
        string _MaNhanVien = "0";
        int _SoThuMoi = 0;          
        public FormClient()
        {
            InitializeComponent();            
        }
        private void FormClient_Load(object sender, EventArgs e)
        {                         
            modeXemCauHinh();
            if (!kiemtraCauHinh())
            {
                modeChuaCauHinhKetNoi();
            }                     
            if (_MaNhanVien == "0") {
                timerLayThu.Enabled = false;
            } else
            {
                layThuMoi(_MaNhanVien);
                timerLayThu.Enabled = true;
                timerLayThu.Start();
            }                     
        }
        private string layThamSoHeThong(string maThamSo)
        {
            foreach (DataRow row in dtThamSoHeThong.Rows)
            {
                if (row["MaThamSo"].ToString() == maThamSo)
                {
                    string giaTri = row["GiaTri"].ToString();
                    return giaTri;                    
                }                 
            }
            return "[Không tìm thấy tham số]";
        }  
        private void loaddtThamSoHeThong(string connectionString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select * from ThamSoHeThong", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtThamSoHeThong);
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy tham số hệ thống: " + ex.Message);
            }
            
        }
        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
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
                notifyIconMain.BalloonTipTitle = layThamSoHeThong("tendonvi");
                notifyIconMain.BalloonTipText = layThamSoHeThong("tenhopthu");
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
            luuCauHinh();
            loadCauHinh();
            modeXemCauHinh();
        }
        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDenHopThu_Click(object sender, EventArgs e)
        {
            openLink(txtLinkHopThu.Text);
        }
        private void btnThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            loadCauHinh();
            modeXemCauHinh();
        }
        private void checkboxTienIch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxTienIch.Checked)
            {
                tabTienIch.PageVisible = true;
            } else
            {
                tabTienIch.PageVisible = false;
            }
        }
        private void loadCauHinh()
        {     
            ClientConfig clientConfig = new ClientConfig();
            string path = "config.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            try
            {
                StreamReader _reader = new StreamReader(path);
                _reader.Close();                
            }
            catch
            {
                XmlSerializer _serializer = new XmlSerializer(typeof(ClientConfig));
                var file = File.Create("config.xml");
                _serializer.Serialize(file, clientConfig);
                file.Close();    
                lblThongBao.Text = "Chưa cấu hình kết nối";
                btnDenHopThu.Enabled = false;  
            }
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
            _MaNhanVien = clientConfig.MaNhanVien;
            string md5Password = getMd5(txtAccountPassword.Text).ToLower();
            txtLinkHopThu.Text = "http://" + txtWebServer.Text + ((txtPort.Text != "") ? (":" + txtPort.Text) : "") + "/Home/ClientLogin/?TenDangNhap=" + txtAccountUserName.Text.ToLower() + "&MatKhau=" + md5Password;
            lblTenKhoa.Text = clientConfig.TenKhoa;
            lblHoTen.Text = clientConfig.HoTen;
            lblThongBao.Text = "Chưa có thư mới";
            lblThongBao.ForeColor = Color.Green;
            btnDenHopThu.Enabled = true;   
            if (clientConfig.AutoStart)  {
                setAutoStart();
            }
            else
            {
                unsetAutoStart();
            }      
            try
            {
                string thoigianlaythu = layThamSoHeThong("thoigianlaythu");
                int thoiGianLayThu = int.Parse(thoigianlaythu);
                timerLayThu.Interval = thoiGianLayThu * 1000;
            } catch
            {
                int thoiGianLayThu = clientConfig.AutoGetMailTimer;
                timerLayThu.Interval = thoiGianLayThu * 1000;
            } 
            statusBanQuyen.Text = layThamSoHeThong("banquyen");
            txtAutoGetMailTimer.Text = layThamSoHeThong("thoigianlaythu");
        }
        private bool validateFormCauHinh()
        {
            if (txtConnectServer.Text == "")
            {
                MessageBox.Show("Chưa nhập tên server kết nối");
                return false;
            }
            if (txtConnectUserName.Text == "")
            {
                MessageBox.Show("Chưa nhập tên đăng nhập kết nối");
                return false;
            }
            if (txtConnectPassword.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu kết nối");
                return false;
            }
            if (txtWebServer.Text == "")
            {
                MessageBox.Show("Chưa nhập tên web server");
                return false;
            }
            if (txtAccountUserName.Text == "")
            {
                MessageBox.Show("Chưa nhập tên đăng nhập tài khoản");
                return false;
            }
            if (txtAccountPassword.Text == "")
            {
                MessageBox.Show("Chưa mật khẩu tài khoản");
                return false;
            }

            return true;
        }
        private bool kiemtraCauHinh()
        {
            ClientConfig clientConfig = new ClientConfig();
            string path = "config.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            try
            {
                StreamReader _reader = new StreamReader(path);
                _reader.Close();
            }
            catch
            {
                XmlSerializer _serializer = new XmlSerializer(typeof(ClientConfig));
                var file = File.Create("config.xml");
                _serializer.Serialize(file, clientConfig);
                file.Close();
            }
            StreamReader reader = new StreamReader(path);
            clientConfig = (ClientConfig)serializer.Deserialize(reader);
            reader.Close();
            if (clientConfig.ConnectServer == "" || clientConfig.ConnectServer == null)
            {
                modeChuaCauHinhKetNoi();
                return false;
            }
            string connectionString = "Data Source=" + clientConfig.ConnectServer + ";Initial Catalog=PHCN; User ID=" + clientConfig.ConnectUserName + "; Password=" + clientConfig.ConnectPassword + "; Connection Timeout=5";            
            SqlConnection connection = new SqlConnection(connectionString);            
            try
            {
                connection.Open();
                loaddtThamSoHeThong(connectionString);
                _ConnnectionString = connectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ, vui lòng kiểm tra thông tin kết nối!");
                return false;
            } 
            try
            {   
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select khoa.TenKhoa, nv.HoTen, nv.TenDangNhap, nv.MatKhau, nv.NhanThu, nv.MaNhanVien from NhanVien as nv
                                            inner join KhoaPhong as khoa on nv.MaKhoa = khoa.MaKhoa
                                            where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau";
                cmd.Parameters.AddWithValue("@TenDangNhap", clientConfig.AccountUserName);
                cmd.Parameters.AddWithValue("@MatKhau", clientConfig.AccountPassword);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu người dùng không đúng !");
                    return false;
                }
                else
                {
                    DataRow row = dt.Rows[0];
                    if (row["NhanThu"].ToString().ToLower() == "false")
                    {
                        MessageBox.Show("Tài khoản \"" + row["HoTen"] + "\" không được phép nhận thư, vui lòng liên hệ quản trị.");
                        return false;
                    }
                }
                loadCauHinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return false;
            }
            connection.Close();
            return true;
        }   
        private void modeChuaCauHinhKetNoi()
        {
            lblTenKhoa.Text = "";
            lblHoTen.Text = "";
            lblThongBao.Text = "";
            btnDenHopThu.Enabled = false;
            statusBanQuyen.Text = "Chưa cấu hình kết nối";
        }      
        private void luuCauHinh()
        {
            if (validateFormCauHinh() == false)
            {
                return;
            }
            dt = new DataTable();
            ClientConfig clientConfig = new ClientConfig();
            clientConfig.ConnectServer = txtConnectServer.Text;
            clientConfig.ConnectUserName = txtConnectUserName.Text;
            clientConfig.ConnectPassword = txtConnectPassword.Text;
            clientConfig.AccountUserName = txtAccountUserName.Text;
            clientConfig.AccountPassword = txtAccountPassword.Text;
            clientConfig.AutoStart = checkboxAutoStart.Checked;
            clientConfig.ShowOnStart = checkboxShowOnStart.Checked;
            clientConfig.AutoGetMail = checkboxAutoGetMail.Checked;
            clientConfig.AutoGetMailTimer = int.Parse(txtAutoGetMailTimer.Text);
            clientConfig.WebServer = txtWebServer.Text;
            clientConfig.Port = txtPort.Text;
            string md5Password = getMd5(txtAccountPassword.Text).ToLower();
            string connectionString = "Data Source=" + clientConfig.ConnectServer + ";Initial Catalog=PHCN; User ID=" + clientConfig.ConnectUserName + "; Password=" + clientConfig.ConnectPassword + "; Connection Timeout=3";
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
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select khoa.TenKhoa, nv.HoTen, nv.TenDangNhap, nv.MatKhau, nv.MaNhanVien, nv.NhanThu from NhanVien as nv
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
                        MessageBox.Show("Tài khoản \"" + row["HoTen"] + "\" không được phép nhận thư, vui lòng liên hệ quản trị.");
                        return;
                    }
                    clientConfig.AccountUserName = row["TenDangNhap"].ToString();
                    clientConfig.AccountPassword = row["MatKhau"].ToString();
                    clientConfig.HoTen = row["HoTen"].ToString();
                    clientConfig.TenKhoa = row["TenKhoa"].ToString();
                    clientConfig.MaNhanVien = row["MaNhanVien"].ToString();
                    XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
                    try
                    {
                        var file = File.Create("config.xml");
                        serializer.Serialize(file, clientConfig);
                        file.Close();
                    }
                    catch (Exception ex){
                        MessageBox.Show(ex.Message);
                    };  
                    MessageBox.Show("Chào mừng " + clientConfig.HoTen + ", kết nối thành công!");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return;
            }
            connection.Close();
        }
        private void openLink(string sUrl)
        {
            try
            {
                System.Diagnostics.Process.Start(sUrl);
            }
            catch (Exception exc1)
            {
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
        static string getMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
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
            checkboxAutoStart.Enabled = true;
            checkboxShowOnStart.Enabled = true;
            checkboxAutoGetMail.Enabled = true;
            txtAutoGetMailTimer.Enabled = true;
            btnCapNhatCauHinh.Enabled = false;
            btnLuuCauHinh.Enabled = true;
            btnBoQua.Enabled = true;
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
        }      
        private int layThuMoi(string maNhanVien)
        {
              
            try
            {
                SqlConnection conn = new SqlConnection(_ConnnectionString);
                string query = "select * from GuiNhan where NguoiNhan = " + maNhanVien + " and DaXem = 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable _dt = new DataTable();
                    adapter.Fill(_dt);
                    int count = _dt.Rows.Count;
                    if (count > 0)
                    {
                        lblThongBao.ForeColor = Color.Red;
                        lblThongBao.Text = "Bạn có " + count + " thư mới";

                        return count;
                    }
                    else
                    {
                        lblThongBao.ForeColor = Color.Green;
                        lblThongBao.Text = "";
                    }

                }
                
            }
            catch 
            {
                showBalloonKhongTheKetNoiDenMayChu();
                timerLayThu.Stop();
            }

            return 0;

        }
        private void timerLayThu_Tick(object sender, EventArgs e)
        {
            timerLayThu.Enabled = false;
            int count = layThuMoi(_MaNhanVien);
            if (count != _SoThuMoi && count > 0)
            {
                notifyIconMain.Visible = true;
                notifyIconMain.BalloonTipTitle = layThamSoHeThong("tenhopthu");
                notifyIconMain.BalloonTipText = "Bạn có " + count + " thư mới !"; 
                notifyIconMain.ShowBalloonTip(500);
            }
            _SoThuMoi = count;
            timerLayThu.Enabled = true;
        }   
        private void setAutoStart()
        {                                                              
            string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            string StartupValue = "PHCN.ThuNoiBo.Client";  
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.SetValue(StartupValue, Application.ExecutablePath.ToString());        
        }
        private void unsetAutoStart()
        {
            string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            string StartupValue = "PHCN.ThuNoiBo.Client";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.DeleteValue(StartupValue);
        }                               
        private void showBalloonKhongTheKetNoiDenMayChu()
        {
            notifyIconMain.Visible = true;
            notifyIconMain.BalloonTipTitle = "Hệ thống nội bộ";
            notifyIconMain.BalloonTipText = "Không thể kết nối đến máy chủ, vui lòng liên hệ quản trị";
            notifyIconMain.ShowBalloonTip(500);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            const string message = "Bạn muốn thoát chương trình ?";
            const string caption = "Hệ thống nội bộ";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Environment.Exit(0);
            

            e.Cancel = (result == DialogResult.No);
        }

    }

}
