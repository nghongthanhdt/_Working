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
using PHCN.ThuNoiBo.Client.Controller;
using System.IO;
using System.Xml.Serialization;

namespace PHCN.ThuNoiBo.Client.App_Forms
{
    public partial class FormNhapMatKhau : DevExpress.XtraEditors.XtraForm
    {
        string _PathConFig = @"C:\configThuNoiBo.xml";
        public int maNhanVien = 0;
        public FormNhapMatKhau()
        {
            InitializeComponent();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            maNhanVien = 0;
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {

            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;

            ClientController controller = new ClientController();
            DataTable dt = new DataTable();
            string query = "select NhanVien.MaNhanVien, NhanVien.HoTen, NhanVien.TenDangNhap, NhanVien.MatKhau, KhoaPhong.TenKhoa, NhanVien.NhanThu from NhanVien inner join KhoaPhong on NhanVien.MaKhoa = KhoaPhong.MaKhoa where TenDangNhap = '" + tenDangNhap + "' and MatKhau = '" + matKhau + "'";
            dt = controller.runQuery(query);
            if (dt.Rows.Count > 0)
            { // set client config
                ClientConfig clientConfig = new ClientConfig();
                StreamReader reader = new StreamReader(_PathConFig);
                XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
                clientConfig = (ClientConfig)serializer.Deserialize(reader);
                reader.Close();
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
                maNhanVien = int.Parse(clientConfig.MaNhanVien);
                try
                {
                    var file = File.Create(_PathConFig);
                    serializer.Serialize(file, clientConfig);
                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                };
                MessageBox.Show("Chào mừng " + clientConfig.HoTen + ", kết nối thành công!");
                this.Close();
            } else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                return;
            }
            
        }
        private void setConfigChonTaiKhoan(int maNhanVien, string hoTen, string tenDangNhap, string tenKhoa)
        {

        }


    }
}