using Fahasa.Models;
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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            BaseController baseController = new BaseController(this);
        }
        private void tsmiGenreType_Click(object sender, EventArgs e)
        {
            frmGenreType genreType = new frmGenreType();
            this.Hide();
            genreType.Show();
        }
        private void tsmiGenre_Click(object sender, EventArgs e)
        {
            frmGenre genre = new frmGenre();
            this.Hide();
            genre.Show();
        }
        private void tsmiProduct_Click(object sender, EventArgs e)
        {
            frmProduct product = new frmProduct();
            this.Hide();
            product.Show();
        }
        private void tsmiPublisher_Click(object sender, EventArgs e)
        {
            frmPublisher publisher = new frmPublisher();
            this.Hide();
            publisher.Show();
        }
        private void tsmiSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier supplier = new frmSupplier();
            this.Hide();
            supplier.Show();
        }

        private void tsmiBrand_Click(object sender, EventArgs e)
        {
            frmBrand brand = new frmBrand();
            this.Hide();
            brand.Show();
        }
        private void tsmiInventory_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();
            this.Hide();
            inventory.Show();
        }

        private void tsmiOrder_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            this.Hide();
            order.Show();
        }

        private void tsmiInvoice_Click(object sender, EventArgs e)
        {
            frmInvoice invoice = new frmInvoice();
            this.Hide();
            invoice.ShowDialog();
            this.Show();

        }
        private void danhMụcGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrice price = new frmPrice();
            this.Hide();
            price.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            CacheController cache = new CacheController();
            var staff = cache.GetCacheStaff();
            txtName.Text = staff.Name;
            txtBranch.Text = staff.BranchName;
            txtPosition.Text = staff.PositionName;
        }
        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            this.Hide();
            customer.Show();
        }
        private void danhMụcKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee employee = new frmEmployee();
            this.Hide();
            employee.Show();
        }

        private void danhMụcChiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranch branch = new frmBranch();
            this.Hide();
            branch.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tsmiProductList_Click(object sender, EventArgs e)
        {

        }

        private void tsmiGenre_Click_1(object sender, EventArgs e)
        {
            frmGenre genre = new frmGenre();
            this.Hide();
            genre.Show();
        }

        private void tsmiGenreType_Click_1(object sender, EventArgs e)
        {
            frmGenreType genreType = new frmGenreType();   
            this.Hide();
            genreType.Show();
        }

        private void danhMụcGiáToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPrice price = new frmPrice();
            this.Show();
            price.Show();
        }
    }
}
