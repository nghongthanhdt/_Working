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
            this.tabTaiKhoan = new DevExpress.XtraTab.XtraTabPage();
            this.btnChonTaiKhoan = new DevExpress.XtraEditors.SimpleButton();
            this.gcTaiKhoan = new DevExpress.XtraGrid.GridControl();
            this.gvTaiKhoan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.selectKhoaPhong = new DevExpress.XtraEditors.LookUpEdit();
            this.tabCauHinh = new DevExpress.XtraTab.XtraTabPage();
            this.txtAccountPassword = new System.Windows.Forms.TextBox();
            this.txtWebServer = new System.Windows.Forms.TextBox();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtConnectPassword = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAccountUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConnectUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBoQua = new DevExpress.XtraEditors.SimpleButton();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtConnectServer = new System.Windows.Forms.TextBox();
            this.btnLuuCauHinh = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhatCauHinh = new DevExpress.XtraEditors.SimpleButton();
            this.tabTienIch = new DevExpress.XtraTab.XtraTabPage();
            this.txtLinkHopThu = new System.Windows.Forms.TextBox();
            this.checkboxAutoStart = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkboxTienIch = new System.Windows.Forms.CheckBox();
            this.txtAutoGetMailTimer = new System.Windows.Forms.TextBox();
            this.checkboxAutoGetMail = new System.Windows.Forms.CheckBox();
            this.checkboxShowOnStart = new System.Windows.Forms.CheckBox();
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
            this.tabTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectKhoaPhong.Properties)).BeginInit();
            this.tabCauHinh.SuspendLayout();
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
            this.xtraTabControl1.Size = new System.Drawing.Size(482, 306);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabHopThu,
            this.tabTaiKhoan,
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
            this.tabHopThu.Size = new System.Drawing.Size(476, 278);
            this.tabHopThu.Text = "Hộp thư";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PHCN.ThuNoiBo.Client.Properties.Resources.home;
            this.pictureBox1.Location = new System.Drawing.Point(19, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(109, 78);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(130, 17);
            this.lblThongBao.TabIndex = 2;
            this.lblThongBao.Text = "Bạn có 3 thư mới !!!";
            // 
            // btnDenHopThu
            // 
            this.btnDenHopThu.Image = ((System.Drawing.Image)(resources.GetObject("btnDenHopThu.Image")));
            this.btnDenHopThu.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDenHopThu.Location = new System.Drawing.Point(154, 135);
            this.btnDenHopThu.Name = "btnDenHopThu";
            this.btnDenHopThu.Size = new System.Drawing.Size(180, 58);
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
            this.lblTenKhoa.Location = new System.Drawing.Point(112, 18);
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
            this.lblHoTen.Location = new System.Drawing.Point(112, 43);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(164, 19);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Nguyễn Hồng Thanh";
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.btnChonTaiKhoan);
            this.tabTaiKhoan.Controls.Add(this.gcTaiKhoan);
            this.tabTaiKhoan.Controls.Add(this.label14);
            this.tabTaiKhoan.Controls.Add(this.label12);
            this.tabTaiKhoan.Controls.Add(this.selectKhoaPhong);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Size = new System.Drawing.Size(476, 278);
            this.tabTaiKhoan.Text = "Tài khoản";
            // 
            // btnChonTaiKhoan
            // 
            this.btnChonTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnChonTaiKhoan.Image")));
            this.btnChonTaiKhoan.Location = new System.Drawing.Point(117, 223);
            this.btnChonTaiKhoan.Name = "btnChonTaiKhoan";
            this.btnChonTaiKhoan.Size = new System.Drawing.Size(99, 34);
            this.btnChonTaiKhoan.TabIndex = 4;
            this.btnChonTaiKhoan.Text = "Chọn";
            this.btnChonTaiKhoan.Click += new System.EventHandler(this.btnChonTaiKhoan_Click);
            // 
            // gcTaiKhoan
            // 
            this.gcTaiKhoan.Location = new System.Drawing.Point(117, 61);
            this.gcTaiKhoan.MainView = this.gvTaiKhoan;
            this.gcTaiKhoan.Name = "gcTaiKhoan";
            this.gcTaiKhoan.Size = new System.Drawing.Size(274, 156);
            this.gcTaiKhoan.TabIndex = 3;
            this.gcTaiKhoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaiKhoan});
            // 
            // gvTaiKhoan
            // 
            this.gvTaiKhoan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNhanVien,
            this.colHoTen,
            this.colTenDangNhap});
            this.gvTaiKhoan.GridControl = this.gcTaiKhoan;
            this.gvTaiKhoan.Name = "gvTaiKhoan";
            this.gvTaiKhoan.OptionsBehavior.Editable = false;
            this.gvTaiKhoan.OptionsBehavior.ReadOnly = true;
            this.gvTaiKhoan.OptionsView.ShowGroupPanel = false;
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.Caption = "Mã NV";
            this.colMaNhanVien.FieldName = "MaNhanVien";
            this.colMaNhanVien.Name = "colMaNhanVien";
            // 
            // colHoTen
            // 
            this.colHoTen.Caption = "Họ tên";
            this.colHoTen.FieldName = "HoTen";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 0;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.Caption = "Tên đăng nhập";
            this.colTenDangNhap.FieldName = "TenDangNhap";
            this.colTenDangNhap.Name = "colTenDangNhap";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Tài khoản:";
            this.label14.Click += new System.EventHandler(this.label12_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Khoa phòng:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // selectKhoaPhong
            // 
            this.selectKhoaPhong.Location = new System.Drawing.Point(117, 29);
            this.selectKhoaPhong.Name = "selectKhoaPhong";
            this.selectKhoaPhong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.selectKhoaPhong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaKhoa", "#"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhoa", 80, "Tên Khoa")});
            this.selectKhoaPhong.Properties.DisplayMember = "TenKhoa";
            this.selectKhoaPhong.Properties.NullText = "Chọn khoa...";
            this.selectKhoaPhong.Properties.ValueMember = "MaKhoa";
            this.selectKhoaPhong.Size = new System.Drawing.Size(201, 20);
            this.selectKhoaPhong.TabIndex = 0;
            this.selectKhoaPhong.EditValueChanged += new System.EventHandler(this.selectKhoaPhong_EditValueChanged);
            // 
            // tabCauHinh
            // 
            this.tabCauHinh.Controls.Add(this.txtAccountPassword);
            this.tabCauHinh.Controls.Add(this.txtWebServer);
            this.tabCauHinh.Controls.Add(this.txtTenKhoa);
            this.tabCauHinh.Controls.Add(this.label11);
            this.tabCauHinh.Controls.Add(this.txtConnectPassword);
            this.tabCauHinh.Controls.Add(this.txtHoTen);
            this.tabCauHinh.Controls.Add(this.txtPort);
            this.tabCauHinh.Controls.Add(this.label8);
            this.tabCauHinh.Controls.Add(this.label7);
            this.tabCauHinh.Controls.Add(this.txtAccountUserName);
            this.tabCauHinh.Controls.Add(this.label2);
            this.tabCauHinh.Controls.Add(this.label3);
            this.tabCauHinh.Controls.Add(this.label1);
            this.tabCauHinh.Controls.Add(this.label4);
            this.tabCauHinh.Controls.Add(this.txtConnectUserName);
            this.tabCauHinh.Controls.Add(this.label5);
            this.tabCauHinh.Controls.Add(this.label10);
            this.tabCauHinh.Controls.Add(this.label6);
            this.tabCauHinh.Controls.Add(this.btnBoQua);
            this.tabCauHinh.Controls.Add(this.txtDatabase);
            this.tabCauHinh.Controls.Add(this.txtConnectServer);
            this.tabCauHinh.Controls.Add(this.btnLuuCauHinh);
            this.tabCauHinh.Controls.Add(this.btnCapNhatCauHinh);
            this.tabCauHinh.Name = "tabCauHinh";
            this.tabCauHinh.Size = new System.Drawing.Size(476, 278);
            this.tabCauHinh.Text = "Cấu hình";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Location = new System.Drawing.Point(124, 189);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.PasswordChar = '*';
            this.txtAccountPassword.Size = new System.Drawing.Size(209, 21);
            this.txtAccountPassword.TabIndex = 88;
            // 
            // txtWebServer
            // 
            this.txtWebServer.Location = new System.Drawing.Point(124, 135);
            this.txtWebServer.Name = "txtWebServer";
            this.txtWebServer.Size = new System.Drawing.Size(116, 21);
            this.txtWebServer.TabIndex = 85;
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.Enabled = false;
            this.txtTenKhoa.Location = new System.Drawing.Point(124, 243);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(209, 21);
            this.txtTenKhoa.TabIndex = 9;
            this.txtTenKhoa.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Khoa phòng:";
            // 
            // txtConnectPassword
            // 
            this.txtConnectPassword.Location = new System.Drawing.Point(256, 81);
            this.txtConnectPassword.Name = "txtConnectPassword";
            this.txtConnectPassword.PasswordChar = '*';
            this.txtConnectPassword.Size = new System.Drawing.Size(77, 21);
            this.txtConnectPassword.TabIndex = 83;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(124, 216);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(209, 21);
            this.txtHoTen.TabIndex = 8;
            this.txtHoTen.TabStop = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(283, 135);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(50, 21);
            this.txtPort.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Họ tên:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Web Server:";
            // 
            // txtAccountUserName
            // 
            this.txtAccountUserName.Location = new System.Drawing.Point(124, 162);
            this.txtAccountUserName.Name = "txtAccountUserName";
            this.txtAccountUserName.Size = new System.Drawing.Size(209, 21);
            this.txtAccountUserName.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "SQL Server:";
            // 
            // txtConnectUserName
            // 
            this.txtConnectUserName.Location = new System.Drawing.Point(124, 81);
            this.txtConnectUserName.Name = "txtConnectUserName";
            this.txtConnectUserName.Size = new System.Drawing.Size(89, 21);
            this.txtConnectUserName.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "User:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pass:";
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
            this.btnBoQua.Location = new System.Drawing.Point(256, 14);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(77, 28);
            this.btnBoQua.TabIndex = 90;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(124, 108);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(209, 21);
            this.txtDatabase.TabIndex = 84;
            // 
            // txtConnectServer
            // 
            this.txtConnectServer.Location = new System.Drawing.Point(124, 54);
            this.txtConnectServer.Name = "txtConnectServer";
            this.txtConnectServer.Size = new System.Drawing.Size(209, 21);
            this.txtConnectServer.TabIndex = 81;
            // 
            // btnLuuCauHinh
            // 
            this.btnLuuCauHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuCauHinh.Image")));
            this.btnLuuCauHinh.Location = new System.Drawing.Point(154, 14);
            this.btnLuuCauHinh.Name = "btnLuuCauHinh";
            this.btnLuuCauHinh.Size = new System.Drawing.Size(96, 28);
            this.btnLuuCauHinh.TabIndex = 89;
            this.btnLuuCauHinh.Text = "Lưu";
            this.btnLuuCauHinh.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnCapNhatCauHinh
            // 
            this.btnCapNhatCauHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCapNhatCauHinh.Appearance.Options.UseFont = true;
            this.btnCapNhatCauHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhatCauHinh.Image")));
            this.btnCapNhatCauHinh.Location = new System.Drawing.Point(29, 14);
            this.btnCapNhatCauHinh.Name = "btnCapNhatCauHinh";
            this.btnCapNhatCauHinh.Size = new System.Drawing.Size(119, 28);
            this.btnCapNhatCauHinh.TabIndex = 80;
            this.btnCapNhatCauHinh.Text = "Cập nhật";
            this.btnCapNhatCauHinh.Click += new System.EventHandler(this.btnCapNhatCauHinh_Click);
            // 
            // tabTienIch
            // 
            this.tabTienIch.Controls.Add(this.txtLinkHopThu);
            this.tabTienIch.Controls.Add(this.checkboxAutoStart);
            this.tabTienIch.Controls.Add(this.label9);
            this.tabTienIch.Controls.Add(this.checkboxTienIch);
            this.tabTienIch.Controls.Add(this.txtAutoGetMailTimer);
            this.tabTienIch.Controls.Add(this.checkboxAutoGetMail);
            this.tabTienIch.Controls.Add(this.checkboxShowOnStart);
            this.tabTienIch.Name = "tabTienIch";
            this.tabTienIch.PageVisible = false;
            this.tabTienIch.Size = new System.Drawing.Size(476, 278);
            this.tabTienIch.Text = "Tiện ích";
            // 
            // txtLinkHopThu
            // 
            this.txtLinkHopThu.Location = new System.Drawing.Point(14, 12);
            this.txtLinkHopThu.Name = "txtLinkHopThu";
            this.txtLinkHopThu.ReadOnly = true;
            this.txtLinkHopThu.Size = new System.Drawing.Size(448, 21);
            this.txtLinkHopThu.TabIndex = 0;
            this.txtLinkHopThu.Text = "http://128.0.0.101:1234/ThuNoiBo/ClientLogin/?TenDangNhap=nghongthanhdt&MatKhau=s" +
    "dhjgdjh3hdh3hfdhfhdj";
            // 
            // checkboxAutoStart
            // 
            this.checkboxAutoStart.AutoSize = true;
            this.checkboxAutoStart.Checked = true;
            this.checkboxAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxAutoStart.Location = new System.Drawing.Point(14, 39);
            this.checkboxAutoStart.Name = "checkboxAutoStart";
            this.checkboxAutoStart.Size = new System.Drawing.Size(145, 17);
            this.checkboxAutoStart.TabIndex = 10;
            this.checkboxAutoStart.Text = "Khởi động cùng Windows";
            this.checkboxAutoStart.UseVisualStyleBackColor = true;
            this.checkboxAutoStart.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(171, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "giây";
            this.label9.Visible = false;
            // 
            // checkboxTienIch
            // 
            this.checkboxTienIch.AutoSize = true;
            this.checkboxTienIch.Location = new System.Drawing.Point(14, 85);
            this.checkboxTienIch.Name = "checkboxTienIch";
            this.checkboxTienIch.Size = new System.Drawing.Size(62, 17);
            this.checkboxTienIch.TabIndex = 17;
            this.checkboxTienIch.TabStop = false;
            this.checkboxTienIch.Text = "Tiện ích";
            this.checkboxTienIch.UseVisualStyleBackColor = true;
            this.checkboxTienIch.Visible = false;
            this.checkboxTienIch.CheckedChanged += new System.EventHandler(this.checkboxTienIch_CheckedChanged);
            // 
            // txtAutoGetMailTimer
            // 
            this.txtAutoGetMailTimer.Location = new System.Drawing.Point(133, 60);
            this.txtAutoGetMailTimer.Name = "txtAutoGetMailTimer";
            this.txtAutoGetMailTimer.Size = new System.Drawing.Size(30, 21);
            this.txtAutoGetMailTimer.TabIndex = 13;
            this.txtAutoGetMailTimer.Text = "30";
            this.txtAutoGetMailTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAutoGetMailTimer.Visible = false;
            // 
            // checkboxAutoGetMail
            // 
            this.checkboxAutoGetMail.AutoSize = true;
            this.checkboxAutoGetMail.Checked = true;
            this.checkboxAutoGetMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxAutoGetMail.Enabled = false;
            this.checkboxAutoGetMail.Location = new System.Drawing.Point(14, 62);
            this.checkboxAutoGetMail.Name = "checkboxAutoGetMail";
            this.checkboxAutoGetMail.Size = new System.Drawing.Size(115, 17);
            this.checkboxAutoGetMail.TabIndex = 12;
            this.checkboxAutoGetMail.Text = "Tự lấy thư mới sau";
            this.checkboxAutoGetMail.UseVisualStyleBackColor = true;
            this.checkboxAutoGetMail.Visible = false;
            // 
            // checkboxShowOnStart
            // 
            this.checkboxShowOnStart.AutoSize = true;
            this.checkboxShowOnStart.Checked = true;
            this.checkboxShowOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxShowOnStart.Location = new System.Drawing.Point(14, 108);
            this.checkboxShowOnStart.Name = "checkboxShowOnStart";
            this.checkboxShowOnStart.Size = new System.Drawing.Size(151, 17);
            this.checkboxShowOnStart.TabIndex = 11;
            this.checkboxShowOnStart.Text = "Bật hội thoại khi khởi động";
            this.checkboxShowOnStart.UseVisualStyleBackColor = true;
            this.checkboxShowOnStart.Visible = false;
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
            this.btnDong.Location = new System.Drawing.Point(354, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(136, 24);
            this.btnDong.TabIndex = 110;
            this.btnDong.Text = "Đóng cửa sổ";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnThoatChuongTrinh
            // 
            this.btnThoatChuongTrinh.Image = ((System.Drawing.Image)(resources.GetObject("btnThoatChuongTrinh.Image")));
            this.btnThoatChuongTrinh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnThoatChuongTrinh.Location = new System.Drawing.Point(260, 12);
            this.btnThoatChuongTrinh.Name = "btnThoatChuongTrinh";
            this.btnThoatChuongTrinh.Size = new System.Drawing.Size(88, 24);
            this.btnThoatChuongTrinh.TabIndex = 100;
            this.btnThoatChuongTrinh.Text = "Thoát";
            this.btnThoatChuongTrinh.Click += new System.EventHandler(this.btnThoatChuongTrinh_Click);
            // 
            // statusStripClient
            // 
            this.statusStripClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBanQuyen});
            this.statusStripClient.Location = new System.Drawing.Point(0, 352);
            this.statusStripClient.Name = "statusStripClient";
            this.statusStripClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripClient.Size = new System.Drawing.Size(508, 22);
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
            this.ClientSize = new System.Drawing.Size(508, 374);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClient_FormClosed);
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.VisibleChanged += new System.EventHandler(this.FormClient_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabHopThu.ResumeLayout(false);
            this.tabHopThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabTaiKhoan.ResumeLayout(false);
            this.tabTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectKhoaPhong.Properties)).EndInit();
            this.tabCauHinh.ResumeLayout(false);
            this.tabCauHinh.PerformLayout();
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
        private System.Windows.Forms.TextBox txtConnectPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConnectUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConnectServer;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatabase;
        private DevExpress.XtraTab.XtraTabPage tabTaiKhoan;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.LookUpEdit selectKhoaPhong;
        private DevExpress.XtraEditors.SimpleButton btnChonTaiKhoan;
        private DevExpress.XtraGrid.GridControl gcTaiKhoan;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaiKhoan;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDangNhap;
        private System.Windows.Forms.Label label14;
    }
}

