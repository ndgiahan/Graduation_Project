using Fahasa.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static Fahasa.frmProduct;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fahasa
{
    public partial class frmProduct : Form
    {
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
        public class ProductGroup
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ProductGroup() { }
            public ProductGroup(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        public class Genre
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int GenreTypeId { get; set; }
            public Genre() { }
            public Genre(int id, string name)
            {
                Id = id;
                Name = name;
                GenreTypeId = GenreTypeId;
            }
        }
        public frmProduct()// load page
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            addDataComboboxProductGroup();
        }

        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        private void addDataComboboxProductGroup()
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
            this.cmbProductGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductGroup.DataSource = listProductGroup;
            cmbProductGroup.DisplayMember = "Name";
            cmbProductGroup.ValueMember = "Id";
        }

        private void addDataComboboxGenreType(int productGroupId)
        {
            string str = @"select [id], [name], [ProductGroupId] from GenreType WHERE [ProductGroupId] = " + productGroupId;
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
            this.cmbGenreType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenreType.DataSource = listGenreType;
            cmbGenreType.DisplayMember = "Name";
            cmbGenreType.ValueMember = "Id";
        }
        private void cmbProductGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            var idString = cmbProductGroup.SelectedValue.ToString();
            int parsedInt = 0;
            if (int.TryParse(idString, out parsedInt))
            {
                addDataComboboxGenreType(parsedInt);
                // Code for if the string was valid
            }
        }

        private void addDataComboboxGenre(int genreTypeId)
        {
            string str = @"select [id], [name], [GenreTypeId] from Genre WHERE [GenreTypeId] = " + genreTypeId;
            List<Genre> listGenre = new List<Genre>();
            var dtGenre = data.ExcuteQuery(str);
            listGenre = (from DataRow dr in dtGenre.Rows
                         select new Genre
                         {
                             Id = Convert.ToInt32(dr["id"]),
                             Name = dr["name"].ToString(),
                             GenreTypeId = Convert.ToInt32(dr["genreTypeId"]),
                         })
                                .ToList();
            this.cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.DataSource = listGenre;
            cmbGenre.DisplayMember = "Name";
            cmbGenre.ValueMember = "Id";
        }

        private void cmbGenreType_SelectedValueChanged(object sender, EventArgs e)
        {
            var idString = cmbGenreType.SelectedValue.ToString();
            int parsedInt = 0;
            if (int.TryParse(idString, out parsedInt))
            {
                addDataComboboxGenre(parsedInt);
                // Code for if the string was valid
            }
            else
            {
                // Code for if the string was invalid
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Product();
            dgvProduct.DataSource = bdsource;
            //đổi font cho header
            dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvProduct.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvProduct.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvProduct.RowCount; i = i + 2)
            {
                dgvProduct.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvProduct;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 200;
                x.Columns[2].Width = 300;
                x.Columns[3].Width = 250;
                x.Columns[4].Width = 300;
                x.Columns[5].Width = 200;
                x.Columns[6].Width = 200;
                x.Columns[7].Width = 100;
                x.Columns[8].Width = 200;
                x.Columns[9].Width = 300;
                x.Columns[10].Width = 250;
                x.Columns[11].Width = 300;
            }
        }
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvProduct.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvProduct.CurrentRow.Cells[2].Value.ToString();
                txtGenre.Text = dgvProduct.CurrentRow.Cells[3].Value.ToString();
                txtImg.Text = dgvProduct.CurrentRow.Cells[4].Value.ToString();
                txtPublisher.Text = dgvProduct.CurrentRow.Cells[8].Value.ToString();
                txtSupplier.Text = dgvProduct.CurrentRow.Cells[9].Value.ToString();
                txtDescription.Text = dgvProduct.CurrentRow.Cells[7].Value.ToString();
                txtBrand.Text = dgvProduct.CurrentRow.Cells[10].Value.ToString();
                txtAuthor.Text = dgvProduct.CurrentRow.Cells[11].Value.ToString();
            }
            catch { }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtNameSearch.Text;
            string genre = cmbGenre.Text;

            if (name != "" && genre != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Product"));
                dv.RowFilter = string.Format("[Tên] like  '%{0}%'", name);
                dgvProduct.DataSource = dv;
            }
            else if (name == "" && genre != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Product"));
                dv.RowFilter = string.Format("[Thể loại] like  '%{0}%'", genre);
                dgvProduct.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            frmProduct_Load(sender,e);
        }

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
    }
}
