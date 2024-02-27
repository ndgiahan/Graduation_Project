using Fahasa.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Fahasa.frmProduct;

namespace Fahasa
{
    public partial class frmGenre : Form
    {
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public frmGenre()
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            addDataComboboxGenreType();
            addDataComboboxGenreTypeSearch();
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
        //khởi tạo đối tượng GenreType
        public class GenreType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ProductGroupId { get; set; }
            public GenreType() { }
            public GenreType(int id, string name, int productGroupId)
            {
                Id = id;
                Name = name;
                ProductGroupId = productGroupId;
            }
        }
        // thêm dữ liệu vào combobox nhóm thể loại cho tìm kiếm
        private void addDataComboboxGenreTypeSearch()
        {
            string str = @"select [id], [name], [productGroupId]  from GenreType";
            List<GenreType> listGenreType = new List<GenreType>();
            var dtGenreType = data.ExcuteQuery(str);
            listGenreType = (from DataRow dr in dtGenreType.Rows
                             select new GenreType
                             {
                                 Id = Convert.ToInt32(dr["id"]),
                                 Name = dr["name"].ToString(),
                                 ProductGroupId = Convert.ToInt32(dr["productGroupId"]),
                             })
                                .ToList();
            this.cmbGenreTypeSearch.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbGenreTypeSearch.DataSource = listGenreType;
            cmbGenreTypeSearch.DisplayMember = "Name";
            cmbGenreTypeSearch.ValueMember = "Id";
        }
        // thêm dữ liệu vào combobox nhóm thể loại
        private void addDataComboboxGenreType()
        {
            string str = @"select [id], [name], [productGroupId]  from GenreType";
            List<GenreType> listGenreType = new List<GenreType>();
            var dtGenreType = data.ExcuteQuery(str);
            listGenreType = (from DataRow dr in dtGenreType.Rows
                             select new GenreType
                             {
                                 Id = Convert.ToInt32(dr["id"]),
                                 Name = $"{dr["id"]} - {dr["name"].ToString()}", // Kết hợp ID và Name thành một chuỗi
                                 ProductGroupId = Convert.ToInt32(dr["productGroupId"]),
                             })
                                .ToList();
            this.cmbGenreType.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbGenreType.DataSource = listGenreType;
            cmbGenreType.DisplayMember = "Name";
            cmbGenreType.ValueMember = "Id";
        }
        //load form
        private void frmGenre_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Genre();
            dgvGenre.DataSource = bdsource;
            //đổi font cho header
            dgvGenre.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvGenre.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvGenre.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvGenre.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvGenre.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvGenre.RowCount; i = i + 2)
            {
                dgvGenre.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            //chỉnh kích thước cho các cột
            DataGridView x = dgvGenre;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 100;
                x.Columns[2].Width = 250;
                x.Columns[3].Width = 450;
            }
        }
        //hiển thị nội dung khi người dùng click vào dữ liệu trong datagrid view
        private void dgvGenre_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvGenre.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvGenre.CurrentRow.Cells[3].Value.ToString();
                cmbGenreType.Text = dgvGenre.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }
        // btn tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtnameSearch.Text;
            string genreType = cmbGenreTypeSearch.Text;

            if (name != "" && genreType != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Genre"));
                dv.RowFilter = string.Format("[Tên thể loại] like  '%{0}%'", name);
                dgvGenre.DataSource = dv;
            }
            else if (name == "" && genreType != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Genre"));
                dv.RowFilter = string.Format("[Nhóm thể loại] like  '%{0}%'", genreType);
                dgvGenre.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
        // đóng form
        private void frmGenre_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //btn về trang chủ
        private void btnExit_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }
        // btn hủy tìm
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmGenre_Load(sender, e);
        }
        // btn thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string genreType = cmbGenreType.Text;
                string genreTypeId = new string(genreType.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("INSERT INTO Genre (Name, GenreTypeId) values (N'" + name + "',N'" + int.Parse(genreTypeId) + "')");
                MessageBox.Show("Thêm mới thành công");
                frmGenre_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        // btn chỉnh
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string genreId = new string(id.Where(char.IsDigit).ToArray());
                string name = txtName.Text;
                string genreType = cmbGenreType.Text;
                string genreTypeId = new string(genreType.Where(char.IsDigit).ToArray());
                data.ExcuteNonQuery("UPDATE Genre SET Name =N'" + name + "', GenreTypeId='" + genreTypeId + "' WHERE Id = N'" + int.Parse(genreId) + "'");
                MessageBox.Show("Chỉnh sửa thành công");
                frmGenre_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //btn xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string id = txtId.Text;
                    string genreId = new string(id.Where(char.IsDigit).ToArray());
                    string name = txtName.Text;
                    string genreType = cmbGenreType.Text;
                    string genreTypeId = new string(genreType.Where(char.IsDigit).ToArray());
                    data.ExcuteNonQuery("DELETE FROM Genre where Id='" + int.Parse(genreId) + "'");
                    MessageBox.Show("Xóa thành công");
                    frmGenre_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
        //btn quay về trạng thái ban đầu
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
