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
            deleteViolationButton = new Button();
            updateViolationButton = new Button();
            addViolationButton = new Button();
            dgvViolation = new DataGridView();
            tabRegistration = new TabPage();
            deleteRegistrationButton = new Button();
            updateRegistrationButton = new Button();
            addRegistrationButton = new Button();
            dgvRegistration = new DataGridView();
            tabLicense = new TabPage();
            deleteLicenseExtButton = new Button();
            deleteLicenseButton = new Button();
            updateLicenseButton = new Button();
            addLicenseButton = new Button();
            dgvLicense = new DataGridView();
            tabDrivers = new TabPage();
            deleteDriverButton = new Button();
            updateDriverButton = new Button();
            addDriverButton = new Button();
            dgvDrivers = new DataGridView();
            tabCars = new TabPage();
            deleteCarButton = new Button();
            updateCarButton = new Button();
            addCarButton = new Button();
            dgvCars = new DataGridView();
            tabDirectories = new TabPage();
            directoryCB = new ComboBox();
            deleteDIrectoryButton = new Button();
            updateDirectoryButton = new Button();
            addDirectoryButton = new Button();
            dgvDirectories = new DataGridView();
            tabRollBack = new TabPage();
            rollBackButton = new Button();
            dgvRollBack = new DataGridView();
            mainMenuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            отчетыToolStripMenuItem = new ToolStripMenuItem();
            нарушенийВодителейЗаПериодToolStripMenuItem = new ToolStripMenuItem();
            эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem = new ToolStripMenuItem();
            сотрудникиToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            mainControl.SuspendLayout();
            tabViolation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViolation).BeginInit();
            tabRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistration).BeginInit();
            tabLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLicense).BeginInit();
            tabDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).BeginInit();
            tabCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            tabDirectories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDirectories).BeginInit();
            tabRollBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRollBack).BeginInit();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // introductionLabel
            // 
            introductionLabel.AutoSize = true;
            introductionLabel.Location = new Point(4, 556);
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
            mainControl.Controls.Add(tabDrivers);
            mainControl.Controls.Add(tabCars);
            mainControl.Controls.Add(tabDirectories);
            mainControl.Controls.Add(tabRollBack);
            mainControl.Dock = DockStyle.Top;
            mainControl.Location = new Point(0, 24);
            mainControl.Name = "mainControl";
            mainControl.SelectedIndex = 0;
            mainControl.Size = new Size(1021, 529);
            mainControl.TabIndex = 1;
            // 
            // tabViolation
            // 
            tabViolation.Controls.Add(deleteViolationButton);
            tabViolation.Controls.Add(updateViolationButton);
            tabViolation.Controls.Add(addViolationButton);
            tabViolation.Controls.Add(dgvViolation);
            tabViolation.Location = new Point(4, 24);
            tabViolation.Name = "tabViolation";
            tabViolation.Padding = new Padding(3);
            tabViolation.Size = new Size(1013, 501);
            tabViolation.TabIndex = 0;
            tabViolation.Text = "Нарушения";
            tabViolation.UseVisualStyleBackColor = true;
            // 
            // deleteViolationButton
            // 
            deleteViolationButton.Location = new Point(850, 200);
            deleteViolationButton.Name = "deleteViolationButton";
            deleteViolationButton.Size = new Size(119, 44);
            deleteViolationButton.TabIndex = 3;
            deleteViolationButton.Text = "Удалить";
            deleteViolationButton.UseVisualStyleBackColor = true;
            deleteViolationButton.Click += deleteViolationButton_Click;
            // 
            // updateViolationButton
            // 
            updateViolationButton.Location = new Point(850, 120);
            updateViolationButton.Name = "updateViolationButton";
            updateViolationButton.Size = new Size(119, 44);
            updateViolationButton.TabIndex = 2;
            updateViolationButton.Text = "Изменить";
            updateViolationButton.UseVisualStyleBackColor = true;
            updateViolationButton.Click += updateViolationButton_Click;
            // 
            // addViolationButton
            // 
            addViolationButton.Location = new Point(850, 40);
            addViolationButton.Name = "addViolationButton";
            addViolationButton.Size = new Size(119, 44);
            addViolationButton.TabIndex = 1;
            addViolationButton.Text = "Добавить";
            addViolationButton.UseVisualStyleBackColor = true;
            addViolationButton.Click += addViolationButton_Click;
            // 
            // dgvViolation
            // 
            dgvViolation.AllowUserToAddRows = false;
            dgvViolation.AllowUserToDeleteRows = false;
            dgvViolation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViolation.Dock = DockStyle.Left;
            dgvViolation.Location = new Point(3, 3);
            dgvViolation.MultiSelect = false;
            dgvViolation.Name = "dgvViolation";
            dgvViolation.RowTemplate.Height = 25;
            dgvViolation.Size = new Size(802, 495);
            dgvViolation.TabIndex = 0;
            // 
            // tabRegistration
            // 
            tabRegistration.Controls.Add(deleteRegistrationButton);
            tabRegistration.Controls.Add(updateRegistrationButton);
            tabRegistration.Controls.Add(addRegistrationButton);
            tabRegistration.Controls.Add(dgvRegistration);
            tabRegistration.Location = new Point(4, 24);
            tabRegistration.Name = "tabRegistration";
            tabRegistration.Padding = new Padding(3);
            tabRegistration.Size = new Size(1013, 501);
            tabRegistration.TabIndex = 1;
            tabRegistration.Text = "Регистрация";
            tabRegistration.UseVisualStyleBackColor = true;
            // 
            // deleteRegistrationButton
            // 
            deleteRegistrationButton.Location = new Point(850, 200);
            deleteRegistrationButton.Name = "deleteRegistrationButton";
            deleteRegistrationButton.Size = new Size(119, 44);
            deleteRegistrationButton.TabIndex = 6;
            deleteRegistrationButton.Text = "Удалить";
            deleteRegistrationButton.UseVisualStyleBackColor = true;
            deleteRegistrationButton.Click += deleteRegistrationButton_Click;
            // 
            // updateRegistrationButton
            // 
            updateRegistrationButton.Location = new Point(850, 120);
            updateRegistrationButton.Name = "updateRegistrationButton";
            updateRegistrationButton.Size = new Size(119, 44);
            updateRegistrationButton.TabIndex = 5;
            updateRegistrationButton.Text = "Изменить";
            updateRegistrationButton.UseVisualStyleBackColor = true;
            updateRegistrationButton.Click += updateRegistrationButton_Click;
            // 
            // addRegistrationButton
            // 
            addRegistrationButton.Location = new Point(850, 40);
            addRegistrationButton.Name = "addRegistrationButton";
            addRegistrationButton.Size = new Size(119, 44);
            addRegistrationButton.TabIndex = 4;
            addRegistrationButton.Text = "Добавить";
            addRegistrationButton.UseVisualStyleBackColor = true;
            addRegistrationButton.Click += addRegistrationButton_Click;
            // 
            // dgvRegistration
            // 
            dgvRegistration.AllowUserToAddRows = false;
            dgvRegistration.AllowUserToDeleteRows = false;
            dgvRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistration.Dock = DockStyle.Left;
            dgvRegistration.Location = new Point(3, 3);
            dgvRegistration.MultiSelect = false;
            dgvRegistration.Name = "dgvRegistration";
            dgvRegistration.RowTemplate.Height = 25;
            dgvRegistration.Size = new Size(802, 495);
            dgvRegistration.TabIndex = 1;
            // 
            // tabLicense
            // 
            tabLicense.Controls.Add(deleteLicenseExtButton);
            tabLicense.Controls.Add(deleteLicenseButton);
            tabLicense.Controls.Add(updateLicenseButton);
            tabLicense.Controls.Add(addLicenseButton);
            tabLicense.Controls.Add(dgvLicense);
            tabLicense.Location = new Point(4, 24);
            tabLicense.Name = "tabLicense";
            tabLicense.Size = new Size(1013, 501);
            tabLicense.TabIndex = 2;
            tabLicense.Text = "Выдача ВУ";
            tabLicense.UseVisualStyleBackColor = true;
            // 
            // deleteLicenseExtButton
            // 
            deleteLicenseExtButton.Location = new Point(850, 373);
            deleteLicenseExtButton.Name = "deleteLicenseExtButton";
            deleteLicenseExtButton.Size = new Size(119, 97);
            deleteLicenseExtButton.TabIndex = 10;
            deleteLicenseExtButton.Text = "Удаление водительских удостоверений, которые были продлены";
            deleteLicenseExtButton.UseVisualStyleBackColor = true;
            deleteLicenseExtButton.Click += deleteLicenseExtButton_Click;
            // 
            // deleteLicenseButton
            // 
            deleteLicenseButton.Location = new Point(850, 200);
            deleteLicenseButton.Name = "deleteLicenseButton";
            deleteLicenseButton.Size = new Size(119, 44);
            deleteLicenseButton.TabIndex = 9;
            deleteLicenseButton.Text = "Удалить";
            deleteLicenseButton.UseVisualStyleBackColor = true;
            deleteLicenseButton.Click += deleteLicenseButton_Click;
            // 
            // updateLicenseButton
            // 
            updateLicenseButton.Location = new Point(850, 120);
            updateLicenseButton.Name = "updateLicenseButton";
            updateLicenseButton.Size = new Size(119, 44);
            updateLicenseButton.TabIndex = 8;
            updateLicenseButton.Text = "Изменить";
            updateLicenseButton.UseVisualStyleBackColor = true;
            updateLicenseButton.Click += updateLicenseButton_Click;
            // 
            // addLicenseButton
            // 
            addLicenseButton.Location = new Point(850, 40);
            addLicenseButton.Name = "addLicenseButton";
            addLicenseButton.Size = new Size(119, 44);
            addLicenseButton.TabIndex = 7;
            addLicenseButton.Text = "Добавить";
            addLicenseButton.UseVisualStyleBackColor = true;
            addLicenseButton.Click += addLicenseButton_Click;
            // 
            // dgvLicense
            // 
            dgvLicense.AllowUserToAddRows = false;
            dgvLicense.AllowUserToDeleteRows = false;
            dgvLicense.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLicense.Location = new Point(3, 3);
            dgvLicense.MultiSelect = false;
            dgvLicense.Name = "dgvLicense";
            dgvLicense.RowTemplate.Height = 25;
            dgvLicense.Size = new Size(802, 495);
            dgvLicense.TabIndex = 1;
            // 
            // tabDrivers
            // 
            tabDrivers.Controls.Add(deleteDriverButton);
            tabDrivers.Controls.Add(updateDriverButton);
            tabDrivers.Controls.Add(addDriverButton);
            tabDrivers.Controls.Add(dgvDrivers);
            tabDrivers.Location = new Point(4, 24);
            tabDrivers.Name = "tabDrivers";
            tabDrivers.Size = new Size(1013, 501);
            tabDrivers.TabIndex = 3;
            tabDrivers.Text = "Водители";
            tabDrivers.UseVisualStyleBackColor = true;
            // 
            // deleteDriverButton
            // 
            deleteDriverButton.Location = new Point(850, 200);
            deleteDriverButton.Name = "deleteDriverButton";
            deleteDriverButton.Size = new Size(119, 44);
            deleteDriverButton.TabIndex = 12;
            deleteDriverButton.Text = "Удалить";
            deleteDriverButton.UseVisualStyleBackColor = true;
            deleteDriverButton.Click += deleteDriverButton_Click;
            // 
            // updateDriverButton
            // 
            updateDriverButton.Location = new Point(850, 120);
            updateDriverButton.Name = "updateDriverButton";
            updateDriverButton.Size = new Size(119, 44);
            updateDriverButton.TabIndex = 11;
            updateDriverButton.Text = "Изменить";
            updateDriverButton.UseVisualStyleBackColor = true;
            updateDriverButton.Click += updateDriverButton_Click;
            // 
            // addDriverButton
            // 
            addDriverButton.Location = new Point(850, 40);
            addDriverButton.Name = "addDriverButton";
            addDriverButton.Size = new Size(119, 44);
            addDriverButton.TabIndex = 10;
            addDriverButton.Text = "Добавить";
            addDriverButton.UseVisualStyleBackColor = true;
            addDriverButton.Click += addDriverButton_Click;
            // 
            // dgvDrivers
            // 
            dgvDrivers.AllowUserToAddRows = false;
            dgvDrivers.AllowUserToDeleteRows = false;
            dgvDrivers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrivers.Location = new Point(3, 3);
            dgvDrivers.MultiSelect = false;
            dgvDrivers.Name = "dgvDrivers";
            dgvDrivers.RowTemplate.Height = 25;
            dgvDrivers.Size = new Size(802, 495);
            dgvDrivers.TabIndex = 2;
            // 
            // tabCars
            // 
            tabCars.Controls.Add(deleteCarButton);
            tabCars.Controls.Add(updateCarButton);
            tabCars.Controls.Add(addCarButton);
            tabCars.Controls.Add(dgvCars);
            tabCars.Location = new Point(4, 24);
            tabCars.Name = "tabCars";
            tabCars.Size = new Size(1013, 501);
            tabCars.TabIndex = 4;
            tabCars.Text = "Автомобили";
            tabCars.UseVisualStyleBackColor = true;
            // 
            // deleteCarButton
            // 
            deleteCarButton.Location = new Point(850, 200);
            deleteCarButton.Name = "deleteCarButton";
            deleteCarButton.Size = new Size(119, 44);
            deleteCarButton.TabIndex = 15;
            deleteCarButton.Text = "Удалить";
            deleteCarButton.UseVisualStyleBackColor = true;
            deleteCarButton.Click += deleteCarButton_Click;
            // 
            // updateCarButton
            // 
            updateCarButton.Location = new Point(850, 120);
            updateCarButton.Name = "updateCarButton";
            updateCarButton.Size = new Size(119, 44);
            updateCarButton.TabIndex = 14;
            updateCarButton.Text = "Изменить";
            updateCarButton.UseVisualStyleBackColor = true;
            updateCarButton.Click += updateCarButton_Click;
            // 
            // addCarButton
            // 
            addCarButton.Location = new Point(850, 40);
            addCarButton.Name = "addCarButton";
            addCarButton.Size = new Size(119, 44);
            addCarButton.TabIndex = 13;
            addCarButton.Text = "Добавить";
            addCarButton.UseVisualStyleBackColor = true;
            addCarButton.Click += addCarButton_Click;
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(3, 3);
            dgvCars.MultiSelect = false;
            dgvCars.Name = "dgvCars";
            dgvCars.RowTemplate.Height = 25;
            dgvCars.Size = new Size(802, 495);
            dgvCars.TabIndex = 3;
            // 
            // tabDirectories
            // 
            tabDirectories.Controls.Add(directoryCB);
            tabDirectories.Controls.Add(deleteDIrectoryButton);
            tabDirectories.Controls.Add(updateDirectoryButton);
            tabDirectories.Controls.Add(addDirectoryButton);
            tabDirectories.Controls.Add(dgvDirectories);
            tabDirectories.Location = new Point(4, 24);
            tabDirectories.Name = "tabDirectories";
            tabDirectories.Size = new Size(1013, 501);
            tabDirectories.TabIndex = 5;
            tabDirectories.Text = "Администрирование";
            tabDirectories.UseVisualStyleBackColor = true;
            // 
            // directoryCB
            // 
            directoryCB.DropDownStyle = ComboBoxStyle.DropDownList;
            directoryCB.FormattingEnabled = true;
            directoryCB.Items.AddRange(new object[] { "Звания", "Категории", "Типы нарушения", "Сотрудники" });
            directoryCB.Location = new Point(832, 294);
            directoryCB.Name = "directoryCB";
            directoryCB.Size = new Size(155, 23);
            directoryCB.TabIndex = 19;
            directoryCB.SelectedIndexChanged += directoryCB_SelectedIndexChanged;
            // 
            // deleteDIrectoryButton
            // 
            deleteDIrectoryButton.Location = new Point(850, 200);
            deleteDIrectoryButton.Name = "deleteDIrectoryButton";
            deleteDIrectoryButton.Size = new Size(119, 44);
            deleteDIrectoryButton.TabIndex = 18;
            deleteDIrectoryButton.Text = "Удалить";
            deleteDIrectoryButton.UseVisualStyleBackColor = true;
            deleteDIrectoryButton.Click += deleteDIrectoryButton_Click;
            // 
            // updateDirectoryButton
            // 
            updateDirectoryButton.Location = new Point(850, 120);
            updateDirectoryButton.Name = "updateDirectoryButton";
            updateDirectoryButton.Size = new Size(119, 44);
            updateDirectoryButton.TabIndex = 17;
            updateDirectoryButton.Text = "Изменить";
            updateDirectoryButton.UseVisualStyleBackColor = true;
            updateDirectoryButton.Click += updateDirectoryButton_Click;
            // 
            // addDirectoryButton
            // 
            addDirectoryButton.Location = new Point(850, 40);
            addDirectoryButton.Name = "addDirectoryButton";
            addDirectoryButton.Size = new Size(119, 44);
            addDirectoryButton.TabIndex = 16;
            addDirectoryButton.Text = "Добавить";
            addDirectoryButton.UseVisualStyleBackColor = true;
            addDirectoryButton.Click += addDirectoryButton_Click;
            // 
            // dgvDirectories
            // 
            dgvDirectories.AllowUserToAddRows = false;
            dgvDirectories.AllowUserToDeleteRows = false;
            dgvDirectories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDirectories.Location = new Point(3, 3);
            dgvDirectories.MultiSelect = false;
            dgvDirectories.Name = "dgvDirectories";
            dgvDirectories.RowTemplate.Height = 25;
            dgvDirectories.Size = new Size(802, 495);
            dgvDirectories.TabIndex = 4;
            // 
            // tabRollBack
            // 
            tabRollBack.Controls.Add(rollBackButton);
            tabRollBack.Controls.Add(dgvRollBack);
            tabRollBack.Location = new Point(4, 24);
            tabRollBack.Name = "tabRollBack";
            tabRollBack.Size = new Size(1013, 501);
            tabRollBack.TabIndex = 6;
            tabRollBack.Text = "Откат изменений";
            tabRollBack.UseVisualStyleBackColor = true;
            // 
            // rollBackButton
            // 
            rollBackButton.Location = new Point(886, 40);
            rollBackButton.Name = "rollBackButton";
            rollBackButton.Size = new Size(119, 44);
            rollBackButton.TabIndex = 17;
            rollBackButton.Text = "Откатить";
            rollBackButton.UseVisualStyleBackColor = true;
            rollBackButton.Click += rollBackButton_Click;
            // 
            // dgvRollBack
            // 
            dgvRollBack.AllowUserToAddRows = false;
            dgvRollBack.AllowUserToDeleteRows = false;
            dgvRollBack.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRollBack.Location = new Point(3, 3);
            dgvRollBack.MultiSelect = false;
            dgvRollBack.Name = "dgvRollBack";
            dgvRollBack.RowTemplate.Height = 25;
            dgvRollBack.Size = new Size(877, 495);
            dgvRollBack.TabIndex = 5;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, отчетыToolStripMenuItem, справкаToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1021, 24);
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
            отчетыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { нарушенийВодителейЗаПериодToolStripMenuItem, эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem, сотрудникиToolStripMenuItem });
            отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            отчетыToolStripMenuItem.Size = new Size(60, 20);
            отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // нарушенийВодителейЗаПериодToolStripMenuItem
            // 
            нарушенийВодителейЗаПериодToolStripMenuItem.Name = "нарушенийВодителейЗаПериодToolStripMenuItem";
            нарушенийВодителейЗаПериодToolStripMenuItem.Size = new Size(347, 22);
            нарушенийВодителейЗаПериодToolStripMenuItem.Text = "Нарушений водителей за период";
            нарушенийВодителейЗаПериодToolStripMenuItem.Click += нарушенийВодителейЗаПериодToolStripMenuItem_Click;
            // 
            // эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem
            // 
            эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem.Name = "эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem";
            эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem.Size = new Size(347, 22);
            эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem.Text = "Эффективность сотрудников за последний месяц";
            эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem.Click += эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem_Click;
            // 
            // сотрудникиToolStripMenuItem
            // 
            сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            сотрудникиToolStripMenuItem.Size = new Size(347, 22);
            сотрудникиToolStripMenuItem.Text = "Сотрудники";
            сотрудникиToolStripMenuItem.Click += сотрудникиToolStripMenuItem_Click;
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
            ClientSize = new Size(1021, 612);
            Controls.Add(introductionLabel);
            Controls.Add(mainControl);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
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
            tabDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).EndInit();
            tabCars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            tabDirectories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDirectories).EndInit();
            tabRollBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRollBack).EndInit();
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
        private Button deleteViolationButton;
        private Button updateViolationButton;
        private Button addViolationButton;
        private Button deleteRegistrationButton;
        private Button updateRegistrationButton;
        private Button addRegistrationButton;
        private Button deleteLicenseButton;
        private Button updateLicenseButton;
        private Button addLicenseButton;
        private TabPage tabDrivers;
        private Button deleteDriverButton;
        private Button updateDriverButton;
        private Button addDriverButton;
        private DataGridView dgvDrivers;
        private TabPage tabCars;
        private Button deleteCarButton;
        private Button updateCarButton;
        private Button addCarButton;
        private DataGridView dgvCars;
        private TabPage tabDirectories;
        private Button deleteDIrectoryButton;
        private Button updateDirectoryButton;
        private Button addDirectoryButton;
        private DataGridView dgvDirectories;
        private ComboBox directoryCB;
        private ToolStripMenuItem нарушенийВодителейЗаПериодToolStripMenuItem;
        private ToolStripMenuItem эффективностьСотрудниковЗаПоследнийМесяцToolStripMenuItem;
        private ToolStripMenuItem сотрудникиToolStripMenuItem;
        private Button deleteLicenseExtButton;
        private TabPage tabRollBack;
        private Button rollBackButton;
        private DataGridView dgvRollBack;
    }
}