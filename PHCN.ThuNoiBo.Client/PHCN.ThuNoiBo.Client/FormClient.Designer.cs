namespace PHCN.ThuNoiBo.Client
{
    partial class FormClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabHopThu = new DevExpress.XtraTab.XtraTabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnDenHopThu = new DevExpress.XtraEditors.SimpleButton();
            this.lblTenKhoa = new DevExpress.XtraEditors.LabelControl();
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.tabCauHinh = new DevExpress.XtraTab.XtraTabPage();
            this.checkboxTienIch = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAutoGetMailTimer = new System.Windows.Forms.TextBox();
            this.checkboxAutoGetMail = new System.Windows.Forms.CheckBox();
            this.checkboxShowOnStart = new System.Windows.Forms.CheckBox();
            this.checkboxAutoStart = new System.Windows.Forms.CheckBox();
            this.btnBoQua = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuuCauHinh = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhatCauHinh = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtWebServer = new System.Windows.Forms.TextBox();
            this.txtConnectPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConnectUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConnectServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccountPassword = new System.Windows.Forms.TextBox();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAccountUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabTienIch = new DevExpress.XtraTab.XtraTabPage();
            this.txtLinkHopThu = new System.Windows.Forms.TextBox();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuHienThu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDenHopThu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoatChuongTrinh = new DevExpress.XtraEditors.SimpleButton();
            this.statusStripClient = new System.Windows.Forms.StatusStrip();
            this.statusBanQuyen = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerLayThu = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabHopThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabCauHinh.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabTienIch.SuspendLayout();
            this.contextMenuStripClient.SuspendLayout();
            this.statusStripClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(150, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "HỆ THỐNG NỘI BỘ";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(13, 37);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabHopThu;
            this.xtraTabControl1.Size = new System.Drawing.Size(554, 341);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabHopThu,
            this.tabCauHinh,
            this.tabTienIch});
            // 
            // tabHopThu
            // 
            this.tabHopThu.Controls.Add(this.pictureBox1);
            this.tabHopThu.Controls.Add(this.lblThongBao);
            this.tabHopThu.Controls.Add(this.btnDenHopThu);
            this.tabHopThu.Controls.Add(this.lblTenKhoa);
            this.tabHopThu.Controls.Add(this.lblHoTen);
            this.tabHopThu.Name = "tabHopThu";
            this.tabHopThu.Size = new System.Drawing.Size(548, 313);
            this.tabHopThu.Text = "Hộp thư";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PHCN.ThuNoiBo.Client.Properties.Resources.home;
            this.pictureBox1.Location = new System.Drawing.Point(19, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(172, 85);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(130, 17);
            this.lblThongBao.TabIndex = 2;
            this.lblThongBao.Text = "Bạn có 3 thư mới !!!";
            // 
            // btnDenHopThu
            // 
            this.btnDenHopThu.Image = ((System.Drawing.Image)(resources.GetObject("btnDenHopThu.Image")));
            this.btnDenHopThu.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDenHopThu.Location = new System.Drawing.Point(155, 177);
            this.btnDenHopThu.Name = "btnDenHopThu";
            this.btnDenHopThu.Size = new System.Drawing.Size(260, 58);
            this.btnDenHopThu.TabIndex = 1;
            this.btnDenHopThu.Text = "ĐẾN HỘP THƯ";
            this.btnDenHopThu.Click += new System.EventHandler(this.btnDenHopThu_Click);
            // 
            // lblTenKhoa
            // 
            this.lblTenKhoa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTenKhoa.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTenKhoa.Appearance.Options.UseFont = true;
            this.lblTenKhoa.Appearance.Options.UseForeColor = true;
            this.lblTenKhoa.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTenKhoa.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblTenKhoa.LineVisible = true;
            this.lblTenKhoa.Location = new System.Drawing.Point(175, 25);
            this.lblTenKhoa.Name = "lblTenKhoa";
            this.lblTenKhoa.Size = new System.Drawing.Size(350, 19);
            this.lblTenKhoa.TabIndex = 0;
            this.lblTenKhoa.Text = "PHÒNG CÔNG NGHỆ THÔNG TIN";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHoTen.Appearance.Options.UseFont = true;
            this.lblHoTen.Appearance.Options.UseForeColor = true;
            this.lblHoTen.LineVisible = true;
            this.lblHoTen.Location = new System.Drawing.Point(175, 50);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(164, 19);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Nguyễn Hồng Thanh";
            // 
            // tabCauHinh
            // 
            this.tabCauHinh.Controls.Add(this.checkboxTienIch);
            this.tabCauHinh.Controls.Add(this.txtPort);
            this.tabCauHinh.Controls.Add(this.label9);
            this.tabCauHinh.Controls.Add(this.txtAutoGetMailTimer);
            this.tabCauHinh.Controls.Add(this.checkboxAutoGetMail);
            this.tabCauHinh.Controls.Add(this.checkboxShowOnStart);
            this.tabCauHinh.Controls.Add(this.checkboxAutoStart);
            this.tabCauHinh.Controls.Add(this.btnBoQua);
            this.tabCauHinh.Controls.Add(this.btnLuuCauHinh);
            this.tabCauHinh.Controls.Add(this.btnCapNhatCauHinh);
            this.tabCauHinh.Controls.Add(this.groupBox2);
            this.tabCauHinh.Controls.Add(this.groupBox1);
            this.tabCauHinh.Name = "tabCauHinh";
            this.tabCauHinh.Size = new System.Drawing.Size(548, 313);
            this.tabCauHinh.Text = "Cấu hình";
            // 
            // checkboxTienIch
            // 
            this.checkboxTienIch.AutoSize = true;
            this.checkboxTienIch.Location = new System.Drawing.Point(349, 94);
            this.checkboxTienIch.Name = "checkboxTienIch";
            this.checkboxTienIch.Size = new System.Drawing.Size(62, 17);
            this.checkboxTienIch.TabIndex = 17;
            this.checkboxTienIch.TabStop = false;
            this.checkboxTienIch.Text = "Tiện ích";
            this.checkboxTienIch.UseVisualStyleBackColor = true;
            this.checkboxTienIch.CheckedChanged += new System.EventHandler(this.checkboxTienIch_CheckedChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(280, 121);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(50, 21);
            this.txtPort.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(506, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "giây";
            // 
            // txtAutoGetMailTimer
            // 
            this.txtAutoGetMailTimer.Location = new System.Drawing.Point(468, 48);
            this.txtAutoGetMailTimer.Name = "txtAutoGetMailTimer";
            this.txtAutoGetMailTimer.Size = new System.Drawing.Size(30, 21);
            this.txtAutoGetMailTimer.TabIndex = 13;
            this.txtAutoGetMailTimer.Text = "30";
            this.txtAutoGetMailTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkboxAutoGetMail
            // 
            this.checkboxAutoGetMail.AutoSize = true;
            this.checkboxAutoGetMail.Checked = true;
            this.checkboxAutoGetMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxAutoGetMail.Enabled = false;
            this.checkboxAutoGetMail.Location = new System.Drawing.Point(349, 50);
            this.checkboxAutoGetMail.Name = "checkboxAutoGetMail";
            this.checkboxAutoGetMail.Size = new System.Drawing.Size(115, 17);
            this.checkboxAutoGetMail.TabIndex = 12;
            this.checkboxAutoGetMail.Text = "Tự lấy thư mới sau";
            this.checkboxAutoGetMail.UseVisualStyleBackColor = true;
            // 
            // checkboxShowOnStart
            // 
            this.checkboxShowOnStart.AutoSize = true;
            this.checkboxShowOnStart.Checked = true;
            this.checkboxShowOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxShowOnStart.Location = new System.Drawing.Point(349, 73);
            this.checkboxShowOnStart.Name = "checkboxShowOnStart";
            this.checkboxShowOnStart.Size = new System.Drawing.Size(151, 17);
            this.checkboxShowOnStart.TabIndex = 11;
            this.checkboxShowOnStart.Text = "Bật hội thoại khi khởi động";
            this.checkboxShowOnStart.UseVisualStyleBackColor = true;
            // 
            // checkboxAutoStart
            // 
            this.checkboxAutoStart.AutoSize = true;
            this.checkboxAutoStart.Checked = true;
            this.checkboxAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxAutoStart.Location = new System.Drawing.Point(349, 27);
            this.checkboxAutoStart.Name = "checkboxAutoStart";
            this.checkboxAutoStart.Size = new System.Drawing.Size(145, 17);
            this.checkboxAutoStart.TabIndex = 10;
            this.checkboxAutoStart.Text = "Khởi động cùng Windows";
            this.checkboxAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
            this.btnBoQua.Location = new System.Drawing.Point(349, 194);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(184, 26);
            this.btnBoQua.TabIndex = 16;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnLuuCauHinh
            // 
            this.btnLuuCauHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuCauHinh.Image")));
            this.btnLuuCauHinh.Location = new System.Drawing.Point(349, 162);
            this.btnLuuCauHinh.Name = "btnLuuCauHinh";
            this.btnLuuCauHinh.Size = new System.Drawing.Size(184, 26);
            this.btnLuuCauHinh.TabIndex = 15;
            this.btnLuuCauHinh.Text = "Lưu";
            this.btnLuuCauHinh.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnCapNhatCauHinh
            // 
            this.btnCapNhatCauHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCapNhatCauHinh.Appearance.Options.UseFont = true;
            this.btnCapNhatCauHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhatCauHinh.Image")));
            this.btnCapNhatCauHinh.Location = new System.Drawing.Point(349, 117);
            this.btnCapNhatCauHinh.Name = "btnCapNhatCauHinh";
            this.btnCapNhatCauHinh.Size = new System.Drawing.Size(184, 39);
            this.btnCapNhatCauHinh.TabIndex = 14;
            this.btnCapNhatCauHinh.Text = "Cập nhật cấu hình";
            this.btnCapNhatCauHinh.Click += new System.EventHandler(this.btnCapNhatCauHinh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtWebServer);
            this.groupBox2.Controls.Add(this.txtConnectPassword);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtConnectUserName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtConnectServer);
            this.groupBox2.Location = new System.Drawing.Point(19, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 143);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết nối";
            // 
            // txtWebServer
            // 
            this.txtWebServer.Location = new System.Drawing.Point(102, 108);
            this.txtWebServer.Name = "txtWebServer";
            this.txtWebServer.Size = new System.Drawing.Size(116, 21);
            this.txtWebServer.TabIndex = 4;
            // 
            // txtConnectPassword
            // 
            this.txtConnectPassword.Location = new System.Drawing.Point(102, 69);
            this.txtConnectPassword.Name = "txtConnectPassword";
            this.txtConnectPassword.PasswordChar = '*';
            this.txtConnectPassword.Size = new System.Drawing.Size(209, 21);
            this.txtConnectPassword.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Web Server:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "SQL Server:";
            // 
            // txtConnectUserName
            // 
            this.txtConnectUserName.Location = new System.Drawing.Point(102, 42);
            this.txtConnectUserName.Name = "txtConnectUserName";
            this.txtConnectUserName.Size = new System.Drawing.Size(209, 21);
            this.txtConnectUserName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên đăng nhập:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mật khẩu:";
            // 
            // txtConnectServer
            // 
            this.txtConnectServer.Location = new System.Drawing.Point(102, 15);
            this.txtConnectServer.Name = "txtConnectServer";
            this.txtConnectServer.Size = new System.Drawing.Size(209, 21);
            this.txtConnectServer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccountPassword);
            this.groupBox1.Controls.Add(this.txtTenKhoa);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAccountUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(19, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 133);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tài khoản";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Location = new System.Drawing.Point(102, 47);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.PasswordChar = '*';
            this.txtAccountPassword.Size = new System.Drawing.Size(209, 21);
            this.txtAccountPassword.TabIndex = 7;
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.Enabled = false;
            this.txtTenKhoa.Location = new System.Drawing.Point(102, 101);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(209, 21);
            this.txtTenKhoa.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Khoa phòng:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(102, 74);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(209, 21);
            this.txtHoTen.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Họ tên:";
            // 
            // txtAccountUserName
            // 
            this.txtAccountUserName.Location = new System.Drawing.Point(102, 20);
            this.txtAccountUserName.Name = "txtAccountUserName";
            this.txtAccountUserName.Size = new System.Drawing.Size(209, 21);
            this.txtAccountUserName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu:";
            // 
            // tabTienIch
            // 
            this.tabTienIch.Controls.Add(this.txtLinkHopThu);
            this.tabTienIch.Name = "tabTienIch";
            this.tabTienIch.PageVisible = false;
            this.tabTienIch.Size = new System.Drawing.Size(548, 313);
            this.tabTienIch.Text = "Tiện ích";
            // 
            // txtLinkHopThu
            // 
            this.txtLinkHopThu.Location = new System.Drawing.Point(14, 12);
            this.txtLinkHopThu.Name = "txtLinkHopThu";
            this.txtLinkHopThu.ReadOnly = true;
            this.txtLinkHopThu.Size = new System.Drawing.Size(516, 21);
            this.txtLinkHopThu.TabIndex = 0;
            this.txtLinkHopThu.Text = "http://128.0.0.101:1234/ThuNoiBo/ClientLogin/?TenDangNhap=nghongthanhdt&MatKhau=s" +
    "dhjgdjh3hdh3hfdhfhdj";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripClient;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Mail nội bộ";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // contextMenuStripClient
            // 
            this.contextMenuStripClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHienThu,
            this.menuDenHopThu,
            this.menuThoat});
            this.contextMenuStripClient.Name = "contextMenuStripClient";
            this.contextMenuStripClient.Size = new System.Drawing.Size(141, 70);
            // 
            // menuHienThu
            // 
            this.menuHienThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuHienThu.Image = ((System.Drawing.Image)(resources.GetObject("menuHienThu.Image")));
            this.menuHienThu.Name = "menuHienThu";
            this.menuHienThu.Size = new System.Drawing.Size(140, 22);
            this.menuHienThu.Text = "Hiển thị";
            this.menuHienThu.Click += new System.EventHandler(this.menuHienThu_Click);
            // 
            // menuDenHopThu
            // 
            this.menuDenHopThu.Image = ((System.Drawing.Image)(resources.GetObject("menuDenHopThu.Image")));
            this.menuDenHopThu.Name = "menuDenHopThu";
            this.menuDenHopThu.Size = new System.Drawing.Size(140, 22);
            this.menuDenHopThu.Text = "Đến hộp thư";
            this.menuDenHopThu.Click += new System.EventHandler(this.btnDenHopThu_Click);
            // 
            // menuThoat
            // 
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(140, 22);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDong.Location = new System.Drawing.Point(460, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(102, 24);
            this.btnDong.TabIndex = 110;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnThoatChuongTrinh
            // 
            this.btnThoatChuongTrinh.Image = ((System.Drawing.Image)(resources.GetObject("btnThoatChuongTrinh.Image")));
            this.btnThoatChuongTrinh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnThoatChuongTrinh.Location = new System.Drawing.Point(310, 12);
            this.btnThoatChuongTrinh.Name = "btnThoatChuongTrinh";
            this.btnThoatChuongTrinh.Size = new System.Drawing.Size(144, 24);
            this.btnThoatChuongTrinh.TabIndex = 100;
            this.btnThoatChuongTrinh.Text = "Thoát chương trình";
            this.btnThoatChuongTrinh.Click += new System.EventHandler(this.btnThoatChuongTrinh_Click);
            // 
            // statusStripClient
            // 
            this.statusStripClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBanQuyen});
            this.statusStripClient.Location = new System.Drawing.Point(0, 381);
            this.statusStripClient.Name = "statusStripClient";
            this.statusStripClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripClient.Size = new System.Drawing.Size(578, 22);
            this.statusStripClient.TabIndex = 2;
            // 
            // statusBanQuyen
            // 
            this.statusBanQuyen.Name = "statusBanQuyen";
            this.statusBanQuyen.Size = new System.Drawing.Size(93, 17);
            this.statusBanQuyen.Text = "statusBanQuyen";
            // 
            // timerLayThu
            // 
            this.timerLayThu.Enabled = true;
            this.timerLayThu.Interval = 5000;
            this.timerLayThu.Tick += new System.EventHandler(this.timerLayThu_Tick);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 403);
            this.ControlBox = false;
            this.Controls.Add(this.statusStripClient);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnThoatChuongTrinh);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.labelControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BỆNH VIỆN PHỤC HỒI CHỨC NĂNG ĐỒNG THÁP";
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.VisibleChanged += new System.EventHandler(this.FormClient_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabHopThu.ResumeLayout(false);
            this.tabHopThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabCauHinh.ResumeLayout(false);
            this.tabCauHinh.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabTienIch.ResumeLayout(false);
            this.tabTienIch.PerformLayout();
            this.contextMenuStripClient.ResumeLayout(false);
            this.statusStripClient.ResumeLayout(false);
            this.statusStripClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabHopThu;
        private DevExpress.XtraEditors.SimpleButton btnDenHopThu;
        private DevExpress.XtraEditors.LabelControl lblTenKhoa;
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraTab.XtraTabPage tabCauHinh;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraTab.XtraTabPage tabTienIch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtConnectPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConnectUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConnectServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAccountPassword;
        private System.Windows.Forms.TextBox txtAccountUserName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnLuuCauHinh;
        private DevExpress.XtraEditors.SimpleButton btnCapNhatCauHinh;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripClient;
        private System.Windows.Forms.ToolStripMenuItem menuHienThu;
        private System.Windows.Forms.ToolStripMenuItem menuDenHopThu;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAutoGetMailTimer;
        private System.Windows.Forms.CheckBox checkboxAutoGetMail;
        private System.Windows.Forms.CheckBox checkboxShowOnStart;
        private System.Windows.Forms.CheckBox checkboxAutoStart;
        private DevExpress.XtraEditors.SimpleButton btnBoQua;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtWebServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLinkHopThu;
        private DevExpress.XtraEditors.SimpleButton btnThoatChuongTrinh;
        private System.Windows.Forms.StatusStrip statusStripClient;
        private System.Windows.Forms.TextBox txtTenKhoa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkboxTienIch;
        private System.Windows.Forms.ToolStripStatusLabel statusBanQuyen;
        public System.Windows.Forms.Timer timerLayThu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

