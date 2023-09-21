namespace GAI.Forms
{
    partial class IURegistrationForm
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
            dateLabel = new Label();
            dateTimePicker = new DateTimePicker();
            carLabel = new Label();
            carCB = new ComboBox();
            employeeLabel = new Label();
            employeeCB = new ComboBox();
            driverLabel = new Label();
            driverCB = new ComboBox();
            registrationPlateLabel = new Label();
            registrationPlateText = new TextBox();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(106, 393);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 29;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(66, 307);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(32, 15);
            dateLabel.TabIndex = 28;
            dateLabel.Text = "Дата";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(66, 325);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(273, 23);
            dateTimePicker.TabIndex = 27;
            // 
            // carLabel
            // 
            carLabel.AutoSize = true;
            carLabel.Location = new Point(66, 251);
            carLabel.Name = "carLabel";
            carLabel.Size = new Size(76, 15);
            carLabel.TabIndex = 26;
            carLabel.Text = "Автомобиль";
            // 
            // carCB
            // 
            carCB.DropDownStyle = ComboBoxStyle.DropDownList;
            carCB.FormattingEnabled = true;
            carCB.Location = new Point(66, 269);
            carCB.Name = "carCB";
            carCB.Size = new Size(273, 23);
            carCB.TabIndex = 25;
            // 
            // employeeLabel
            // 
            employeeLabel.AutoSize = true;
            employeeLabel.Location = new Point(66, 195);
            employeeLabel.Name = "employeeLabel";
            employeeLabel.Size = new Size(66, 15);
            employeeLabel.TabIndex = 24;
            employeeLabel.Text = "Сотрудник";
            // 
            // employeeCB
            // 
            employeeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            employeeCB.FormattingEnabled = true;
            employeeCB.Location = new Point(66, 213);
            employeeCB.Name = "employeeCB";
            employeeCB.Size = new Size(273, 23);
            employeeCB.TabIndex = 23;
            // 
            // driverLabel
            // 
            driverLabel.AutoSize = true;
            driverLabel.Location = new Point(66, 137);
            driverLabel.Name = "driverLabel";
            driverLabel.Size = new Size(58, 15);
            driverLabel.TabIndex = 22;
            driverLabel.Text = "Водитель";
            // 
            // driverCB
            // 
            driverCB.DropDownStyle = ComboBoxStyle.DropDownList;
            driverCB.FormattingEnabled = true;
            driverCB.Location = new Point(66, 155);
            driverCB.Name = "driverCB";
            driverCB.Size = new Size(273, 23);
            driverCB.TabIndex = 21;
            // 
            // registrationPlateLabel
            // 
            registrationPlateLabel.AutoSize = true;
            registrationPlateLabel.Location = new Point(66, 78);
            registrationPlateLabel.Name = "registrationPlateLabel";
            registrationPlateLabel.Size = new Size(134, 15);
            registrationPlateLabel.TabIndex = 20;
            registrationPlateLabel.Text = "Регистрационный знак";
            // 
            // registrationPlateText
            // 
            registrationPlateText.Location = new Point(66, 96);
            registrationPlateText.Name = "registrationPlateText";
            registrationPlateText.Size = new Size(273, 23);
            registrationPlateText.TabIndex = 19;
            // 
            // IURegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 525);
            Controls.Add(submitButton);
            Controls.Add(dateLabel);
            Controls.Add(dateTimePicker);
            Controls.Add(carLabel);
            Controls.Add(carCB);
            Controls.Add(employeeLabel);
            Controls.Add(employeeCB);
            Controls.Add(driverLabel);
            Controls.Add(driverCB);
            Controls.Add(registrationPlateLabel);
            Controls.Add(registrationPlateText);
            Name = "IURegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IURegistrationForm";
            Load += IURegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Label dateLabel;
        private DateTimePicker dateTimePicker;
        private Label carLabel;
        private ComboBox carCB;
        private Label employeeLabel;
        private ComboBox employeeCB;
        private Label driverLabel;
        private ComboBox driverCB;
        private Label registrationPlateLabel;
        private TextBox registrationPlateText;
    }
}