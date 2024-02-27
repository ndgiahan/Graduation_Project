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
    public partial class frmInvoice : Form
    {
        public frmInvoice()
        {
            InitializeComponent();
            BaseController baseController = new BaseController(this);
        }
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();


        private void frmInvoice_Load(object sender, EventArgs e)
        {
            bdsource.DataSource = data.Invoice();
            dgvInvoice.DataSource = bdsource;
            //đổi font cho header
            dgvInvoice.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvInvoice.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvInvoice.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvInvoice.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            //for (int i = 0; i < dgvOrder.RowCount; i = i + 2)
            //{
            //    dgvOrder.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            //}
            DataGridView x = dgvInvoice;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 150;
                x.Columns[2].Width = 150;
                x.Columns[3].Width = 200;
                x.Columns[4].Width = 200;
                x.Columns[5].Width = 250;
                x.Columns[6].Width = 170;
                x.Columns[7].Width = 170;
                x.Columns[8].Width = 200;
                x.Columns[9].Width = 170;
                x.Columns[10].Width = 250;
            }
        }

        private void dgvInvoice_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvInvoice.CurrentRow.Cells[1].Value.ToString();
                txtCustomer.Text = dgvInvoice.CurrentRow.Cells[4].Value.ToString();
                txtEmployee.Text = dgvInvoice.CurrentRow.Cells[11].Value.ToString();
                txtBrand.Text = dgvInvoice.CurrentRow.Cells[10].Value.ToString();
                txtCreateDate.Text = dgvInvoice.CurrentRow.Cells[3].Value.ToString();
                txtTotal.Text = formatNumber.FormatNumber(dgvInvoice.CurrentRow.Cells[9].Value);
                txtDeliveryDate.Text = dgvInvoice.CurrentRow.Cells[5].Value.ToString();
                txtPhone.Text = dgvInvoice.CurrentRow.Cells[7].Value.ToString();
                txtAddress.Text = dgvInvoice.CurrentRow.Cells[6].Value.ToString();

            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtIdSearch.Text;
            string cus = txtCustomerSearch.Text;


            if (id == "" && cus != "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Invoice"));
                dv.RowFilter = string.Format("[Khách hàng] like  '%{0}%'", cus);
                dgvInvoice.DataSource = dv;
            }

            else if (id != "" && cus == "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Invoice"));
                dv.RowFilter = string.Format("[Mã hóa đơn] LIKE '%{0}%' OR [Ghi chú] LIKE '%{0}%'", id);
                dgvInvoice.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
    }
}
