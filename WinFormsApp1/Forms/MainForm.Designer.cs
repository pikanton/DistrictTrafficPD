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
            SuspendLayout();
            // 
            // introductionLabel
            // 
            introductionLabel.AutoSize = true;
            introductionLabel.Location = new Point(15, 7);
            introductionLabel.Name = "introductionLabel";
            introductionLabel.Size = new Size(38, 15);
            introductionLabel.TabIndex = 0;
            introductionLabel.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 588);
            Controls.Add(introductionLabel);
            Name = "MainForm";
            Text = "ГАИ";
            FormClosed += MainForm_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label introductionLabel;
    }
}