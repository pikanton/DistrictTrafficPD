namespace GAI.Forms
{
    partial class IURangForm
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
            titleLabel = new Label();
            titleText = new TextBox();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(111, 156);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 27;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(69, 41);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(90, 15);
            titleLabel.TabIndex = 26;
            titleLabel.Text = "Наименование";
            // 
            // titleText
            // 
            titleText.Location = new Point(69, 59);
            titleText.Name = "titleText";
            titleText.Size = new Size(273, 23);
            titleText.TabIndex = 25;
            // 
            // IURangForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 227);
            Controls.Add(submitButton);
            Controls.Add(titleLabel);
            Controls.Add(titleText);
            Name = "IURangForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IURangForm";
            Load += IURangForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Label titleLabel;
        private TextBox titleText;
    }
}