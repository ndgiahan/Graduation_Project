using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Fahasa.DAO;
using System.Xml.Linq;

namespace Fahasa
{
    public partial class frmGenreType : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmGenreType()
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            addDataComboboxProductGroup();
            addDataComboboxProductGroupSearch();
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
        //Khởi tạo đối tượng ProductFroup
        public class ProductGroup
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ProductGroup() { }
            public ProductGroup(int id, string name, int productGroupId)
            {
                Id = id;
                Name = name;
            }
        }
        //thêm dữ liệu vào combobox nhóm sản phẩm cho tìm kiếm
        private void addDataComboboxProductGroupSearch()
        {
            string str = @"select [id], [name]  from ProductGroup";
            List<ProductGroup> listProductGroup = new List<ProductGroup>();
            var dtProductGroup = data.ExcuteQuery(str);
            listProductGroup = (from DataRow dr in dtProductGroup.Rows
                                select new ProductGroup
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    Name = dr["name"].ToString(),
                                })
                                .ToList();
            this.cmbProductGroupSearch.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbProductGroupSearch.DataSource = listProductGroup;
            cmbProductGroupSearch.DisplayMember = "Name";
            cmbProductGroupSearch.ValueMember = "Id";
        }
        //thêm dữ liệu vào combobox nhóm sản phẩm
        private void addDataComboboxProductGroup()
        {
            string str = @"select [id], [name]  from ProductGroup";
            List<ProductGroup> listProductGroup = new List<ProductGroup>();
            var dtProductGroup = data.ExcuteQuery(str);
            listProductGroup = (from DataRow dr in dtProductGroup.Rows
                                select new ProductGroup
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    Name = $"{dr["id"]} - {dr["name"].ToString()}", // Kết hợp ID và Name thành một chuỗi

                                })
                                .ToList();
            this.cmbProductGroup.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbProductGroup.DataSource = listProductGroup;
            cmbProductGroup.DisplayMember = "Name";
            cmbProductGroup.ValueMember = "Id";
        }
        //load form
        private void frmGenreType_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.GenreType();
            dgvGenreType.DataSource = bdsource;
            //đổi font cho header
            dgvGenreType.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvGenreType.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvGenreType.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvGenreType.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvGenreType.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvGenreType.RowCount; i = i + 2)
            {
                dgvGenreType.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvGenreType;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 100;
                x.Columns[2].Width = 300;
                x.Columns[3].Width = 400;
            }
        }
        //hiển thị nội dung khi người dùng click vào dữ liệu trong datagrid view
        private void dgvGenreType_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvGenreType.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvGenreType.CurrentRow.Cells[3].Value.ToString();
                cmbProductGroup.Text = dgvGenreType.CurrentRow.Cells[2].Value.ToString();            }
            catch { }
        }
        //btn hủy tìm
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            frmGenreType genreType = new frmGenreType();
            this.Hide();
            genreType.Show();
        }
        // btn tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name=txtnameSearch.Text;
            string productGroup=cmbProductGroupSearch.Text;
            if (name != "" && productGroup != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_GenreType"));
                dv.RowFilter = string.Format("[Tên nhóm thể loại] like  '%{0}%'", name);
                dgvGenreType.DataSource = dv;
            }
            else if (name == "" && productGroup != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_GenreType"));
                dv.RowFilter = string.Format("[Nhóm sản phẩm] like  '%{0}%'", productGroup);
                dgvGenreType.DataSource = dv;
            }
        }
        //đóng form
        private void frmGenreType_FormClosing(object sender, FormClosingEventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
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
            //Xóa thông tin đang hiện trong các textbox
            txtName.Clear();
            txtId.Clear();
        }
        // btn về trạng thái ban đầu
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
        // btn Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string productGroup = cmbProductGroup.Text;
                string productGroupId = new string(productGroup.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("INSERT INTO GenreType (Name, ProductGroupId) values (N'" + name + "',N'" + int.Parse(productGroupId) + "')");
                MessageBox.Show("Thêm mới thành công");
                frmGenreType_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string genreTypeId = new string(id.Where(char.IsDigit).ToArray());
                string name = txtName.Text;
                string productGroup = cmbProductGroup.Text;
                string productGroupId = new string(productGroup.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("UPDATE GenreType SET Name =N'" + name + "', ProductGroupId='" + productGroupId + "' " +
                    "WHERE Id = N'" + int.Parse(genreTypeId) + "'");
                MessageBox.Show("Chỉnh sửa thành công");
                frmGenreType_Load(sender, e);
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
                    string genreTypeId = new string(id.Where(char.IsDigit).ToArray());
                    string name = txtName.Text;
                    string productGroup = cmbProductGroup.Text;
                    string productGroupId = new string(productGroup.Where(char.IsDigit).ToArray());
                    data.ExcuteNonQuery("DELETE FROM GenreType where Id='" + int.Parse(genreTypeId) + "'");
                    MessageBox.Show("Xóa thành công");
                    frmGenreType_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
