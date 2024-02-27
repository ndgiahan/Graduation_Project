using Fahasa.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahasa
{
    public partial class frmPublisher : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmPublisher()
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
        }
        //load form
        private void frmPublisher_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Publisher();
            dgvPublisher.DataSource = bdsource;
            //đổi font cho header
            dgvPublisher.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            //đổi font cho các hàng
            dgvPublisher.DefaultCellStyle.Font = new Font("Tahoma", 10);
            //đổi màu cho header
            dgvPublisher.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvPublisher.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvPublisher.RowCount; i = i + 2)
            {
                dgvPublisher.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvPublisher;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 150;
                x.Columns[2].Width = 350;
                x.Columns[3].Width = 350;
                x.Columns[4].Width = 300;
            }

        }
        //đổ dữ liệu vào textbox khi người dùng chọn dữ liệu trong datagrid view
        private void dgvPublisher_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvPublisher.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvPublisher.CurrentRow.Cells[2].Value.ToString();
                txtAddress.Text = dgvPublisher.CurrentRow.Cells[3].Value.ToString();
                txtPhone.Text = dgvPublisher.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }
        // btn hủy tìm
        private void btnExitt_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }
        // btn Tìm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtnameSearch.Text;

            if ( name != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("select * from v_Publisher"));
                dv.RowFilter = string.Format("[Tên] like  '%{0}%'", name);
                dgvPublisher.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
        // đóng form
        private void frmPublisher_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại Yes/No
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả người dùng chọn
            if (result == DialogResult.No)
            {
                // Ngăn không cho form đóng
                e.Cancel = true;
            }
        }
        //btn về trang chủ
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmPublisher publisher = new frmPublisher();
            this.Hide();
            publisher.Show();
        }
        // btn đổi trạng thái form
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
            //Xóa thông tin đang hiện trong các textbox
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtId.Clear();
        }

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

        }
        // bnt thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string address = txtAddress.Text;
                string phone = txtPhone.Text;
                data.ExcuteNonQuery("INSERT INTO Publisher (Name, Address, PhoneNumber) values(N'" + name + "',N'" + address + "',N'" + phone + "')");
                MessageBox.Show("Thêm mới thành công");
                frmPublisher_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        // chỉnh sửa 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string pubId = new string(id.Where(char.IsDigit).ToArray());
                string name = txtName.Text;
                string address = txtAddress.Text;
                string phone = txtPhone.Text;
                data.ExcuteNonQuery("UPDATE Publisher SET Name =N'" + name + "',Address=N'" + address + "', PhoneNumber = N'" + phone + "' where Id = N'" + pubId + "'");
                MessageBox.Show("Chỉnh sửa thành công");
                frmPublisher_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        // btn xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult rlg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string id = txtId.Text;
                    string pubId = new string(id.Where(char.IsDigit).ToArray());
                    string name = txtName.Text;
                    string address = txtAddress.Text;
                    string phone = txtPhone.Text;
                    data.ExcuteNonQuery("DELETE FROM Publisher where Id='" + pubId + "'");
                    MessageBox.Show("Xóa thành công");
                    frmPublisher_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
