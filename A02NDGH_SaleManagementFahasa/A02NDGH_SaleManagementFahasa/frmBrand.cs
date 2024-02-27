using Fahasa.DAO;
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
    public partial class frmBrand : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmBrand()
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            addDataComboboxOrigin();
            addDataComboboxOriginSearch();
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
        //Khởi tạo đối tượng Origin
        public class Origin
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Origin() { }
            public Origin(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        //thêm dữ liệu vào combobox origin cho tìm kiếm
        private void addDataComboboxOriginSearch()
        {
            string str = @"select [id], [name]  from Origin";
            List<Origin> listOrigin = new List<Origin>();
            var dtOrigin = data.ExcuteQuery(str);
            listOrigin = (from DataRow dr in dtOrigin.Rows
                        select new Origin
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Name = dr["name"].ToString(),
                        })
                                .ToList();
            this.cmbOriginSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOriginSearch.DataSource = listOrigin;
            cmbOriginSearch.DisplayMember = "Name";
            cmbOriginSearch.ValueMember = "Id";
        }
        //Thêm dữ liệu vào combobox origin 
        private void addDataComboboxOrigin()
        {
            string str = @"select [id], [name]  from Origin";
            List<Origin> listOrigin = new List<Origin>();
            var dtOrigin = data.ExcuteQuery(str);
            listOrigin = (from DataRow dr in dtOrigin.Rows
                          select new Origin
                          {
                              Id = Convert.ToInt32(dr["id"]),
                              Name = $"{dr["id"]} - {dr["name"].ToString()}", // Kết hợp ID và Name thành một chuỗi
                          })
                                .ToList();
            this.cmbOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigin.DataSource = listOrigin;
            cmbOrigin.DisplayMember = "Name";
            cmbOrigin.ValueMember = "Id";
        }
        //load form
        private void frmBrand_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Brand();
            dgvBrand.DataSource = bdsource;
            //đổi font cho header
            dgvBrand.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvBrand.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            dgvBrand.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvBrand.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvBrand.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvBrand.RowCount; i = i + 2)
            {
                dgvBrand.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvBrand;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 150;
                x.Columns[2].Width = 300;
                x.Columns[3].Width = 350;
            }
        }
        private void dgvBrand_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvBrand.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvBrand.CurrentRow.Cells[2].Value.ToString();
                cmbOrigin.Text = dgvBrand.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }
        //btn Về trang chủ
        private void btnBackMain_Click(object sender, EventArgs e)
        {
            frmMain main= new frmMain();
            this.Hide();
            main.Show();
        }
        //btn tìm (theo tên và nguồn gốc)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtnameSearch.Text;
            string origin = cmbOriginSearch.Text;

            if (name != "" && origin!="")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Brand"));
                dv.RowFilter = string.Format("[Tên] like  '%{0}%'", name);
                dgvBrand.DataSource = dv;
            }

            else if (name == "" && origin != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Brand"));
                dv.RowFilter = string.Format("[Xuất xứ] like  '%{0}%'", origin);
                dgvBrand.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
        //nút hủy tìm
        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            frmBrand_Load(sender, e);
        }
        //đóng form
        private void frmBrand_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //button thêm mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string origin = cmbOrigin.Text;
                string originId = new string(origin.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("INSERT INTO Brand (Name, OriginId) values (N'" + name + "',N'" + int.Parse(originId) + "')");
                MessageBox.Show("Thêm mới thành công");
                frmBrand_Load(sender, e);
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
                string brandId = new string(id.Where(char.IsDigit).ToArray());
                string name = txtName.Text;
                string origin = cmbOrigin.Text;
                string originId = new string(origin.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("UPDATE Brand SET Name =N'" + name + "', OriginId='" + originId + "' WHERE Id = N'" + int.Parse(brandId) + "'");
                MessageBox.Show("Chỉnh sửa thành công");
                frmBrand_Load(sender, e);
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
                    string brandId = new string(id.Where(char.IsDigit).ToArray());
                    string name = txtName.Text;
                    string origin = cmbOrigin.Text;
                    data.ExcuteNonQuery("DELETE FROM Brand where Id='" + int.Parse(brandId) + "'");
                    MessageBox.Show("Xóa thành công");
                    frmBrand_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            //Xóa thông tin đang hiện trong các textbox
            txtName.Clear();
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
        }
    }
}
