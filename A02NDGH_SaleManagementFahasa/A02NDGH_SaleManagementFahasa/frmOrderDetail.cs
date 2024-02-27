using Fahasa.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahasa
{

    public partial class frmOrderDetail : Form
    {
        String result = "";

        //public frmOrderDetail()
        //{
        //    InitializeComponent();
        //}
        public frmOrderDetail(String orderId)
        {
            BaseController baseController = new BaseController(this);
            InitializeComponent();
            this.result = orderId;
        }
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            string id = result.ToString();
            string str = "SELECT 'ORD-' + CAST(Orders.Id AS varchar) AS N'Mã đơn đặt hàng',Product.Name AS N'Tên sản phẩm', Quantity AS N'Số lượng',Price.DiscountedPrice AS N'Giá', Product.Thumbnail AS N'Thumbnail' FROM OrderDetail join Orders on OrderDetail.OrderId= Orders.Id join Product on OrderDetail.ProductId=Product.Id join Price on OrderDetail.ProductId= Price.ProductId WHERE OrderId='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvOrderDetail.DataSource = dt;
            dgvOrderDetail.Columns[4].Visible = false;
            //bdsource.DataSource = data.OrderDetail();
            //dgvOrderDetail.DataSource = bdsource;
            dgvOrderDetail.Columns[3].DefaultCellStyle.Format = "#,0.###";
            //đổi font cho header
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Romain", 12, FontStyle.Bold);
            //đổi font cho các hàng
            dgvOrderDetail.DefaultCellStyle.Font = new Font("Time New Romain", 12);
            //đổi màu cho header
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvOrderDetail.EnableHeadersVisualStyles = false;
            //đổi màu cho data gridview cách dòng
            for (int i = 0; i < dgvOrderDetail.RowCount; i = i + 2)
            {
                dgvOrderDetail.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            DataGridView x = dgvOrderDetail;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 350;
                x.Columns[2].Width = 100;
                x.Columns[3].Width = 100;
            }

            try
            {
                string nameImg = dgvOrderDetail.Rows[0].Cells["Thumbnail"].Value.ToString(); // Lấy tên ảnh từ TextBox
                Utils.loadImage(nameImg, thumbnail);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            this.Hide();
            order.Show();

        }
        
        private void dgvOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string nameImg = dgvOrderDetail.Rows[e.RowIndex].Cells["Thumbnail"].Value.ToString(); // Lấy tên ảnh từ TextBox
                Utils.loadImage(nameImg, thumbnail);
            }
            catch (Exception ex) { 
            
            }
        }
    }
}