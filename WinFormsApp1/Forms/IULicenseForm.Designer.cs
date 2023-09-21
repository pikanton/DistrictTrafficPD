namespace GAI.Forms
{
    partial class IULicenseForm
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
            submitButton = new Button();
            dateOfIssueLabel = new Label();
            dateOfIssuePicker = new DateTimePicker();
            driverLabel = new Label();
            driverCB = new ComboBox();
            numberLabel = new Label();
            numberText = new TextBox();
            validityLabel = new Label();
            validityPicker = new DateTimePicker();
            categoriesCLB = new CheckedListBox();
            categoriesLabel = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(102, 482);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 10;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // dateOfIssueLabel
            // 
            dateOfIssueLabel.AutoSize = true;
            dateOfIssueLabel.Location = new Point(62, 102);
            dateOfIssueLabel.Name = "dateOfIssueLabel";
            dateOfIssueLabel.Size = new Size(76, 15);
            dateOfIssueLabel.TabIndex = 3;
            dateOfIssueLabel.Text = "Дата выдачи";
            // 
            // dateOfIssuePicker
            // 
            dateOfIssuePicker.Location = new Point(62, 120);
            dateOfIssuePicker.Name = "dateOfIssuePicker";
            dateOfIssuePicker.Size = new Size(273, 23);
            dateOfIssuePicker.TabIndex = 2;
            // 
            // driverLabel
            // 
            driverLabel.AutoSize = true;
            driverLabel.Location = new Point(62, 219);
            driverLabel.Name = "driverLabel";
            driverLabel.Size = new Size(58, 15);
            driverLabel.TabIndex = 7;
            driverLabel.Text = "Водитель";
            // 
            // driverCB
            // 
            driverCB.DropDownStyle = ComboBoxStyle.DropDownList;
            driverCB.FormattingEnabled = true;
            driverCB.Location = new Point(62, 237);
            driverCB.Name = "driverCB";
            driverCB.Size = new Size(273, 23);
            driverCB.TabIndex = 6;
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Location = new Point(62, 46);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new Size(45, 15);
            numberLabel.TabIndex = 1;
            numberLabel.Text = "Номер";
            // 
            // numberText
            // 
            numberText.Location = new Point(62, 64);
            numberText.Name = "numberText";
            numberText.Size = new Size(273, 23);
            numberText.TabIndex = 0;
            // 
            // validityLabel
            // 
            validityLabel.AutoSize = true;
            validityLabel.Location = new Point(62, 162);
            validityLabel.Name = "validityLabel";
            validityLabel.Size = new Size(87, 15);
            validityLabel.TabIndex = 5;
            validityLabel.Text = "Срок действия";
            // 
            // validityPicker
            // 
            validityPicker.Location = new Point(62, 180);
            validityPicker.Name = "validityPicker";
            validityPicker.Size = new Size(273, 23);
            validityPicker.TabIndex = 4;
            // 
            // categoriesCLB
            // 
            categoriesCLB.CheckOnClick = true;
            categoriesCLB.FormattingEnabled = true;
            categoriesCLB.Location = new Point(62, 293);
            categoriesCLB.MultiColumn = true;
            categoriesCLB.Name = "categoriesCLB";
            categoriesCLB.Size = new Size(273, 166);
            categoriesCLB.TabIndex = 8;
            // 
            // categoriesLabel
            // 
            categoriesLabel.AutoSize = true;
            categoriesLabel.Location = new Point(62, 275);
            categoriesLabel.Name = "categoriesLabel";
            categoriesLabel.Size = new Size(64, 15);
            categoriesLabel.TabIndex = 9;
            categoriesLabel.Text = "Категории";
            // 
            // IULicenseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 525);
            Controls.Add(categoriesLabel);
            Controls.Add(categoriesCLB);
            Controls.Add(validityLabel);
            Controls.Add(validityPicker);
            Controls.Add(submitButton);
            Controls.Add(dateOfIssueLabel);
            Controls.Add(dateOfIssuePicker);
            Controls.Add(driverLabel);
            Controls.Add(driverCB);
            Controls.Add(numberLabel);
            Controls.Add(numberText);
            Name = "IULicenseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IULicenseForm";
            Load += IULicenseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Label dateOfIssueLabel;
        private DateTimePicker dateOfIssuePicker;
        private Label driverLabel;
        private ComboBox driverCB;
        private Label numberLabel;
        private TextBox numberText;
        private Label validityLabel;
        private DateTimePicker validityPicker;
        private CheckedListBox categoriesCLB;
        private Label categoriesLabel;
    }
}