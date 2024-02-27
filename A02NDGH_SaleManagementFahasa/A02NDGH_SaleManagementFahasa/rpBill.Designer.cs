namespace Fahasa
{
    partial class rpBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.prodBillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fahasaBookStoreDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fahasaBookStoreDataSet = new Fahasa.FahasaBookStoreDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.prod_BillsTableAdapter = new Fahasa.FahasaBookStoreDataSetTableAdapters.prod_BillsTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prodBillsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // prodBillsBindingSource
            // 
            this.prodBillsBindingSource.DataMember = "prod_Bills";
            this.prodBillsBindingSource.DataSource = this.fahasaBookStoreDataSetBindingSource;
            // 
            // fahasaBookStoreDataSetBindingSource
            // 
            this.fahasaBookStoreDataSetBindingSource.DataSource = this.fahasaBookStoreDataSet;
            this.fahasaBookStoreDataSetBindingSource.Position = 0;
            // 
            // fahasaBookStoreDataSet
            // 
            this.fahasaBookStoreDataSet.DataSetName = "FahasaBookStoreDataSet";
            this.fahasaBookStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DatasetBill";
            reportDataSource2.Value = this.prodBillsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Fahasa.rpBill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(44, 110);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(740, 685);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // prod_BillsTableAdapter
            // 
            this.prod_BillsTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 42);
            this.label1.TabIndex = 22;
            this.label1.Text = "Lập phiếu tính tiền";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(188, 65);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(174, 26);
            this.txtId.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(40, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Mã đơn đặt hàng";
            // 
            // btnInvoice
            // 
            this.btnInvoice.BackColor = System.Drawing.Color.MistyRose;
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInvoice.Location = new System.Drawing.Point(482, 58);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(119, 37);
            this.btnInvoice.TabIndex = 30;
            this.btnInvoice.Text = "Xuất hóa đơn";
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBack.Location = new System.Drawing.Point(619, 60);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 37);
            this.btnBack.TabIndex = 61;
            this.btnBack.Text = "Quay về";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rpBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 834);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rpBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập phiếu tính tiền";
            this.Load += new System.EventHandler(this.rpBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prodBillsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FahasaBookStoreDataSet fahasaBookStoreDataSet;
        private System.Windows.Forms.BindingSource fahasaBookStoreDataSetBindingSource;
        private System.Windows.Forms.BindingSource prodBillsBindingSource;
        private FahasaBookStoreDataSetTableAdapters.prod_BillsTableAdapter prod_BillsTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnBack;
    }
}