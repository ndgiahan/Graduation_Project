using Fahasa.DAO;
using Fahasa.Models;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahasa
{
    public partial class frmEmployee : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmEmployee()
        {
           
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            addDataComboboxBranch();
            addDataComboboxBranchSearch();
            addDataComboboxPosition();
            this.BackColor = Color.FromArgb(245, 245, 245);
            btnStatusBack.Enabled = false;
            btnStatusBack.BackColor = Color.Gainsboro;
            //vô hiệu hóa các button thêm xóa sửa khi chưa đổi trạng thái
            btnAdd.Enabled = false;
            btnAdd.BackColor = Color.Gainsboro;
            btnAdd.ForeColor = Color.Black;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gainsboro;
            btnUpdate.ForeColor = Color.Black;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.Gainsboro;
            btnDelete.ForeColor = Color.Black;
            //vô hiệu hóa check box
            ckbNam.Enabled = false;
            ckbNu.Enabled = false;
            CacheController cache = new CacheController();
            StaffInformation staff = cache.GetCacheStaff();
            if (staff.PositionId != 3)
            {
                this.ShowInTaskbar = false;
                this.Opacity = 0;
                frmMain main = new frmMain();
                main.Show();
            }
        }
        // khởi tạo đối tượng Branch
        public class Branch
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public Branch() { }
            public Branch(int id, string name, string address, string phoneNumber)
            {
                Id = id;
                Name = name;
                Address = address;
                PhoneNumber = phoneNumber;
            }
        }
        //Khởi tạo đối tượng Position
        public class Position
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Position() { }
            public Position(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        //load dữ liệu vào combobox Branch cho tìm kiếm
        private void addDataComboboxBranchSearch()
        {
            string str = @"select [id], [name], [Address], [PhoneNumber]  from Branch";
            List<Branch> listBranch = new List<Branch>();
            var dtBranch = data.ExcuteQuery(str);
            listBranch = (from DataRow dr in dtBranch.Rows
                        select new Branch
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Name = $"{dr["id"]} - {dr["name"].ToString()}", // Kết hợp ID và Name thành một chuỗi
                            Address = dr["address"].ToString(),
                            PhoneNumber = dr["phoneNumber"].ToString(),
                        })
                                .ToList();
            this.cmbBranchSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchSearch.DataSource = listBranch;
            cmbBranchSearch.DisplayMember = "Name";
            cmbBranchSearch.ValueMember = "Id";
        }
        //load dữ liệu vào combobox Branch
        private void addDataComboboxBranch()
        {
            string str = @"select [id], [name], [Address], [PhoneNumber]  from Branch";
            List<Branch> listBranch = new List<Branch>();
            var dtBranch = data.ExcuteQuery(str);
            listBranch = (from DataRow dr in dtBranch.Rows
                          select new Branch
                          {
                              Id = Convert.ToInt32(dr["id"]),
                              Name = $"{dr["id"]} - {dr["name"].ToString()}", // Kết hợp ID và Name thành một chuỗi
                              Address = dr["address"].ToString(),
                              PhoneNumber = dr["phoneNumber"].ToString(),
                          })
                                .ToList();
            this.cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.DataSource = listBranch;
            cmbBranch.DisplayMember = "Name";
            cmbBranch.ValueMember = "Id";
        }
        //load dữ liệu vào combox Position cho tìm kiếm
        private void addDataComboboxPositionSearch()
        {
            string str = @"select [id], [name]  from Position";
            List<Position> listPosition = new List<Position>();
            var dtPosition = data.ExcuteQuery(str);
            listPosition = (from DataRow dr in dtPosition.Rows
                          select new Position
                          {
                              Id = Convert.ToInt32(dr["id"]),
                              Name = dr["name"].ToString(),
                          })
                                .ToList();
            this.cmbPositonSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPositonSearch.DataSource = listPosition;
            cmbPositonSearch.DisplayMember = "Name";
            cmbPositonSearch.ValueMember = "Id";
        }
        //load dữ liệu vào combox Position
        private void addDataComboboxPosition()
        {
            string str = @"select [id], [name]  from Position";
            List<Position> listPosition = new List<Position>();
            var dtPosition = data.ExcuteQuery(str);
            listPosition = (from DataRow dr in dtPosition.Rows
                            select new Position
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Name = $"{dr["id"]} - {dr["name"].ToString()}", // Kết hợp ID và Name thành một chuỗi
                            })
                                .ToList();
            this.cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.DataSource = listPosition;
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "Id";
        }
        //load form
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Employee();
            dgvEmployee.DataSource = bdsource;
            //đổi font cho header
            dgvEmployee.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvEmployee.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvEmployee.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvEmployee.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvEmployee.RowCount; i = i + 2)
            {
                dgvEmployee.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvEmployee;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 100;
                x.Columns[2].Width = 200;
                x.Columns[3].Width = 100;
                x.Columns[4].Width = 100;
                x.Columns[5].Width = 150;
                x.Columns[6].Width = 200;
                x.Columns[7].Width = 150;
                x.Columns[8].Width = 250;
                x.Columns[9].Width = 250;
            }
        }
        //Thay đổi check box theo giá trị của cột Giới tính
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ khi cột "Giới tính" thay đổi giá trị
            if (e.ColumnIndex == dgvEmployee.Columns["Giới tính"].Index && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dgvEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string gender = cell.Value.ToString();

                // Kiểm tra giá trị và tự động check checkbox tương ứng
                if (gender == "Nam")
                {
                    ckbNam.Checked = true;
                    ckbNu.Checked = false;
                }
                else if (gender == "Nữ")
                {
                    ckbNam.Checked = false;
                    ckbNu.Checked = true;
                }
            }
        }
        // btn Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtnameSearch.Text;
            string branch = cmbBranchSearch.Text;
            string position = cmbPositonSearch.Text;

            if (name == "" && branch != "" && position !="")
            {
                DataView dv = new DataView(data.ExcuteQuery("select * from v_Employee"));
                dv.RowFilter = string.Format("[Chi nhánh] like '%{0}%' OR [Chức vụ] like '%{0}%'", branch, position) ;
                dgvEmployee.DataSource = dv;
            }
            else if (name != "" && branch != "" && position != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("select * from v_Employee"));
                dv.RowFilter = string.Format("[Tên NV] like  '%{0}%'", name);
                dgvEmployee.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
        //hiển thị nội dung khi người dùng click vào dữ liệu trong datagrid view
        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                txtId.Text = dgvEmployee.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvEmployee.CurrentRow.Cells[2].Value.ToString();
                dtpBirth.Text = dgvEmployee.CurrentRow.Cells[4].Value.ToString();
                txtAddress.Text = dgvEmployee.CurrentRow.Cells[6].Value.ToString();
                txtPhoneNum.Text = dgvEmployee.CurrentRow.Cells[5].Value.ToString();
                txtIdentification.Text = dgvEmployee.CurrentRow.Cells[7].Value.ToString();
                cmbBranch.Text = dgvEmployee.CurrentRow.Cells[8].Value.ToString();
                cmbPosition.Text = dgvEmployee.CurrentRow.Cells[9].Value.ToString();
                //nếu là nữ thì check box tự động check nữ, nam thì tự động check nam
                string male = dgvEmployee.CurrentRow.Cells[3].Value.ToString();
                if (male == "Nam")
                {
                    ckbNam.Checked = true;
                    ckbNu.Checked = false;
                }
                else
                {
                    ckbNam.Checked = false;
                    ckbNu.Checked = true;
                }
            }
            catch { }
        }
        //btn Hủy tìm
        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            frmEmployee_Load(sender, e);
        }
        // btn về trang chủ
        private void btnBackMain_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }
        //btnFormStatus - đổi trạng thái cho form từ chỉ xem thành có thể chỉnh sửa
        private void btnFormStatus_Click(object sender, EventArgs e)
        {
            // đổi màu nên form để người dùng thấy sự thay đổi
            this.BackColor = Color.White;
            //kích hoạt btnStatusBack
            btnStatusBack.Enabled = true;
            btnStatusBack.BackColor = Color.LightSalmon;
            btnStatusBack.ForeColor = Color.Black;
            //kích hoạt các button thêm xóa sửa khi chưa đổi trạng thái
            btnAdd.Enabled = true;
            btnAdd.BackColor = Color.MistyRose;
            btnAdd.ForeColor = Color.Black;
            btnUpdate.Enabled = true;
            btnUpdate.BackColor = Color.MistyRose;
            btnUpdate.ForeColor = Color.Black;
            btnDelete.Enabled = true;
            btnDelete.BackColor = Color.MistyRose;
            btnDelete.ForeColor = Color.Black;
            //vô hiệu hóa btnFormStatus
            btnFormStatus.Enabled = false;
            btnFormStatus.BackColor = Color.Gainsboro;
            btnFormStatus.ForeColor = Color.Black;
            //đổi trạng thái của các textbox từ chỉ đọc thành có thể chỉnh sửa
            txtName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtIdentification.ReadOnly = false;
            txtPhoneNum.ReadOnly = false;
            // đổi trạng thái cho combo box
            ckbNu.Enabled = true;
            ckbNam.Enabled = true;
            //Xóa thông tin đang hiện trong các textbox
            txtName.Clear();
            txtAddress.Clear();
            txtPhoneNum.Clear();
            txtId.Clear();
            txtIdentification.Clear();
        }
        //btnStatusBack - from quay về trạng thái ban đầu (chỉ xem)
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
            btnAdd.Enabled = false;
            btnAdd.BackColor = Color.Gainsboro;
            btnAdd.ForeColor = Color.Black;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gainsboro;
            btnUpdate.ForeColor = Color.Black;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.Gainsboro;
            btnDelete.ForeColor = Color.Black;
            //kích hoạt btnFormStatus
            btnFormStatus.Enabled = true;
            btnFormStatus.BackColor = Color.LightSalmon;
            btnFormStatus.ForeColor = Color.Black;
            //đổi trạng thái của các textbox từ có thể chỉnh sửa thành chỉ đọc
            txtName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtIdentification.ReadOnly = true;
            txtPhoneNum.ReadOnly = true;
            //đổi trạng thái check box về lại ban đầu
            ckbNam.Enabled = false;
            ckbNu.Enabled = false;
        }
        //btn Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string address = txtAddress.Text;
                string phone = txtPhoneNum.Text;
                int sex = 1;
                if (ckbNam.Checked)
                {
                    sex = 0;
                }
                DateTime birth = dtpBirth.Value;
                string identification = txtIdentification.Text;
                string postion = cmbPosition.Text;
                string postionId = new string(postion.Where(char.IsDigit).ToArray());
                string branch = cmbBranch.Text;
                string branchId = new string(postion.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("INSERT INTO Employee (Name, Address, PhoneNumber, Sex, DayOfBirth, CitizenIdentity,BranchId, PositionId) " +
                    "values(N'" + name + "',N'" + address + "',N'" + phone + "','" + sex + "','" + birth.Date + "'," +
                    "'" + identification + "','" + branchId + "','" + postionId + "' )");
                MessageBox.Show("Thêm mới thành công");
                frmEmployee_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //btn chỉnh sửa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string empId = new string(id.Where(char.IsDigit).ToArray());
                string name = txtName.Text;
                string address = txtAddress.Text;
                string phone = txtPhoneNum.Text;
                int sex = 1;
                if (ckbNam.Checked)
                {
                    sex = 0;
                }
                DateTime birth = dtpBirth.Value;
                string identification = txtIdentification.Text;
                string postion = cmbPosition.Text;
                string postionId = new string(postion.Where(char.IsDigit).ToArray());
                string branch = cmbBranch.Text;
                string branchId = new string(postion.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("UPDATE Employee SET Name =N'" + name + "',Address=N'" + address + "', PhoneNumber = N'" + phone + "', " +
                    "Sex='" + sex + "',DayOfBirth=N'" + birth.Date + "',CitizenIdentity=N'" + identification + "'," +
                    "PositionId=N'" + postionId + "',BranchId=N'" + branchId + "'  where Id = N'" + int.Parse(empId) + "'");
                MessageBox.Show("Chỉnh sửa thành công");
                frmEmployee_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //btn Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult rlg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string id = txtId.Text;
                    string empId = new string(id.Where(char.IsDigit).ToArray());
                    string name = txtName.Text;
                    string address = txtAddress.Text;
                    string phone = txtPhoneNum.Text;
                    int sex = 1;
                    if (ckbNam.Checked)
                    {
                        sex = 0;
                    }
                    DateTime birth = dtpBirth.Value;
                    string identification = txtIdentification.Text;
                    string postion = cmbPosition.Text;
                    string postionId = new string(postion.Where(char.IsDigit).ToArray());
                    string branch = cmbBranch.Text;
                    string branchId = new string(postion.Where(char.IsDigit).ToArray());
                    data.ExcuteNonQuery("DELETE FROM Employee where Id='" + int.Parse(empId) + "'");
                    MessageBox.Show("Xóa thành công");
                    frmEmployee_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // dóng form
        private void frmEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
