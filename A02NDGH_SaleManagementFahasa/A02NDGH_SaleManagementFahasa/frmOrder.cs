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
using System.Xml.Linq;
using static Fahasa.frmConfirmOrder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Reporting.WinForms;

namespace Fahasa
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
          
            InitializeComponent();
            cmbStatus.Items.Add("Chưa duyệt");
            cmbStatus.Items.Add("Đã duyệt");
            cmbStatus.Items.Add("Đã hủy đơn");
            // addDataComboboxEmployee();
            //addDataComboboxBranch();
            BaseController baseController = new BaseController(this);
            btnBackStatus.Enabled = false;
            btnBackStatus.BackColor = Color.Gainsboro;
        }
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        public class Branch
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public int AreaId { get; set; }
            public Branch() { }
            public Branch(int id, string name, string address, string phoneNumber, int areaId)
            {
                Id = id;
                Name = name;
                Address = address;
                PhoneNumber = phoneNumber;
                AreaId = areaId;
            }
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {

            bdsource.DataSource = data.Order();
            dgvOrder.DataSource = bdsource;
            dgvOrder.Columns[11].DefaultCellStyle.Format = "#,0.###";

            //đổi font cho header
            dgvOrder.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvOrder.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvOrder.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvOrder.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            //for (int i = 0; i < dgvOrder.RowCount; i = i + 2)
            //{
            //    dgvOrder.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            //}
            DataGridView x = dgvOrder;
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
                x.Columns[11].Width = 200;
            }
        }
        private void btnConfim_Click(object sender, EventArgs e)
        {
            string orderId = txtId.Text;
            string customer = txtCustomer.Text;
            string employee = txtEmployee.Text;
            string branch = txtBrand.Text;
            string orderDateText = txtOrderDate.Text;
            DateTime orderDate = DateTime.Parse(orderDateText);
            string status = txtStatus.Text;
            string total = txtTotal.Text;
            string note = txtNote.Text;
            string deliveryDate = txtDeliveryDate.Text;
            string receipient = txtReceipient.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            Order order = new Order(orderId, customer, employee, orderDate, phone, address, status, note, branch, total, receipient);
            frmConfirmOrder confirmOrder = new frmConfirmOrder(order);

            this.Hide();
            confirmOrder.Show();

        }

        private void dgvOrder_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvOrder.CurrentRow.Cells[1].Value.ToString();
                txtCustomer.Text = dgvOrder.CurrentRow.Cells[3].Value.ToString();
                txtEmployee.Text = dgvOrder.CurrentRow.Cells[4].Value.ToString();
                txtBrand.Text = dgvOrder.CurrentRow.Cells[5].Value.ToString();
                txtOrderDate.Text = dgvOrder.CurrentRow.Cells[6].Value.ToString();
                txtStatus.Text = dgvOrder.CurrentRow.Cells[2].Value.ToString();
                txtTotal.Text = formatNumber.FormatNumber(dgvOrder.CurrentRow.Cells[11].Value);
                txtNote.Text = dgvOrder.CurrentRow.Cells[12].Value.ToString();
                txtDeliveryDate.Text = dgvOrder.CurrentRow.Cells[7].Value.ToString();
                txtReceipient.Text = dgvOrder.CurrentRow.Cells[8].Value.ToString();
                txtPhone.Text = dgvOrder.CurrentRow.Cells[9].Value.ToString();
                txtAddress.Text = dgvOrder.CurrentRow.Cells[10].Value.ToString();

            }
            catch { }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

            string orderId = txtId.Text;
            string removeText = "ORD-";
            string result = orderId.Replace(removeText, "");
            frmOrderDetail orderDetail = new frmOrderDetail(result);
            this.Hide();
            orderDetail.Show();

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Chưa duyệt")
            {
                btnConfim.Enabled = true;
                btnConfim.BackColor = Color.MistyRose;
                btnSetBill.Enabled = false;
                btnSetBill.BackColor = Color.Gainsboro;
            }
            else if (txtStatus.Text == "Đã duyệt")
            {
                btnConfim.Enabled = false;
                btnConfim.BackColor = Color.Gainsboro;
                btnSetBill.Enabled = true;
                btnSetBill.BackColor = Color.MistyRose;
            }

        }

        private void btnSetBill_Click(object sender, EventArgs e)
        {
            
            string orderId = txtId.Text; //Tạo biến OrderId để lấy giá trị Id từ ô textbox
            string removeText = "ORD-";//bỏ
            string result = orderId.Replace(removeText, "");//bỏ
            rpBill orderDetail = new rpBill(result); //Chỗ này m bỏ 2 dòng trên thì gọi như này: rpBill orderDetail = new rpBill(orderId)
            this.Hide();
            orderDetail.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            frmOrder_Load(sender, e);
        }

        private void dgvOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string orderId = txtId.Text;
            string removeText = "ORD-";
            string result = orderId.Replace(removeText, "");
            frmOrderDetail orderDetail = new frmOrderDetail(result);
            this.Hide();
            orderDetail.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy đơn hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string id = txtId.Text;
                string removeText = "ORD-"; //t mún bỏ chữ ORD thì đặt 1 biến removeText = ORD 
                string orderId = id.Replace(removeText, ""); // dòng này gọi hàm để bỏ 
                Console.WriteLine("Bạn đã chọn Yes.");
                data.ExcuteNonQuery("UPDATE Orders set Note = N'Đã hủy đơn' WHERE Id =" +int.Parse(orderId));
                frmOrder_Load(sender, e);

            }
            else
            {
                Console.WriteLine("Bạn đã chọn No.");
                
            }
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            if (txtNote.Text == "Đã hủy đơn")
            {
                btnBackStatus.Enabled = true;
                btnBackStatus.BackColor = Color.MistyRose;
                btnCancel.Enabled = false;
                btnCancel.BackColor = Color.Gainsboro;
                btnSetBill.Enabled = false;
                btnSetBill.BackColor = Color.Gainsboro;
                btnConfim.Enabled = false;
                btnConfim.BackColor = Color.Gainsboro;
                txtStatus.BackColor = Color.Gainsboro;
                txtStatus.ForeColor = Color.Black;
                txtNote.ForeColor = Color.Red;
            }
            else if ((txtNote.Text != "Đã hủy đơn")|| (txtNote.Text == ""))
            {
                //btnConfim.Enabled = true;
                //btnConfim.BackColor = Color.MistyRose;
                btnBackStatus.Enabled = false;
                btnBackStatus.BackColor = Color.Gainsboro;
                btnCancel.Enabled = true;
                btnCancel.BackColor = Color.MistyRose;
                txtStatus.BackColor = Color.White;
                txtStatus.ForeColor = Color.Red;
                txtNote.ForeColor = Color.Black;
            }
            else if ((txtStatus.Text=="Đã duyệt") && (txtNote.Text!="Đã hủy đơn"))
            {
              btnConfim.Enabled = false;
               btnConfim.BackColor = Color.Gainsboro;
            }

        }

        private void btnBackStatus_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn bỏ hủy đơn hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string id = txtId.Text;
                string removeText = "ORD-"; //t mún bỏ chữ ORD thì đặt 1 biến removeText = ORD 
                string orderId = id.Replace(removeText, ""); // dòng này gọi hàm để bỏ 
                Console.WriteLine("Bạn đã chọn Yes.");
                data.ExcuteNonQuery("UPDATE Orders set Note = N'', Status=0 WHERE Id =" + int.Parse(orderId));
                frmOrder_Load(sender, e);
            }
            else
            {
                Console.WriteLine("Bạn đã chọn No.");

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtIdSearch.Text;
            string emp = txtEmpSearch.Text;
            string cus = txtCustomerSearch.Text;
            string status = cmbStatus.Text;

            if (id == "" && emp == "" && status =="" && cus !="")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Orders"));
                dv.RowFilter = string.Format("[Tên khách hàng] like  '%{0}%'", cus);
                dgvOrder.DataSource = dv;
            }

            else if (id == "" && emp == "" && status != "" && cus == "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Orders"));
                dv.RowFilter = string.Format("[Trạng thái] LIKE '%{0}%' OR [Ghi chú] LIKE '%{0}%'", status);
                dgvOrder.DataSource = dv;
            }
            else if (id == "" && emp != "" && status == "" && cus == "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Orders"));
                dv.RowFilter = string.Format("[Tên nhân viên] like  '%{0}%'", emp);
                dgvOrder.DataSource = dv;
            }
            else if (id != "" && emp == "" && status == "" && cus == "")
            {
                DataView dv = new DataView(data.ExcuteQuery("SELECT * FROM v_Orders"));
                dv.RowFilter = string.Format("[Mã đơn đặt hàng] like  '%{0}%'", id);
                dgvOrder.DataSource = dv;
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên để tìm kiếm");
            }
        }
    }
}
