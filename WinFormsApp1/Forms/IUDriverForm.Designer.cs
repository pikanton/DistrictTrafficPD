namespace GAI.Forms
{
    partial class IUDriverForm
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
            patronymicLabel = new Label();
            patronymicText = new TextBox();
            nameLabel = new Label();
            nameText = new TextBox();
            surnameLabel = new Label();
            surnameText = new TextBox();
            passportLabel = new Label();
            passportText = new TextBox();
            phoneNumberLabel = new Label();
            phoneNumberText = new TextBox();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(109, 466);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 10;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // patronymicLabel
            // 
            patronymicLabel.AutoSize = true;
            patronymicLabel.Location = new Point(63, 170);
            patronymicLabel.Name = "patronymicLabel";
            patronymicLabel.Size = new Size(58, 15);
            patronymicLabel.TabIndex = 5;
            patronymicLabel.Text = "Отчество";
            // 
            // patronymicText
            // 
            patronymicText.Location = new Point(63, 188);
            patronymicText.Name = "patronymicText";
            patronymicText.Size = new Size(273, 23);
            patronymicText.TabIndex = 4;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(63, 108);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(31, 15);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Имя";
            // 
            // nameText
            // 
            nameText.Location = new Point(63, 126);
            nameText.Name = "nameText";
            nameText.Size = new Size(273, 23);
            nameText.TabIndex = 2;
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(63, 49);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(58, 15);
            surnameLabel.TabIndex = 1;
            surnameLabel.Text = "Фамилия";
            // 
            // surnameText
            // 
            surnameText.Location = new Point(63, 67);
            surnameText.Name = "surnameText";
            surnameText.Size = new Size(273, 23);
            surnameText.TabIndex = 0;
            // 
            // passportLabel
            // 
            passportLabel.AutoSize = true;
            passportLabel.Location = new Point(63, 229);
            passportLabel.Name = "passportLabel";
            passportLabel.Size = new Size(54, 15);
            passportLabel.TabIndex = 7;
            passportLabel.Text = "Паспорт";
            // 
            // passportText
            // 
            passportText.Location = new Point(63, 247);
            passportText.Name = "passportText";
            passportText.Size = new Size(273, 23);
            passportText.TabIndex = 6;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(63, 290);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(101, 15);
            phoneNumberLabel.TabIndex = 9;
            phoneNumberLabel.Text = "Номер телефона";
            // 
            // phoneNumberText
            // 
            phoneNumberText.Location = new Point(63, 308);
            phoneNumberText.Name = "phoneNumberText";
            phoneNumberText.Size = new Size(273, 23);
            phoneNumberText.TabIndex = 8;
            // 
            // IUDriverForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 525);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberText);
            Controls.Add(passportLabel);
            Controls.Add(passportText);
            Controls.Add(submitButton);
            Controls.Add(patronymicLabel);
            Controls.Add(patronymicText);
            Controls.Add(nameLabel);
            Controls.Add(nameText);
            Controls.Add(surnameLabel);
            Controls.Add(surnameText);
            Name = "IUDriverForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IUDriverForm";
            Load += IUDriverForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Label patronymicLabel;
        private TextBox patronymicText;
        private Label nameLabel;
        private TextBox nameText;
        private Label surnameLabel;
        private TextBox surnameText;
        private Label passportLabel;
        private TextBox passportText;
        private Label phoneNumberLabel;
        private TextBox phoneNumberText;
    }
}