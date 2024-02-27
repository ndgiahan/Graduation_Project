using Fahasa.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fahasa
{
    public partial class frmPrice : Form
    {
        public frmPrice()
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
        }
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        private void frmPrice_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Price();
            dgvPrice.DataSource = bdsource;
            //format number cho datagridview
            dgvPrice.Columns[3].DefaultCellStyle.Format= "#,0.###";
            dgvPrice.Columns[4].DefaultCellStyle.Format = "#,0.###";
            dgvPrice.Columns[5].DefaultCellStyle.Format = "#,0.###";
            dgvPrice.Columns[6].DefaultCellStyle.Format = "#,0.###";
            //đổi font cho header
            dgvPrice.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPrice.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvPrice.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvPrice.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvPrice.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvPrice.RowCount; i = i + 2)
            {
                dgvPrice.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvPrice;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 350;
                x.Columns[2].Width = 150;
                x.Columns[3].Width = 150;
                x.Columns[4].Width = 150;
                x.Columns[5].                                                                           Width = 150;
            }
        }
        private void dgvPrice_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtProduct.Text = dgvPrice.CurrentRow.Cells[1].Value.ToString();
                txtImg.Text = dgvPrice.CurrentRow.Cells[2].Value.ToString();
                txtPurchasePrice.Text = formatNumber.FormatNumber(dgvPrice.CurrentRow.Cells[3].Value);
                txtRetailPrice.Text = formatNumber.FormatNumber(dgvPrice.CurrentRow.Cells[4].Value);
                txtWholePrice.Text = formatNumber.FormatNumber(dgvPrice.CurrentRow.Cells[5].Value);
                txtSalePrice.Text = formatNumber.FormatNumber(dgvPrice.CurrentRow.Cells[6].Value);
            }
            catch { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string product = txtProductSearch.Text;
            //string productGroup=cmbProductGroup.Text;

            if (product != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Price"));
                dv.RowFilter = string.Format("[Tên sản phẩm] like  '%{0}%'", product);
                dgvPrice.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmPrice_Load(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
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
