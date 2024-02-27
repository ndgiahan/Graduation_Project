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
    public partial class rpBill : Form
    {
        String result = "";
        public rpBill(string orderId)
        {
            InitializeComponent();
            BaseController baseController = new BaseController(this);
            this.result = orderId;
        }
        private void rpBill_Load(object sender, EventArgs e)
        {
            string x = "ORD-";
            string id = result.ToString();
            txtId.Text = string.Concat(x, id); 
            this.prod_BillsTableAdapter.Fill(this.fahasaBookStoreDataSet.prod_Bills, int.Parse(id));
            this.reportViewer1.RefreshReport();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            rpInvoice invoice = new rpInvoice(result);
            this.Hide();
            invoice.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            this.Hide();
            order.Show();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
