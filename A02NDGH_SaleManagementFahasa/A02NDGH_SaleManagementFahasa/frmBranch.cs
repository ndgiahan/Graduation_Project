using Fahasa.DAO;
using Fahasa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace Fahasa
{
    public partial class frmBranch : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmBranch()
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            addDataComboboxAreaSearch();
            addDataComboboxArea();
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
        //khởi tạo đối tượng Area
        public class Area
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Area() { }
            public Area(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        //Thêm dữ liệu vào cmbAreaSearch
        private void addDataComboboxAreaSearch()
        {
            string str = @"select [id], [name]  from Area";
            List<Area> listArea = new List<Area>();
            var dtArea = data.ExcuteQuery(str);
            listArea = (from DataRow dr in dtArea.Rows
                                select new Area
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    Name = dr["name"].ToString(),
                                })
                                .ToList();
            this.cmbAreaSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAreaSearch.DataSource = listArea;
            cmbAreaSearch.DisplayMember = "Name";
            cmbAreaSearch.ValueMember = "Id";
        }
        //Thêm dữ liệu vào cmbArea
        private void addDataComboboxArea()
        {
            string str = @"select [id], [name]  from Area";
            List<Area> listArea = new List<Area>();
            var dtArea = data.ExcuteQuery(str);
            listArea = (from DataRow dr in dtArea.Rows
                        select new Area
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Name = $"{dr["id"]} - {dr["name"].ToString()}"
                        })
                                .ToList();
            this.cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.DataSource = listArea;
            cmbArea.DisplayMember = "Name";
            cmbArea.ValueMember = "Id";
        }
        //Load form
        private void Branch_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Branch();
            dgvBranch.DataSource = bdsource;
            //đổi font cho header
            dgvBranch.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvBranch.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvBranch.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvBranch.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvBranch.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvBranch.RowCount; i = i + 2)
            {
                dgvBranch.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            //chỉnh chiều rộng cho các cột tromg datagrid view
            DataGridView x = dgvBranch;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 100;
                x.Columns[2].Width = 300;
                x.Columns[3].Width = 250;
                x.Columns[4].Width = 450;
                x.Columns[5].Width = 170;
            }
        }
        //đổ dữ liệu vào textbox khi người dùng chọn dữ liệu trong datagrid view
        private void dgvBranch_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvBranch.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvBranch.CurrentRow.Cells[2].Value.ToString();
                cmbArea.Text = dgvBranch.CurrentRow.Cells[3].Value.ToString();
                txtPhone.Text = dgvBranch.CurrentRow.Cells[5].Value.ToString();
                txtAdress.Text = dgvBranch.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }
        //btnSearch - tìm kiếm bằng 2 cách (tên chi nhánh hoặc khu vực)
        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            string name = txtNameSearch.Text;
            string area = cmbAreaSearch.Text;

            if (name != "" && area !="")
            {
                DataView dv = new DataView(data.ExcuteQuery("select * from v_Branch"));
                dv.RowFilter = string.Format("[Tên] like  '%{0}%'", name);
                dgvBranch.DataSource = dv;
            }
            else if (name == "" && area != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT Area.Name AS N'Khu vực','BRANCH-' + CAST(Branch.Id AS varchar) AS N'Mã chi nhánh',Branch.Name AS N'Tên chi nhánh',Branch.Address AS N'Địa chỉ', PhoneNumber AS N'SDT' FROM Branch join Area on Branch.AreaId= Area.Id WHERE Area.Name like N'%" + area + "%'"));
                dgvBranch.DataSource = dv;
            }    
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
        //btnCancelSearch - Hủy tìm
        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            Branch_Load(sender, e);
        }
        //btnBackMain - quay về trang chủ
        private void btnBackMain_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }
        //sự kiện đóng form
        private void frmBranch_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
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
            txtAdress.ReadOnly = false;
            txtPhone.ReadOnly = false;
            //Xóa thông tin đang hiện trong các textbox
            txtName.Clear();
            txtAdress.Clear();
            txtPhone.Clear();
            txtId.Clear();
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
            txtAdress.ReadOnly = true;
            txtPhone.ReadOnly = true;

        }
        // button thêm một chi nhánh mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string address = txtAdress.Text;
                string phone = txtPhone.Text;
                string area = cmbArea.Text;
                string areaId = new string(area.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("INSERT INTO BRANCH (Name, Address, PhoneNumber, AreaId) values(N'" + name + "',N'" + address + "',N'" + phone + "','" + int.Parse(areaId) + "')");
                MessageBox.Show("Thêm mới thành công");
                Branch_Load(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //button chỉnh sửa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string branchId = new string(id.Where(char.IsDigit).ToArray());
                string name = txtName.Text;
                string address = txtAdress.Text;
                string phone = txtPhone.Text;
                string area = cmbArea.Text;
                string areaId = new string(area.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("UPDATE Branch SET Name =N'" + name + "',Address=N'" + address + "', PhoneNumber = N'" + phone + "', AreaId='" + areaId + "' where Id = N'" + branchId + "'");
                MessageBox.Show("Chỉnh sửa thành công");
                Branch_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        //button xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string id = txtId.Text;
                    string branchId = new string(id.Where(char.IsDigit).ToArray());
                    string name = txtName.Text;
                    string address = txtAdress.Text;
                    string phone = txtPhone.Text;
                    string area = cmbArea.Text;
                    string areaId = new string(area.Where(char.IsDigit).ToArray());
                    data.ExcuteNonQuery("DELETE FROM branch where Id='" + branchId + "'");
                    MessageBox.Show("Xóa thành công");
                    Branch_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
