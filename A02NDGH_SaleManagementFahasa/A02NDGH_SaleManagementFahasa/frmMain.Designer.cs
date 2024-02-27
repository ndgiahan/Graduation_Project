using System.Windows.Forms;

namespace Fahasa
{
    partial class frmMain
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
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmiList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGenreType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcTácGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublisher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.tsminBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatisticsOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatisticsProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fahasaBookStoreDataSet1 = new Fahasa.FahasaBookStoreDataSet();
            this.danhMụcGiáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(535, 326);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(0, 0);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiList,
            this.tsmiMenu,
            this.tsmiAccount});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1089, 29);
            this.menuStrip2.TabIndex = 26;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsmiList
            // 
            this.tsmiList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProductGroup,
            this.tsmiGenreType,
            this.tsmiGenre,
            this.danhMụcTácGiảToolStripMenuItem,
            this.tsmiPublisher,
            this.tsmiSupplier,
            this.tsmiBrand,
            this.tsmiProduct,
            this.danhMụcGiáToolStripMenuItem,
            this.tsmiInventory,
            this.tsmiCustomer,
            this.tsmiOthers});
            this.tsmiList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tsmiList.Name = "tsmiList";
            this.tsmiList.Size = new System.Drawing.Size(93, 25);
            this.tsmiList.Text = "Danh mục";
            // 
            // tsmiProductGroup
            // 
            this.tsmiProductGroup.Name = "tsmiProductGroup";
            this.tsmiProductGroup.Size = new System.Drawing.Size(387, 26);
            this.tsmiProductGroup.Text = "Danh mục nhóm sản phẩm";
            this.tsmiProductGroup.Click += new System.EventHandler(this.tsmiProductList_Click);
            // 
            // tsmiGenreType
            // 
            this.tsmiGenreType.Name = "tsmiGenreType";
            this.tsmiGenreType.Size = new System.Drawing.Size(387, 26);
            this.tsmiGenreType.Text = "Danh mục nhóm thể loại";
            this.tsmiGenreType.Click += new System.EventHandler(this.tsmiGenreType_Click_1);
            // 
            // tsmiGenre
            // 
            this.tsmiGenre.Name = "tsmiGenre";
            this.tsmiGenre.Size = new System.Drawing.Size(387, 26);
            this.tsmiGenre.Text = "Danh mục thể loại";
            this.tsmiGenre.Click += new System.EventHandler(this.tsmiGenre_Click_1);
            // 
            // danhMụcTácGiảToolStripMenuItem
            // 
            this.danhMụcTácGiảToolStripMenuItem.Name = "danhMụcTácGiảToolStripMenuItem";
            this.danhMụcTácGiảToolStripMenuItem.Size = new System.Drawing.Size(387, 26);
            this.danhMụcTácGiảToolStripMenuItem.Text = "Danh mục tác giả";
            // 
            // tsmiPublisher
            // 
            this.tsmiPublisher.Name = "tsmiPublisher";
            this.tsmiPublisher.Size = new System.Drawing.Size(387, 26);
            this.tsmiPublisher.Text = "Danh mục nhà xuất bản";
            this.tsmiPublisher.Click += new System.EventHandler(this.tsmiPublisher_Click);
            // 
            // tsmiSupplier
            // 
            this.tsmiSupplier.Name = "tsmiSupplier";
            this.tsmiSupplier.Size = new System.Drawing.Size(387, 26);
            this.tsmiSupplier.Text = "Danh mục nhà cung cấp";
            this.tsmiSupplier.Click += new System.EventHandler(this.tsmiSupplier_Click);
            // 
            // tsmiBrand
            // 
            this.tsmiBrand.Name = "tsmiBrand";
            this.tsmiBrand.Size = new System.Drawing.Size(387, 26);
            this.tsmiBrand.Text = "Danh mục thương hiệu";
            this.tsmiBrand.Click += new System.EventHandler(this.tsmiBrand_Click);
            // 
            // tsmiProduct
            // 
            this.tsmiProduct.Name = "tsmiProduct";
            this.tsmiProduct.Size = new System.Drawing.Size(387, 26);
            this.tsmiProduct.Text = "Danh mục sản phẩm";
            // 
            // tsmiInventory
            // 
            this.tsmiInventory.Name = "tsmiInventory";
            this.tsmiInventory.Size = new System.Drawing.Size(387, 26);
            this.tsmiInventory.Text = "Danh mục hàng tồn kho";
            this.tsmiInventory.Click += new System.EventHandler(this.tsmiInventory_Click);
            // 
            // tsmiCustomer
            // 
            this.tsmiCustomer.Name = "tsmiCustomer";
            this.tsmiCustomer.Size = new System.Drawing.Size(387, 26);
            this.tsmiCustomer.Text = "Danh mục khách hàng";
            this.tsmiCustomer.Click += new System.EventHandler(this.danhMụcKháchHàngToolStripMenuItem_Click);
            // 
            // tsmiOthers
            // 
            this.tsmiOthers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEmployee,
            this.tsminBranch});
            this.tsmiOthers.Name = "tsmiOthers";
            this.tsmiOthers.Size = new System.Drawing.Size(387, 26);
            this.tsmiOthers.Text = "Danh mục khác (dành cho quản lý cửa hàng)";
            this.tsmiOthers.Click += new System.EventHandler(this.danhMụcKhácToolStripMenuItem_Click);
            // 
            // tsmiEmployee
            // 
            this.tsmiEmployee.Name = "tsmiEmployee";
            this.tsmiEmployee.Size = new System.Drawing.Size(223, 26);
            this.tsmiEmployee.Text = "Danh mục nhân viên";
            this.tsmiEmployee.Click += new System.EventHandler(this.danhMụcNhânViênToolStripMenuItem_Click);
            // 
            // tsminBranch
            // 
            this.tsminBranch.Name = "tsminBranch";
            this.tsminBranch.Size = new System.Drawing.Size(223, 26);
            this.tsminBranch.Text = "Danh mục chi nhánh";
            this.tsminBranch.Click += new System.EventHandler(this.danhMụcChiNhánhToolStripMenuItem_Click);
            // 
            // tsmiMenu
            // 
            this.tsmiMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOrder,
            this.tsmiInvoice,
            this.tsmiReport});
            this.tsmiMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tsmiMenu.Name = "tsmiMenu";
            this.tsmiMenu.Size = new System.Drawing.Size(96, 25);
            this.tsmiMenu.Text = "Chức năng";
            // 
            // tsmiOrder
            // 
            this.tsmiOrder.Name = "tsmiOrder";
            this.tsmiOrder.Size = new System.Drawing.Size(231, 26);
            this.tsmiOrder.Text = "Quản lý đơn đặt hàng";
            this.tsmiOrder.Click += new System.EventHandler(this.tsmiOrder_Click);
            // 
            // tsmiInvoice
            // 
            this.tsmiInvoice.Name = "tsmiInvoice";
            this.tsmiInvoice.Size = new System.Drawing.Size(231, 26);
            this.tsmiInvoice.Text = "Quản lý hóa đơn";
            this.tsmiInvoice.Click += new System.EventHandler(this.tsmiInvoice_Click);
            // 
            // tsmiReport
            // 
            this.tsmiReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStatisticsOrder,
            this.tsmiStatisticsProduct});
            this.tsmiReport.Name = "tsmiReport";
            this.tsmiReport.Size = new System.Drawing.Size(231, 26);
            this.tsmiReport.Text = "Báo cáo thống kê";
            // 
            // tsmiStatisticsOrder
            // 
            this.tsmiStatisticsOrder.Name = "tsmiStatisticsOrder";
            this.tsmiStatisticsOrder.Size = new System.Drawing.Size(281, 26);
            this.tsmiStatisticsOrder.Text = "Thống kê đơn đặt hàng";
            // 
            // tsmiStatisticsProduct
            // 
            this.tsmiStatisticsProduct.Name = "tsmiStatisticsProduct";
            this.tsmiStatisticsProduct.Size = new System.Drawing.Size(281, 26);
            this.tsmiStatisticsProduct.Text = "Thống kê số lượng sản phẩm";
            // 
            // tsmiAccount
            // 
            this.tsmiAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangePass,
            this.tsmiLogOut});
            this.tsmiAccount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tsmiAccount.Name = "tsmiAccount";
            this.tsmiAccount.Size = new System.Drawing.Size(87, 25);
            this.tsmiAccount.Text = "Tài khoản";
            // 
            // tsmiChangePass
            // 
            this.tsmiChangePass.Name = "tsmiChangePass";
            this.tsmiChangePass.Size = new System.Drawing.Size(173, 26);
            this.tsmiChangePass.Text = "Đổi mật khẩu";
            // 
            // tsmiLogOut
            // 
            this.tsmiLogOut.Name = "tsmiLogOut";
            this.tsmiLogOut.Size = new System.Drawing.Size(173, 26);
            this.tsmiLogOut.Text = "Đăng xuất";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtPosition);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBranch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(588, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 185);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.White;
            this.txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(154, 125);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(233, 26);
            this.txtPosition.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Chức vụ";
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.White;
            this.txtBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(154, 81);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(233, 26);
            this.txtBranch.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Chi nhánh";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(154, 41);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(233, 26);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tên nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(342, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(407, 37);
            this.label4.TabIndex = 29;
            this.label4.Text = "Đồ án Khóa luận tốt nghiệp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 184);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(350, 24);
            this.label5.TabIndex = 30;
            this.label5.Text = "Sinh viên thực hiện: Nguyễn Đỗ Gia Hân";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 24);
            this.label6.TabIndex = 31;
            this.label6.Text = "Mã sinh viên: 2021010142";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(325, 24);
            this.label7.TabIndex = 32;
            this.label7.Text = "Trường Đại học Tài Chính - Marketing";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(346, 217);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 24);
            this.label8.TabIndex = 33;
            this.label8.Text = "Lớp: 20DTH1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(80, 151);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(321, 24);
            this.label9.TabIndex = 34;
            this.label9.Text = "Giảng viên hướng dẫn: Võ Xuân Thể";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(549, 79);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(204, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "[Chương trình chỉ phục vụ học tập]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(80, 252);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(504, 48);
            this.label11.TabIndex = 36;
            this.label11.Text = "Đề tài: Phát triển phân hệ thông tin quản lý bán sách \r\ncủa hệ thống nhà sách Fah" +
    "sa";
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackgroundImage = global::Fahasa.Properties.Resources.fahasa_background;
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Location = new System.Drawing.Point(0, 29);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip3.Size = new System.Drawing.Size(1089, 24);
            this.menuStrip3.TabIndex = 3;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // fahasaBookStoreDataSet1
            // 
            this.fahasaBookStoreDataSet1.DataSetName = "FahasaBookStoreDataSet";
            this.fahasaBookStoreDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // danhMụcGiáToolStripMenuItem
            // 
            this.danhMụcGiáToolStripMenuItem.Name = "danhMụcGiáToolStripMenuItem";
            this.danhMụcGiáToolStripMenuItem.Size = new System.Drawing.Size(387, 26);
            this.danhMụcGiáToolStripMenuItem.Text = "Danh mục giá";
            this.danhMụcGiáToolStripMenuItem.Click += new System.EventHandler(this.danhMụcGiáToolStripMenuItem_Click_1);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1089, 426);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmiList;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublisher;
        private System.Windows.Forms.ToolStripMenuItem tsmiBrand;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiInvoice;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem tsmiInventory;
        private System.Windows.Forms.ToolStripMenuItem tsmiCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmiOthers;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmployee;
        private System.Windows.Forms.ToolStripMenuItem tsminBranch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private ToolStripMenuItem tsmiReport;
        private ToolStripMenuItem tsmiStatisticsOrder;
        private ToolStripMenuItem tsmiStatisticsProduct;
        private ToolStripMenuItem tsmiGenreType;
        private ToolStripMenuItem tsmiGenre;
        private ToolStripMenuItem tsmiProduct;
        private FahasaBookStoreDataSet fahasaBookStoreDataSet1;
        private ToolStripMenuItem tsmiAccount;
        private ToolStripMenuItem tsmiChangePass;
        private ToolStripMenuItem tsmiLogOut;
        private ToolStripMenuItem danhMụcTácGiảToolStripMenuItem;
        private ToolStripMenuItem danhMụcGiáToolStripMenuItem;
    }
}