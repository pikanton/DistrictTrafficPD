namespace GAI.Forms
{
    partial class IUCarForm
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
            colorLabel = new Label();
            colorText = new TextBox();
            submitButton = new Button();
            modelLabel = new Label();
            modelText = new TextBox();
            markLabel = new Label();
            markText = new TextBox();
            VINLabel = new Label();
            VINText = new TextBox();
            SuspendLayout();
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.Location = new Point(63, 260);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(33, 15);
            colorLabel.TabIndex = 7;
            colorLabel.Text = "Цвет";
            // 
            // colorText
            // 
            colorText.Location = new Point(63, 278);
            colorText.Name = "colorText";
            colorText.Size = new Size(273, 23);
            colorText.TabIndex = 6;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(115, 456);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 29);
            submitButton.TabIndex = 8;
            submitButton.Text = "Сохранить";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Location = new Point(63, 201);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new Size(50, 15);
            modelLabel.TabIndex = 5;
            modelLabel.Text = "Модель";
            // 
            // modelText
            // 
            modelText.Location = new Point(63, 219);
            modelText.Name = "modelText";
            modelText.Size = new Size(273, 23);
            modelText.TabIndex = 4;
            // 
            // markLabel
            // 
            markLabel.AutoSize = true;
            markLabel.Location = new Point(63, 139);
            markLabel.Name = "markLabel";
            markLabel.Size = new Size(43, 15);
            markLabel.TabIndex = 3;
            markLabel.Text = "Марка";
            // 
            // markText
            // 
            markText.Location = new Point(63, 157);
            markText.Name = "markText";
            markText.Size = new Size(273, 23);
            markText.TabIndex = 2;
            // 
            // VINLabel
            // 
            VINLabel.AutoSize = true;
            VINLabel.Location = new Point(63, 80);
            VINLabel.Name = "VINLabel";
            VINLabel.Size = new Size(26, 15);
            VINLabel.TabIndex = 1;
            VINLabel.Text = "VIN";
            // 
            // VINText
            // 
            VINText.Location = new Point(63, 98);
            VINText.Name = "VINText";
            VINText.Size = new Size(273, 23);
            VINText.TabIndex = 0;
            // 
            // IUCarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 525);
            Controls.Add(colorLabel);
            Controls.Add(colorText);
            Controls.Add(submitButton);
            Controls.Add(modelLabel);
            Controls.Add(modelText);
            Controls.Add(markLabel);
            Controls.Add(markText);
            Controls.Add(VINLabel);
            Controls.Add(VINText);
            Name = "IUCarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IUCarForm";
            Load += IUCarForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label colorLabel;
        private TextBox colorText;
        private Button submitButton;
        private Label modelLabel;
        private TextBox modelText;
        private Label markLabel;
        private TextBox markText;
        private Label VINLabel;
        private TextBox VINText;
    }
}