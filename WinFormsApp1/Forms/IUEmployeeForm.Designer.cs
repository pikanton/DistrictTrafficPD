namespace GAI.Forms
{
    partial class IUEmployeeForm
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
            roleLabel = new Label();
            roleCB = new ComboBox();
            rangLabel = new Label();
            rangCB = new ComboBox();
            patronymicLabel = new Label();
            patronymicText = new TextBox();
            nameLabel = new Label();
            nameText = new TextBox();
            surnameLabel = new Label();
            surnameText = new TextBox();
            phoneNumberLabel = new Label();
            phoneNumberText = new TextBox();
            userNameLabel = new Label();
            userNameText = new TextBox();
            passwordLabel = new Label();
            passwordText = new TextBox();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(105, 524);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 16;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Location = new Point(65, 453);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(34, 15);
            roleLabel.TabIndex = 15;
            roleLabel.Text = "Роль";
            // 
            // roleCB
            // 
            roleCB.DropDownStyle = ComboBoxStyle.DropDownList;
            roleCB.FormattingEnabled = true;
            roleCB.Location = new Point(65, 471);
            roleCB.Name = "roleCB";
            roleCB.Size = new Size(273, 23);
            roleCB.TabIndex = 14;
            // 
            // rangLabel
            // 
            rangLabel.AutoSize = true;
            rangLabel.Location = new Point(65, 391);
            rangLabel.Name = "rangLabel";
            rangLabel.Size = new Size(46, 15);
            rangLabel.TabIndex = 13;
            rangLabel.Text = "Звание";
            // 
            // rangCB
            // 
            rangCB.DropDownStyle = ComboBoxStyle.DropDownList;
            rangCB.FormattingEnabled = true;
            rangCB.Location = new Point(65, 409);
            rangCB.Name = "rangCB";
            rangCB.Size = new Size(273, 23);
            rangCB.TabIndex = 12;
            // 
            // patronymicLabel
            // 
            patronymicLabel.AutoSize = true;
            patronymicLabel.Location = new Point(65, 144);
            patronymicLabel.Name = "patronymicLabel";
            patronymicLabel.Size = new Size(58, 15);
            patronymicLabel.TabIndex = 5;
            patronymicLabel.Text = "Отчество";
            // 
            // patronymicText
            // 
            patronymicText.Location = new Point(65, 162);
            patronymicText.Name = "patronymicText";
            patronymicText.Size = new Size(273, 23);
            patronymicText.TabIndex = 4;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(65, 82);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(31, 15);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Имя";
            // 
            // nameText
            // 
            nameText.Location = new Point(65, 100);
            nameText.Name = "nameText";
            nameText.Size = new Size(273, 23);
            nameText.TabIndex = 2;
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(65, 23);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(58, 15);
            surnameLabel.TabIndex = 1;
            surnameLabel.Text = "Фамилия";
            // 
            // surnameText
            // 
            surnameText.Location = new Point(65, 41);
            surnameText.Name = "surnameText";
            surnameText.Size = new Size(273, 23);
            surnameText.TabIndex = 0;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(65, 208);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(55, 15);
            phoneNumberLabel.TabIndex = 7;
            phoneNumberLabel.Text = "Телефон";
            // 
            // phoneNumberText
            // 
            phoneNumberText.Location = new Point(65, 226);
            phoneNumberText.Name = "phoneNumberText";
            phoneNumberText.Size = new Size(273, 23);
            phoneNumberText.TabIndex = 6;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(65, 269);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(41, 15);
            userNameLabel.TabIndex = 9;
            userNameLabel.Text = "Логин";
            // 
            // userNameText
            // 
            userNameText.Location = new Point(65, 287);
            userNameText.Name = "userNameText";
            userNameText.Size = new Size(273, 23);
            userNameText.TabIndex = 8;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(65, 327);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(49, 15);
            passwordLabel.TabIndex = 11;
            passwordLabel.Text = "Пароль";
            // 
            // passwordText
            // 
            passwordText.Location = new Point(65, 345);
            passwordText.Name = "passwordText";
            passwordText.Size = new Size(273, 23);
            passwordText.TabIndex = 10;
            // 
            // IUEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 565);
            Controls.Add(passwordLabel);
            Controls.Add(passwordText);
            Controls.Add(userNameLabel);
            Controls.Add(userNameText);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberText);
            Controls.Add(submitButton);
            Controls.Add(roleLabel);
            Controls.Add(roleCB);
            Controls.Add(rangLabel);
            Controls.Add(rangCB);
            Controls.Add(patronymicLabel);
            Controls.Add(patronymicText);
            Controls.Add(nameLabel);
            Controls.Add(nameText);
            Controls.Add(surnameLabel);
            Controls.Add(surnameText);
            Name = "IUEmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IUEmployeeForm";
            Load += IUEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Label roleLabel;
        private ComboBox roleCB;
        private Label rangLabel;
        private ComboBox rangCB;
        private Label patronymicLabel;
        private TextBox patronymicText;
        private Label nameLabel;
        private TextBox nameText;
        private Label surnameLabel;
        private TextBox surnameText;
        private Label phoneNumberLabel;
        private TextBox phoneNumberText;
        private Label userNameLabel;
        private TextBox userNameText;
        private Label passwordLabel;
        private TextBox passwordText;
    }
}