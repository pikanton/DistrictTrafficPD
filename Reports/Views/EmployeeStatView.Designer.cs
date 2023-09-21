namespace Reports.Views
{
    partial class EmployeeStatView
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
            this.гАИ2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.гАИ2DataSet = new Reports.ГАИ2DataSet();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.гАИ2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.гАИ2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // гАИ2DataSetBindingSource
            // 
            this.гАИ2DataSetBindingSource.DataSource = this.гАИ2DataSet;
            this.гАИ2DataSetBindingSource.Position = 0;
            // 
            // гАИ2DataSet
            // 
            this.гАИ2DataSet.DataSetName = "ГАИ2DataSet";
            this.гАИ2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EmployeeStatDataSet";
            reportDataSource1.Value = this.гАИ2DataSetBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Reports.Reports.EmployeeStat.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(775, 464);
            this.reportViewer.TabIndex = 0;
            // 
            // EmployeeStatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 464);
            this.Controls.Add(this.reportViewer);
            this.Name = "EmployeeStatView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика сотрудников";
            this.Load += new System.EventHandler(this.EmployeeStatView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.гАИ2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.гАИ2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource гАИ2DataSetBindingSource;
        private ГАИ2DataSet гАИ2DataSet;
    }
}