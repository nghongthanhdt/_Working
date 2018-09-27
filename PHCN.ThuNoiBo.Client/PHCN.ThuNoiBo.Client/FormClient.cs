
using Microsoft.Win32;
using PHCN.ThuNoiBo.Client.App_Forms;
using PHCN.ThuNoiBo.Client.Controller;
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
        string _PathConFig = @"C:\configThuNoiBo.xml";
        
        int _macdinhThoiGianLayThu = 10000; // 10 giây
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
                timerLayThu.Stop();
                timerLayThu.Enabled = false;
            } else
            {
                loadCauHinh();
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
            txtConnectServer.Focus();
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
            const string message = "Bạn muốn thoát chương trình ?";
            const string caption = "Hệ thống nội bộ";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }
        private void btnDenHopThu_Click(object sender, EventArgs e)
        {
            openLink(txtLinkHopThu.Text);
        }
        private void btnThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            const string message = "Bạn muốn thoát chương trình ?";
            const string caption = "Hệ thống nội bộ";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();

        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            loadCauHinh();
            modeXemCauHinh();
        }

        private void loadCauHinh()
        {     
            // đọc file cấu hình, lấy thông tin load lên các control
            ClientConfig clientConfig = new ClientConfig();
            
            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            try
            {
                // kiểm tra xem có tồn tại file không 
                StreamReader _reader = new StreamReader(_PathConFig);
                _reader.Close();                
            }
            catch
            {
                // nếu không có thì tạo file mới
                XmlSerializer _serializer = new XmlSerializer(typeof(ClientConfig));
                var file = File.Create(_PathConFig);
                _serializer.Serialize(file, clientConfig);
                file.Close();    
                lblThongBao.Text = "Chưa cấu hình kết nối";
                statusBanQuyen.Text = "";
                btnDenHopThu.Enabled = false;  
            }
            // đọc và giải mã file cấu hình
            StreamReader reader = new StreamReader(_PathConFig);
            clientConfig = (ClientConfig)serializer.Deserialize(reader);
            reader.Close();
            // gắn clientConfig vào các control
            txtConnectServer.Text = clientConfig.ConnectServer;
            txtConnectUserName.Text = clientConfig.ConnectUserName;
            txtConnectPassword.Text = clientConfig.ConnectPassword;
            txtAccountUserName.Text = clientConfig.AccountUserName;
            txtAccountPassword.Text = clientConfig.AccountPassword;

            txtWebServer.Text = clientConfig.WebServer;
            txtPort.Text = clientConfig.Port;
            txtDatabase.Text = clientConfig.Database;
            txtHoTen.Text = clientConfig.HoTen;
            txtTenKhoa.Text = clientConfig.TenKhoa;
            _MaNhanVien = clientConfig.MaNhanVien;
            // ví dụ tên đăng nhập là nhthanh thì pass md5 là hongthanh_nhthanh ->> md5code
            string md5AccountUserName = getMd5(txtAccountUserName.Text).ToLower();
            txtLinkHopThu.Text = "http://" + txtWebServer.Text + ((txtPort.Text != "") ? (":" + txtPort.Text) : "") + "/Home/ClientLogin/?TenDangNhap=" + txtAccountUserName.Text.ToLower() + "&MatKhau=" + md5AccountUserName;
            lblTenKhoa.Text = clientConfig.TenKhoa;
            lblHoTen.Text = clientConfig.HoTen;
            lblThongBao.Text = "";
            lblThongBao.ForeColor = Color.Green;
            btnDenHopThu.Enabled = true;
            setAutoStart();      
            try
            {
                string thoigianlaythu = layThamSoHeThong("thoigianlaythu");
                int thoiGianLayThu = int.Parse(thoigianlaythu);
                timerLayThu.Interval = thoiGianLayThu * 1000;
            } catch
            {
                timerLayThu.Interval = _macdinhThoiGianLayThu;
            } 
            statusBanQuyen.Text = layThamSoHeThong("banquyen");
            

            // load danh sách khoa phòng vào select khoa phòng
            if (_ConnnectionString != "")
            {
                try
                {
                    SqlConnection connection = new SqlConnection(_ConnnectionString);
                    string query = "select * from KhoaPhong where Xoa = 0 order by STT";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        selectKhoaPhong.Properties.DataSource = dt;                        
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
                
            }
            
        }
        private bool validateFormCauHinh()
        {
            //kiểm tra hợp lệ khi lưu cấu hình
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
            if (txtDatabase.Text == "")
            {
                MessageBox.Show("Chưa nhập tên database");
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
            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            try
            {
                // kiểm tra file cấu hình có tồn tại không
                StreamReader _reader = new StreamReader(_PathConFig);
                _reader.Close();
            }
            catch (Exception ex)
            {
                // nếu chưa thấy file cấu hình thì tạo file xml mới có cấu trúc là client Config
                MessageBox.Show(ex.Message);
                XmlSerializer _serializer = new XmlSerializer(typeof(ClientConfig));
                var file = File.Create(_PathConFig);
                _serializer.Serialize(file, clientConfig);
                file.Close();
            }
            // bắt đầu đọc file config, gắn về clientConfig
            StreamReader reader = new StreamReader(_PathConFig);
            clientConfig = (ClientConfig)serializer.Deserialize(reader);
            reader.Close();

            if (clientConfig.ConnectServer == "" || clientConfig.ConnectServer == null)
            {
                MessageBox.Show("Chưa cấu hình kết nối !");
                modeChuaCauHinhKetNoi();
                return false;
            }
            string connectionString = "Data Source=" + clientConfig.ConnectServer + ";Initial Catalog="+clientConfig.Database+"; User ID=" + clientConfig.ConnectUserName + "; Password=" + clientConfig.ConnectPassword + "; Connection Timeout=5";            
            SqlConnection connection = new SqlConnection(connectionString);            
            try
            {
                connection.Open();
                loaddtThamSoHeThong(connectionString);
                _ConnnectionString = connectionString;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến SQL, vui lòng kiểm tra thông tin kết nối!");
                return false;
            } 
            try
            {   
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select khoa.TenKhoa, nv.HoTen, nv.TenDangNhap, nv.MatKhau, nv.NhanThu, nv.MaNhanVien from NhanVien as nv
                                            inner join KhoaPhong as khoa on nv.MaKhoa = khoa.MaKhoa
                                            where TenDangNhap = @TenDangNhap";
                cmd.Parameters.AddWithValue("@TenDangNhap", clientConfig.AccountUserName);                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tên tài khoản không đúng!");
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

                    // set configThuNoiBo cho mật khẩu mới được đổi
                    try
                    {
                        reader = new StreamReader(_PathConFig);
                        clientConfig = (ClientConfig)serializer.Deserialize(reader);
                        reader.Close();
                        clientConfig.AccountPassword = row["MatKhau"].ToString();
                        var file = File.Create(_PathConFig);
                        serializer.Serialize(file, clientConfig);
                        file.Close();
                    } catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu mật khẩu mới: " + ex.Message);
                    }
                    

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return false;
            }
            connection.Close();
            reader.Close();
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
            clientConfig.Database = txtDatabase.Text;
            clientConfig.AutoStart = true;
            clientConfig.ShowOnStart = true;
            clientConfig.AutoGetMail = true;
            clientConfig.AutoGetMailTimer = 15;
            clientConfig.WebServer = txtWebServer.Text;
            clientConfig.Port = txtPort.Text;
            string md5Password = getMd5(txtAccountPassword.Text).ToLower();
            string connectionString = "Data Source=" + clientConfig.ConnectServer + ";Initial Catalog=PHCN; User ID=" + clientConfig.ConnectUserName + "; Password=" + clientConfig.ConnectPassword + "; Connection Timeout=3";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                
            }
            catch 
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
                                            where TenDangNhap = @TenDangNhap and MatKhauMD5 = @MatKhau";
                cmd.Parameters.AddWithValue("@TenDangNhap", txtAccountUserName.Text);
                cmd.Parameters.AddWithValue("@MatKhau", md5Password);
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
                        var file = File.Create(_PathConFig);
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

            txtWebServer.Enabled = true;
            txtPort.Enabled = true;
            txtDatabase.Enabled = true;

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

            txtWebServer.Enabled = false;
            txtPort.Enabled = false;
            txtDatabase.Enabled = false;

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
            // chưa sử dụng
            try
            {
                string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
                string StartupValue = "PHCN.ThuNoiBo.Client";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                key.DeleteValue(StartupValue);
            }
            catch { }
            
        }                               
        private void showBalloonKhongTheKetNoiDenMayChu()
        {
            notifyIconMain.Visible = true;
            notifyIconMain.BalloonTipTitle = "Hệ thống nội bộ";
            notifyIconMain.BalloonTipText = "Không thể kết nối đến máy chủ, vui lòng liên hệ quản trị";
            notifyIconMain.ShowBalloonTip(500);
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void btnChonTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                FormNhapMatKhau f = new FormNhapMatKhau();
                int maNhanVien = int.Parse(gvTaiKhoan.GetFocusedRowCellValue("MaNhanVien").ToString());
                string hoTen = gvTaiKhoan.GetFocusedRowCellValue("HoTen").ToString();
                string tenDangNhap = gvTaiKhoan.GetFocusedRowCellValue("TenDangNhap").ToString();
                f.maNhanVien = maNhanVien;
                f.txtHoTen.Text = hoTen;
                f.txtTenDangNhap.Text = tenDangNhap;
                f.ShowDialog();
                if (f.maNhanVien != 0)
                {
                    loadCauHinh();
                }
            } catch
            {
                MessageBox.Show("Chưa chọn tài khoản");
                return;
            }
            
            
        }

        
        private void selectKhoaPhong_EditValueChanged(object sender, EventArgs e)
        {
            

            string maKhoa = "";
            if (selectKhoaPhong.EditValue != null)
            {
                maKhoa = selectKhoaPhong.EditValue.ToString();
                ClientController controller = new ClientController();
                DataTable dt = controller.runQuery("select * from NhanVien where Xoa = 0 and MaKhoa = '"+maKhoa+"' and NhanThu = '1' order by HoTen");
                gcTaiKhoan.DataSource = dt;
            }
             
            
        }

    }

}

