using Fahasa.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fahasa
{
    public partial class frmConfirmOrder : Form
    {
        public frmConfirmOrder(Order order)
        {
            BaseController baseController = new BaseController(this);
            this.order = order;
            InitializeComponent();
            btnConfim.Enabled = false;
            btnConfim.BackColor = Color.Gainsboro; // Đặt màu nền là màu xám
            btnConfim.ForeColor = Color.Black; // Đặt màu chữ là màu đen


        }
        Connect data = new Connect();

        Order order;
        public class Order
        {
            public string Id { get; set; }
            public string CustomerId { get; set; }
            public string EmployeeId { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
            public string Note { get; set; }
            public string BranchId { get; set; }
            public string Total { get; set; }
            public string Recipient { get; set; }

            public Order() { }
            public Order(string id, string customerId, string employeeId, DateTime orderDate, string phoneNumber, string address, string status, string note, string branchId, string total, string recipient)
            {
                Id = id;
                CustomerId = customerId;
                EmployeeId = employeeId;
                OrderDate = orderDate;
                // DeliveryDate = deliveryDate;
                PhoneNumber = phoneNumber;
                Address = address;
                Status = status;
                Note = note;
                BranchId = branchId;
                Total = total;
                Recipient = recipient;
            }
        }
        //Load form
        private void frmConfirmOrder_Load(object sender, EventArgs e)
        {
            CacheController cache = new CacheController();
            var staff = cache.GetCacheStaff();
            txtEmployee.Text = staff.Name;
            txtId.Text = this.order.Id;
            txtCustomer.Text = this.order.CustomerId;
            //txtEmployee.Text=this.order.EmployeeId;
            txtBranch.Text = this.order.BranchId;
            txtOrderDate.Text = this.order.OrderDate.ToString();
            txtStatus.Text = this.order.Status.ToString();
            txtTotal.Text = this.order.Total;
            txtReceipient.Text = this.order.Recipient;
            txtPhone.Text = this.order.PhoneNumber;
            txtAddress.Text = this.order.Address;

        }
        //btnBack - quay về form order
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            this.Hide();
            order.Show();
        }


        //Cập nhật trạng thái từ chưa duyệt thành duyệt
        //Cập nhật ngày giao hàng
        //Cập nhật ghi chú (nếu có)
        //Thông báo duyệt thành công
        private void btnConfim_Click(object sender, EventArgs e)
        {
            string x = txtNote.Text;
            string delivery = dtpDeliveryDate.Text;
            string orderId = txtId.Text;
            string removeText = "ORD-";
            string result = orderId.Replace(removeText, "");
            string emp = txtEmployee.Text;
            data.ExcuteNonQuery("UPDATE Orders set Status=1, DeliveryDate= '" + DateTime.Parse(delivery) + "',Note='" + x + "',EmployeeId=1 WHERE Id =" + result);
            MessageBox.Show("Duyệt thành công!", "Thông báo");
            this.Hide();
            frmOrder order = new frmOrder();
            order.Show();
        }

        private void dtpDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime selectedDate = dtpDeliveryDate.Value;
            TimeSpan difference = selectedDate - currentDate;
            int daysDifference = Math.Abs(difference.Days);

            if (selectedDate.Date < currentDate.Date)
            {
                lblMessage.Text = "Ngày giao hàng không được bé hơn ngày hiện tại!";
                btnConfim.Enabled = false;
                btnConfim.BackColor = Color.Gainsboro; // Đặt màu nền là màu xám
                btnConfim.ForeColor = Color.Black; // Đặt màu chữ là màu đen
            }
            else
            {
                btnConfim.BackColor = Color.MistyRose; // Đặt màu nền là màu xám
                btnConfim.ForeColor = Color.Black; // Đặt màu chữ là màu đen
                lblMessage.Text = "";
                btnConfim.Enabled = true;
            }
        }
    }
}
