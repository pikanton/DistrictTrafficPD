namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            introductionLabel = new Label();
            mainControl = new TabControl();
            tabViolation = new TabPage();
            dgvViolation = new DataGridView();
            tabRegistration = new TabPage();
            dgvRegistration = new DataGridView();
            tabLicense = new TabPage();
            dgvLicense = new DataGridView();
            mainMenuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            отчетыToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            mainControl.SuspendLayout();
            tabViolation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViolation).BeginInit();
            tabRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistration).BeginInit();
            tabLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLicense).BeginInit();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // introductionLabel
            // 
            introductionLabel.AutoSize = true;
            introductionLabel.Location = new Point(4, 483);
            introductionLabel.Name = "introductionLabel";
            introductionLabel.Size = new Size(38, 15);
            introductionLabel.TabIndex = 0;
            introductionLabel.Text = "label1";
            // 
            // mainControl
            // 
            mainControl.Controls.Add(tabViolation);
            mainControl.Controls.Add(tabRegistration);
            mainControl.Controls.Add(tabLicense);
            mainControl.Dock = DockStyle.Top;
            mainControl.Location = new Point(0, 24);
            mainControl.Name = "mainControl";
            mainControl.SelectedIndex = 0;
            mainControl.Size = new Size(829, 456);
            mainControl.TabIndex = 1;
            // 
            // tabViolation
            // 
            tabViolation.Controls.Add(dgvViolation);
            tabViolation.Location = new Point(4, 24);
            tabViolation.Name = "tabViolation";
            tabViolation.Padding = new Padding(3);
            tabViolation.Size = new Size(821, 428);
            tabViolation.TabIndex = 0;
            tabViolation.Text = "Нарушения";
            tabViolation.UseVisualStyleBackColor = true;
            // 
            // dgvViolation
            // 
            dgvViolation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViolation.Dock = DockStyle.Left;
            dgvViolation.Location = new Point(3, 3);
            dgvViolation.MultiSelect = false;
            dgvViolation.Name = "dgvViolation";
            dgvViolation.RowTemplate.Height = 25;
            dgvViolation.Size = new Size(606, 422);
            dgvViolation.TabIndex = 0;
            dgvViolation.DataSourceChanged += dgvViolation_DataSourceChanged;
            // 
            // tabRegistration
            // 
            tabRegistration.Controls.Add(dgvRegistration);
            tabRegistration.Location = new Point(4, 24);
            tabRegistration.Name = "tabRegistration";
            tabRegistration.Padding = new Padding(3);
            tabRegistration.Size = new Size(821, 428);
            tabRegistration.TabIndex = 1;
            tabRegistration.Text = "Регистрация";
            tabRegistration.UseVisualStyleBackColor = true;
            // 
            // dgvRegistration
            // 
            dgvRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistration.Dock = DockStyle.Left;
            dgvRegistration.Location = new Point(3, 3);
            dgvRegistration.MultiSelect = false;
            dgvRegistration.Name = "dgvRegistration";
            dgvRegistration.RowTemplate.Height = 25;
            dgvRegistration.Size = new Size(606, 422);
            dgvRegistration.TabIndex = 1;
            dgvRegistration.DataSourceChanged += dgvRegistration_DataSourceChanged;
            // 
            // tabLicense
            // 
            tabLicense.Controls.Add(dgvLicense);
            tabLicense.Location = new Point(4, 24);
            tabLicense.Name = "tabLicense";
            tabLicense.Size = new Size(821, 428);
            tabLicense.TabIndex = 2;
            tabLicense.Text = "Выдача ВУ";
            tabLicense.UseVisualStyleBackColor = true;
            // 
            // dgvLicense
            // 
            dgvLicense.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLicense.Dock = DockStyle.Left;
            dgvLicense.Location = new Point(0, 0);
            dgvLicense.MultiSelect = false;
            dgvLicense.Name = "dgvLicense";
            dgvLicense.RowTemplate.Height = 25;
            dgvLicense.Size = new Size(606, 428);
            dgvLicense.TabIndex = 1;
            dgvLicense.DataSourceChanged += dgvLicense_DataSourceChanged;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, отчетыToolStripMenuItem, справкаToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(829, 24);
            mainMenuStrip.TabIndex = 2;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // отчетыToolStripMenuItem
            // 
            отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            отчетыToolStripMenuItem.Size = new Size(60, 20);
            отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 533);
            Controls.Add(introductionLabel);
            Controls.Add(mainControl);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Name = "MainForm";
            Text = "ГАИ";
            FormClosed += MainForm_FormClosed;
            Load += Form1_Load;
            mainControl.ResumeLayout(false);
            tabViolation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvViolation).EndInit();
            tabRegistration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRegistration).EndInit();
            tabLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLicense).EndInit();
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label introductionLabel;
        private TabControl mainControl;
        private TabPage tabViolation;
        private TabPage tabRegistration;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private TabPage tabLicense;
        private DataGridView dgvViolation;
        private DataGridView dgvRegistration;
        private DataGridView dgvLicense;
    }
}