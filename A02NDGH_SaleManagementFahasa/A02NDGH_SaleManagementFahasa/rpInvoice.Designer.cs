namespace Fahasa
{
    partial class rpInvoice
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.prodInvoiceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fahasaBookStoreDataSetInvoice = new Fahasa.FahasaBookStoreDataSetInvoice();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rpvInvoice = new Microsoft.Reporting.WinForms.ReportViewer();
            this.prodInvoiceBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.prodInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prod_InvoiceTableAdapter = new Fahasa.FahasaBookStoreDataSetInvoiceTableAdapters.prod_InvoiceTableAdapter();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prodInvoiceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSetInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodInvoiceBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodInvoiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // prodInvoiceBindingSource1
            // 
            this.prodInvoiceBindingSource1.DataMember = "prod_Invoice";
            this.prodInvoiceBindingSource1.DataSource = this.fahasaBookStoreDataSetInvoice;
            // 
            // fahasaBookStoreDataSetInvoice
            // 
            this.fahasaBookStoreDataSetInvoice.DataSetName = "FahasaBookStoreDataSetInvoice";
            this.fahasaBookStoreDataSetInvoice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(236, 82);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(231, 30);
            this.txtId.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(45, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 25);
            this.label7.TabIndex = 33;
            this.label7.Text = "Mã đơn đặt hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(404, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 52);
            this.label1.TabIndex = 32;
            this.label1.Text = "Xuất hóa đơn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rpvInvoice
            // 
            reportDataSource1.Name = "Invoice";
            reportDataSource1.Value = this.prodInvoiceBindingSource1;
            this.rpvInvoice.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvInvoice.LocalReport.ReportEmbeddedResource = "Fahasa.rpInvoice.rdlc";
            this.rpvInvoice.Location = new System.Drawing.Point(8, 132);
            this.rpvInvoice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rpvInvoice.Name = "rpvInvoice";
            this.rpvInvoice.ServerReport.BearerToken = null;
            this.rpvInvoice.Size = new System.Drawing.Size(1111, 956);
            this.rpvInvoice.TabIndex = 31;
            this.rpvInvoice.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // prodInvoiceBindingSource2
            // 
            this.prodInvoiceBindingSource2.DataMember = "prod_Invoice";
            this.prodInvoiceBindingSource2.DataSource = this.fahasaBookStoreDataSetInvoice;
            // 
            // prodInvoiceBindingSource
            // 
            this.prodInvoiceBindingSource.DataMember = "prod_Invoice";
            this.prodInvoiceBindingSource.DataSource = this.fahasaBookStoreDataSetInvoice;
            // 
            // prod_InvoiceTableAdapter
            // 
            this.prod_InvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MistyRose;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(972, 70);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(109, 42);
            this.btnBack.TabIndex = 35;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rpInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 1055);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rpvInvoice);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "rpInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất hóa đơn";
            this.Load += new System.EventHandler(this.rpInvoice_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.prodInvoiceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fahasaBookStoreDataSetInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodInvoiceBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodInvoiceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rpvInvoice;
        private FahasaBookStoreDataSetInvoice fahasaBookStoreDataSetInvoice;
        private System.Windows.Forms.BindingSource prodInvoiceBindingSource;
        private FahasaBookStoreDataSetInvoiceTableAdapters.prod_InvoiceTableAdapter prod_InvoiceTableAdapter;
        private System.Windows.Forms.BindingSource prodInvoiceBindingSource2;
        private System.Windows.Forms.BindingSource prodInvoiceBindingSource1;
        private System.Windows.Forms.Button btnBack;
    }
}