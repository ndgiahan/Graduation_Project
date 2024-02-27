using Fahasa.DAO;
using Fahasa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fahasa
{
    public partial class frmInventory : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmInventory()
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            addDataComboboxBranch();
            addDataComboboxBranchSearch();
            this.BackColor = Color.FromArgb(245, 245, 245);
            btnStatusBack.Enabled = false;
            btnStatusBack.BackColor = Color.Gainsboro;
            //vô hiệu hóa các button thêm xóa sửa khi chưa đổi trạng thái
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gainsboro;
            btnUpdate.ForeColor = Color.Black;
            //khi chức vụ là quản lý sản phẩm hoặc quản lý cửa hàng mới thực hiện chuyển đổi hàng hóa được
            CacheController cache = new CacheController();
            StaffInformation staff = cache.GetCacheStaff();
            if (staff.PositionId != 3 && staff.PositionId != 4)
            {
                this.ShowInTaskbar = false;
                this.Opacity = 0;
                frmMain main = new frmMain();
                main.Show();
            }

            if (checkDBExisted())
            {
                btnRestore.Enabled = false;
            }
        }
        //khởi tạo đối tượng branch
        public class Branch
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public int AreaId { get; set; }
            public Branch() { }
            public Branch(int id, string name,string address, string phoneNumber, int areaId)
            {
                Id = id;
                Name = name;
                Address = address;
                PhoneNumber = phoneNumber;
                AreaId = areaId;
            }
        }
        // thêm dữ liệu cho combobox branch tìm kiếm
        private void addDataComboboxBranchSearch()
        {
            string str = @"select [id], [name],[address],[phoneNumber],[areaId]  from Branch";
            List<Branch> listBranch = new List<Branch>();
            var dtBranch = data.ExcuteQuery(str);
            listBranch = (from DataRow dr in dtBranch.Rows
                                select new Branch
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    Name = dr["name"].ToString(),
                                    Address = dr["address"].ToString(),
                                    PhoneNumber = dr["phoneNumber"].ToString(),
                                    AreaId = Convert.ToInt32(dr["areaId"]),
                                })
                                .ToList();
            this.cmbBranchSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchSearch.DataSource = listBranch;
            cmbBranchSearch.DisplayMember = "Name";
            cmbBranchSearch.ValueMember = "Id";
        }
        // thêm dữ liệu cho combobox branch
        private void addDataComboboxBranch()
        {
            string str = @"select [id], [name],[address],[phoneNumber],[areaId]  from Branch";
            List<Branch> listBranch = new List<Branch>();
            var dtBranch = data.ExcuteQuery(str);
            listBranch = (from DataRow dr in dtBranch.Rows
                          select new Branch
                          {
                              Id = Convert.ToInt32(dr["id"]),
                              Name = $"{dr["id"]} - {dr["name"].ToString()}",
                              Address = dr["address"].ToString(),
                              PhoneNumber = dr["phoneNumber"].ToString(),
                              AreaId = Convert.ToInt32(dr["areaId"]),
                          })
                                .ToList();
            this.cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.DataSource = listBranch;
            cmbBranch.DisplayMember = "Name";
            cmbBranch.ValueMember = "Id";
        }
        //load form
        private void frmInventory_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Inventory();
            dgvInventory.DataSource = bdsource;
            //đổi font cho header
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvInventory.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvInventory.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvInventory.RowCount; i = i + 2)
            {
                dgvInventory.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvInventory;
            {
                x.Columns[0].Width = 270;
                x.Columns[1].Width = 100;
                x.Columns[2].Width = 300;
                x.Columns[3].Width = 100;
                x.Columns[4].Width = 300;
            }
        }
        //đổ dữ liệu vào textbox khi người dùng chọn dữ liệu trong datagrid view
        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBranch.Text = dgvInventory.CurrentRow.Cells[0].Value.ToString();
                txtProductId.Text = dgvInventory.CurrentRow.Cells[1].Value.ToString();
                txtProduct.Text = dgvInventory.CurrentRow.Cells[2].Value.ToString();
                txtQuantity.Text = dgvInventory.CurrentRow.Cells[3].Value.ToString();
                txtImg.Text = dgvInventory.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }
        // btn Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string branch = cmbBranchSearch.Text;
            string product = txtProductSearch.Text;

            if (branch != "" && product== "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Inventory"));
                dv.RowFilter = string.Format("[Chi nhánh] like  '%{0}%'", branch);
                dgvInventory.DataSource = dv;
            }
            else if (branch == "" && product != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Inventory"));
                dv.RowFilter = string.Format("[Sản phẩm] like  '%{0}%'", product);
                dgvInventory.DataSource = dv;
            }
            else if (branch != "" && product != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT Branch.Name, Product.Name, Quantity FROM Inventory join Branch on Inventory.BranchId= Branch.ID join Product on Inventory.ProductId=Product.Id WHERE Branch.Name = N'"+branch+"' and Product.Name like N'%"+product+"%'"));
                dgvInventory.DataSource = dv;
            }

            else
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 thuộc tính để tìm kiếm!");
            }
        }
        // btn hủy tìm
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmInventory_Load(sender, e);
        }
        // trạng thái cho ô số lượng khi số lượng =0
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            string text = "Hết hàng";
            if (txtQuantity.Text == "0")
            {
                txtQuantity.Text = text;

            }
        }
        //load ảnh
        private void txtImg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nameImg = txtImg.Text; // Lấy tên ảnh từ TextBox

                Utils.loadImage(nameImg, thumbnail);
            }
            catch (Exception ex)
            {
            }
        }
        // btn về trang chủ
        private void btnExit_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }
        // btn đổi trạng thái cho form
        private void btnFormStatus_Click(object sender, EventArgs e)
        {
            // đổi màu nên form để người dùng thấy sự thay đổi
            this.BackColor = Color.White;
            //kích hoạt btnStatusBack
            btnStatusBack.Enabled = true;
            btnStatusBack.BackColor = Color.LightSalmon;
            btnStatusBack.ForeColor = Color.Black;
            //kích hoạt các button thêm xóa sửa khi chưa đổi trạng thái
            btnUpdate.Enabled = true;
            btnUpdate.BackColor = Color.MistyRose;
            btnUpdate.ForeColor = Color.Black;
            //vô hiệu hóa btnFormStatus
            btnFormStatus.Enabled = false;
            btnFormStatus.BackColor = Color.Gainsboro;
            btnFormStatus.ForeColor = Color.Black;
            //đổi trạng thái của các textbox từ chỉ đọc thành có thể chỉnh sửa
            txtQuantity.ReadOnly = false;
            //Xóa thông tin đang hiện trong các textbox
            txtQuantity.Clear();
        }
        // btn quay về trạng thái ban đẩu
        private void btnStatusBack_Click(object sender, EventArgs e)
        {
            // đổi màu nên form để người dùng thấy sự thay đổi
            this.BackColor = Color.FromArgb(245, 245, 245);
            ;
            //vô hiệu hóa btnStatusBack
            btnStatusBack.Enabled = false;
            btnStatusBack.BackColor = Color.Gainsboro;
            btnStatusBack.ForeColor = Color.Black;
            //Vô hiệu hóa các button thêm xóa sửa khi chưa đổi trạng thái
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gainsboro;
            btnUpdate.ForeColor = Color.Black;
            //kích hoạt btnFormStatus
            btnFormStatus.Enabled = true;
            btnFormStatus.BackColor = Color.LightSalmon;
            btnFormStatus.ForeColor = Color.Black;
            //đổi trạng thái của các textbox từ có thể chỉnh sửa thành chỉ đọc
            txtQuantity.ReadOnly = true;
        }
        //btn cập nhật số lượng
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtProductId.Text;
                string productId = new string(id.Where(char.IsDigit).ToArray());
                string branchId = new string(cmbBranch.Text.Where(char.IsDigit).ToArray());
                string quantity = txtQuantity.Text;
                data.ExcuteNonQuery("UPDATE Inventory SET Quantity ='" + int.Parse(quantity) + "' WHERE ProductId =" + int.Parse(productId) + "and BranchId =" + int.Parse(branchId) + "");
                MessageBox.Show("Chỉnh sửa thành công");
                frmInventory_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName + @"\BackupDB\backupDB.bak";
            string query = $"BACKUP DATABASE [FahasaBookStore] TO DISK = N'{path}' WITH NOFORMAT, NOINIT, NAME = N'SQLTestDB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
            data.ExcuteNonQuery(query);
            MessageBox.Show("Sao lưu thành công");
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName + @"\BackupDB\backupDB.bak";
            string query = $"RESTORE DATABASE [FahasaBookStore] FROM DISK = N'{path}' WITH  FILE = 1, NOUNLOAD, STATS = 5;";
            data.ExcuteNonQuery(query);
        }

        private bool checkDBExisted()
        {
            string query = "SELECT name FROM master.sys.databases WHERE name = N'FahasaBookStore'";
            var db = data.ExcuteQuery(query);
            return db != null;
        }
    }
}
