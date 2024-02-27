using Fahasa.DAO;
using Fahasa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace Fahasa
{
    public partial class frmCustomer : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmCustomer()
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
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
        //load form
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Customer();
            dgvCustomer.DataSource = bdsource;
            //đổi font cho header
            dgvCustomer.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvCustomer.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvCustomer.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvCustomer.RowCount; i = i + 2)
            {
                dgvCustomer.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvCustomer;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 100;
                x.Columns[2].Width = 200;
                x.Columns[3].Width = 150;
                x.Columns[4].Width = 300;
                x.Columns[5].Width = 200;
            }
        }
        // btn Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtnameSearch.Text;
            string phoneNumber = txtPhoneSearch.Text;

            if (name != "" && phoneNumber=="")
            {
                DataView dv = new DataView(data.ExcuteQuery("select * from v_Customer"));
                dv.RowFilter = string.Format("[Tên KH] like  '%{0}%'", name);
                dgvCustomer.DataSource = dv;
            }
            else if (name == "" && phoneNumber != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("select * from v_Customer"));
                dv.RowFilter = string.Format("[SĐT] like  '%{0}%'", phoneNumber);
                dgvCustomer.DataSource = dv;
            }
            else if (name != "" && phoneNumber != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("select * from v_Customer"));
                dv.RowFilter = string.Format("[SDT] like  '%{0}%'", phoneNumber);
                dgvCustomer.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
        //btn Về trang chủ
        private void btnBackMain_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }
        //hiển thị nội dung khi người dùng click vào dữ liệu trong datagrid view
        private void dgvCustomer_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
                txtPhone.Text = dgvCustomer.CurrentRow.Cells[3].Value.ToString();
                txtAddress.Text = dgvCustomer.CurrentRow.Cells[4].Value.ToString();
                txtTIN.Text = dgvCustomer.CurrentRow.Cells[5].Value.ToString();

            }
            catch { }
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
            txtPhone.ReadOnly = false;
            txtTIN.ReadOnly = false;
            //Xóa thông tin đang hiện trong các textbox
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtId.Clear();
            txtTIN.Clear();
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
            txtPhone.ReadOnly = true;
            txtTIN.ReadOnly = true;
        }
        //btn Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string address = txtAddress.Text;
                string phone = txtPhone.Text;
                string TIN = txtTIN.Text;
                data.ExcuteNonQuery("INSERT INTO Customer (Name, Address, PhoneNumber, TIN) values(N'" + name + "',N'" + address + "',N'" + phone + "','" + TIN + "')");
                MessageBox.Show("Thêm mới thành công");
                frmCustomer_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //btn Chỉnh sửa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string customerId = new string(id.Where(char.IsDigit).ToArray());
                string name = txtName.Text;
                string address = txtAddress.Text;
                string phone = txtPhone.Text;
                string TIN = txtTIN.Text;
                data.ExcuteNonQuery("UPDATE Customer SET Name =N'" + name + "',Address=N'" + address + "', PhoneNumber = N'" + phone + "', TIN='" + TIN + "' where Id = N'" + int.Parse(customerId)+ "'");
                MessageBox.Show("Chỉnh sửa thành công");
                frmCustomer_Load(sender, e);
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
                    string customerId = new string(id.Where(char.IsDigit).ToArray());
                    string name = txtName.Text;
                    string address = txtAddress.Text;
                    string phone = txtPhone.Text;
                    string TIN = txtTIN.Text;
                    data.ExcuteNonQuery("DELETE FROM Customer where Id='" + int.Parse(customerId) + "'");
                    MessageBox.Show("Xóa thành công");
                    frmCustomer_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
