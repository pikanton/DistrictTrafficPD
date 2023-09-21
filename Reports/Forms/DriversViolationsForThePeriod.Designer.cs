namespace Reports.Forms
{
    partial class DriversViolationsForThePeriod
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
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.beginLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.subminButton = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Location = new System.Drawing.Point(54, 26);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.beginDateTimePicker.TabIndex = 0;
            // 
            // beginLabel
            // 
            this.beginLabel.AutoSize = true;
            this.beginLabel.Location = new System.Drawing.Point(54, 10);
            this.beginLabel.Name = "beginLabel";
            this.beginLabel.Size = new System.Drawing.Size(89, 13);
            this.beginLabel.TabIndex = 1;
            this.beginLabel.Text = "Начало периода";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(54, 85);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(83, 13);
            this.endLabel.TabIndex = 3;
            this.endLabel.Text = "Конец периода";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(54, 101);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 2;
            // 
            // subminButton
            // 
            this.subminButton.Location = new System.Drawing.Point(111, 179);
            this.subminButton.Name = "subminButton";
            this.subminButton.Size = new System.Drawing.Size(85, 32);
            this.subminButton.TabIndex = 4;
            this.subminButton.Text = "Показать";
            this.subminButton.UseVisualStyleBackColor = true;
            this.subminButton.Click += new System.EventHandler(this.subminButton_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(57, 141);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(185, 17);
            this.checkBox.TabIndex = 5;
            this.checkBox.Text = "Показать записи за всё время";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // DriversViolationsForThePeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 223);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.subminButton);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.beginLabel);
            this.Controls.Add(this.beginDateTimePicker);
            this.Name = "DriversViolationsForThePeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нарушения водителей";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.Label beginLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Button subminButton;
        private System.Windows.Forms.CheckBox checkBox;
    }
}