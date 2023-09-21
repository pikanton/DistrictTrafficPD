namespace Reports
{
    partial class ReportForm
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.studTrainingDataSourse = new Reports.StudTrainingDataSourse();
            this.studTrainingDataSourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.studTrainingDataSourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studTrainingDataSourseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MainDataSet";
            reportDataSource1.Value = this.studTrainingDataSourseBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Reports.Report1.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(954, 561);
            this.reportViewer.TabIndex = 0;
            // 
            // studTrainingDataSourse
            // 
            this.studTrainingDataSourse.DataSetName = "StudTrainingDataSourse";
            this.studTrainingDataSourse.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studTrainingDataSourseBindingSource
            // 
            this.studTrainingDataSourseBindingSource.DataSource = this.studTrainingDataSourse;
            this.studTrainingDataSourseBindingSource.Position = 0;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 561);
            this.Controls.Add(this.reportViewer);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Количество проступков студентов";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studTrainingDataSourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studTrainingDataSourseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource studTrainingDataSourseBindingSource;
        private StudTrainingDataSourse studTrainingDataSourse;
    }
}