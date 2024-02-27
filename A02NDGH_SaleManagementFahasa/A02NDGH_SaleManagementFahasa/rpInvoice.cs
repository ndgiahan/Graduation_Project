using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Fahasa.frmConfirmOrder;

namespace Fahasa
{
    public partial class rpInvoice : Form
    {
        String result = "";
        public rpInvoice(string orderId)
        {
            InitializeComponent();
            BaseController baseController = new BaseController(this);
            this.result = orderId;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void rpInvoice_Load_1(object sender, EventArgs e)
        {
            string x = "ORD-";
            string id = result.ToString();
            txtId.Text = string.Concat(x, id); ;
            this.prod_InvoiceTableAdapter.Fill(this.fahasaBookStoreDataSetInvoice.prod_Invoice, int.Parse(id));
            var y = prod_InvoiceTableAdapter.GetData(int.Parse(id));
            this.rpvInvoice.RefreshReport();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            rpBill orderDetail = new rpBill(result);
            this.Hide();
            orderDetail.Show();
        }
    }
}
