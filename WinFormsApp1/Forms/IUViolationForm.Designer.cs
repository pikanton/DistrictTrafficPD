namespace GAI.Forms
{
    partial class IUViolationForm
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
            protocolText = new TextBox();
            protocolLabel = new Label();
            fineLabel = new Label();
            fineText = new TextBox();
            termOfDeprivationLabel = new Label();
            termOfDeprivationText = new TextBox();
            driverCB = new ComboBox();
            driverLabel = new Label();
            employeeLabel = new Label();
            employeeCB = new ComboBox();
            typeLabel = new Label();
            typeCB = new ComboBox();
            dateTimePicker = new DateTimePicker();
            dateLabel = new Label();
            submitButton = new Button();
            SuspendLayout();
            // 
            // protocolText
            // 
            protocolText.Location = new Point(65, 66);
            protocolText.Name = "protocolText";
            protocolText.Size = new Size(273, 23);
            protocolText.TabIndex = 0;
            // 
            // protocolLabel
            // 
            protocolLabel.AutoSize = true;
            protocolLabel.Location = new Point(65, 48);
            protocolLabel.Name = "protocolLabel";
            protocolLabel.Size = new Size(84, 15);
            protocolLabel.TabIndex = 1;
            protocolLabel.Text = "№ Протокола";
            // 
            // fineLabel
            // 
            fineLabel.AutoSize = true;
            fineLabel.Location = new Point(65, 107);
            fineLabel.Name = "fineLabel";
            fineLabel.Size = new Size(94, 15);
            fineLabel.TabIndex = 3;
            fineLabel.Text = "Размер штрафа";
            // 
            // fineText
            // 
            fineText.Location = new Point(65, 125);
            fineText.Name = "fineText";
            fineText.Size = new Size(273, 23);
            fineText.TabIndex = 2;
            // 
            // termOfDeprivationLabel
            // 
            termOfDeprivationLabel.AutoSize = true;
            termOfDeprivationLabel.Location = new Point(65, 169);
            termOfDeprivationLabel.Name = "termOfDeprivationLabel";
            termOfDeprivationLabel.Size = new Size(118, 15);
            termOfDeprivationLabel.TabIndex = 5;
            termOfDeprivationLabel.Text = "Срок лишения прав";
            // 
            // termOfDeprivationText
            // 
            termOfDeprivationText.Location = new Point(65, 187);
            termOfDeprivationText.Name = "termOfDeprivationText";
            termOfDeprivationText.Size = new Size(273, 23);
            termOfDeprivationText.TabIndex = 4;
            // 
            // driverCB
            // 
            driverCB.DropDownStyle = ComboBoxStyle.DropDownList;
            driverCB.FormattingEnabled = true;
            driverCB.Location = new Point(65, 246);
            driverCB.Name = "driverCB";
            driverCB.Size = new Size(273, 23);
            driverCB.TabIndex = 6;
            // 
            // driverLabel
            // 
            driverLabel.AutoSize = true;
            driverLabel.Location = new Point(65, 228);
            driverLabel.Name = "driverLabel";
            driverLabel.Size = new Size(58, 15);
            driverLabel.TabIndex = 7;
            driverLabel.Text = "Водитель";
            // 
            // employeeLabel
            // 
            employeeLabel.AutoSize = true;
            employeeLabel.Location = new Point(65, 286);
            employeeLabel.Name = "employeeLabel";
            employeeLabel.Size = new Size(66, 15);
            employeeLabel.TabIndex = 9;
            employeeLabel.Text = "Сотрудник";
            // 
            // employeeCB
            // 
            employeeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            employeeCB.FormattingEnabled = true;
            employeeCB.Location = new Point(65, 304);
            employeeCB.Name = "employeeCB";
            employeeCB.Size = new Size(273, 23);
            employeeCB.TabIndex = 8;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(65, 342);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(93, 15);
            typeLabel.TabIndex = 11;
            typeLabel.Text = "Тип нарушения";
            // 
            // typeCB
            // 
            typeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            typeCB.FormattingEnabled = true;
            typeCB.Location = new Point(65, 360);
            typeCB.Name = "typeCB";
            typeCB.Size = new Size(273, 23);
            typeCB.TabIndex = 10;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(65, 416);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(273, 23);
            dateTimePicker.TabIndex = 12;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(65, 398);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(32, 15);
            dateLabel.TabIndex = 13;
            dateLabel.Text = "Дата";
            // 
            // submitButton
            // 
            submitButton.Location = new Point(105, 484);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 14;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // IUViolationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 525);
            Controls.Add(submitButton);
            Controls.Add(dateLabel);
            Controls.Add(dateTimePicker);
            Controls.Add(typeLabel);
            Controls.Add(typeCB);
            Controls.Add(employeeLabel);
            Controls.Add(employeeCB);
            Controls.Add(driverLabel);
            Controls.Add(driverCB);
            Controls.Add(termOfDeprivationLabel);
            Controls.Add(termOfDeprivationText);
            Controls.Add(fineLabel);
            Controls.Add(fineText);
            Controls.Add(protocolLabel);
            Controls.Add(protocolText);
            Name = "IUViolationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IUViolationForm";
            Load += IUViolationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox protocolText;
        private Label protocolLabel;
        private Label fineLabel;
        private TextBox fineText;
        private Label termOfDeprivationLabel;
        private TextBox termOfDeprivationText;
        private ComboBox driverCB;
        private Label driverLabel;
        private Label employeeLabel;
        private ComboBox employeeCB;
        private Label typeLabel;
        private ComboBox typeCB;
        private DateTimePicker dateTimePicker;
        private Label dateLabel;
        private Button submitButton;

    }
}