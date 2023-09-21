namespace GAI.Forms
{
    partial class IUCategoryForm
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
            descriptionLabel = new Label();
            descriptionText = new TextBox();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(115, 340);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 30;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(66, 46);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(90, 15);
            titleLabel.TabIndex = 29;
            titleLabel.Text = "Наименование";
            // 
            // titleText
            // 
            titleText.Location = new Point(66, 64);
            titleText.Name = "titleText";
            titleText.Size = new Size(273, 23);
            titleText.TabIndex = 28;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(66, 132);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(85, 15);
            descriptionLabel.TabIndex = 32;
            descriptionLabel.Text = "Расшифровка";
            // 
            // descriptionText
            // 
            descriptionText.Location = new Point(66, 150);
            descriptionText.Multiline = true;
            descriptionText.Name = "descriptionText";
            descriptionText.Size = new Size(273, 166);
            descriptionText.TabIndex = 31;
            // 
            // IUCategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 381);
            Controls.Add(descriptionLabel);
            Controls.Add(descriptionText);
            Controls.Add(submitButton);
            Controls.Add(titleLabel);
            Controls.Add(titleText);
            Name = "IUCategoryForm";
            Text = "IUCategoryForm";
            Load += IUCategoryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private Label titleLabel;
        private TextBox titleText;
        private Label descriptionLabel;
        private TextBox descriptionText;
    }
}