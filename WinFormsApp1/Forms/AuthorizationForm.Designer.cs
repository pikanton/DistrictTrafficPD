namespace GAI.Forms
{
    partial class AuthorizationForm
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
            loginBox = new TextBox();
            passwordBox = new TextBox();
            loginLabel = new Label();
            passwordLabel = new Label();
            submitButton = new Button();
            SuspendLayout();
            // 
            // loginBox
            // 
            loginBox.Location = new Point(129, 128);
            loginBox.Name = "loginBox";
            loginBox.Size = new Size(187, 23);
            loginBox.TabIndex = 0;
            loginBox.Text = "avsumonchik";
            loginBox.KeyPress += loginBox_KeyPress;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(129, 199);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '*';
            passwordBox.Size = new Size(187, 23);
            passwordBox.TabIndex = 1;
            passwordBox.KeyPress += passwordBox_KeyPress;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(129, 110);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(41, 15);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "Логин";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(129, 181);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(49, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Пароль";
            // 
            // submitButton
            // 
            submitButton.Location = new Point(181, 250);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 4;
            submitButton.Text = "Войти";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 381);
            Controls.Add(submitButton);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Controls.Add(passwordBox);
            Controls.Add(loginBox);
            Name = "AuthorizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginBox;
        private TextBox passwordBox;
        private Label loginLabel;
        private Label passwordLabel;
        private Button submitButton;
    }
}