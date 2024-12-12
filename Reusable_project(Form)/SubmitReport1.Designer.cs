namespace Reusable_project_Form_
{
    partial class SubmitReport1
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
            this.IDTextbox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ReportTextboxLabel = new System.Windows.Forms.Label();
            this.IDTextboxLabel = new System.Windows.Forms.Label();
            this.ReportTextbox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IDTextbox
            // 
            this.IDTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.IDTextbox.Location = new System.Drawing.Point(51, 114);
            this.IDTextbox.Name = "IDTextbox";
            this.IDTextbox.Size = new System.Drawing.Size(94, 22);
            this.IDTextbox.TabIndex = 21;
            this.IDTextbox.TextChanged += new System.EventHandler(this.IDTextbox_TextChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(173, 416);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CancelButton.Size = new System.Drawing.Size(94, 29);
            this.CancelButton.TabIndex = 20;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SubmitButton.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(52, 416);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SubmitButton.Size = new System.Drawing.Size(94, 29);
            this.SubmitButton.TabIndex = 19;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 37);
            this.label2.TabIndex = 18;
            this.label2.Text = "Report Submission";
            // 
            // ReportTextboxLabel
            // 
            this.ReportTextboxLabel.AutoSize = true;
            this.ReportTextboxLabel.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportTextboxLabel.Location = new System.Drawing.Point(48, 214);
            this.ReportTextboxLabel.Name = "ReportTextboxLabel";
            this.ReportTextboxLabel.Size = new System.Drawing.Size(218, 21);
            this.ReportTextboxLabel.TabIndex = 17;
            this.ReportTextboxLabel.Text = "Please enter your report here:";
            // 
            // IDTextboxLabel
            // 
            this.IDTextboxLabel.AutoSize = true;
            this.IDTextboxLabel.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTextboxLabel.Location = new System.Drawing.Point(47, 80);
            this.IDTextboxLabel.Name = "IDTextboxLabel";
            this.IDTextboxLabel.Size = new System.Drawing.Size(217, 21);
            this.IDTextboxLabel.TabIndex = 16;
            this.IDTextboxLabel.Text = "Please enter your project\'s ID:";
            // 
            // ReportTextbox
            // 
            this.ReportTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ReportTextbox.Location = new System.Drawing.Point(51, 252);
            this.ReportTextbox.Name = "ReportTextbox";
            this.ReportTextbox.Size = new System.Drawing.Size(381, 148);
            this.ReportTextbox.TabIndex = 15;
            this.ReportTextbox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "Please enter your report\'s title:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TitleTextbox.Location = new System.Drawing.Point(52, 180);
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(280, 22);
            this.TitleTextbox.TabIndex = 22;
            // 
            // SubmitReport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TitleTextbox);
            this.Controls.Add(this.IDTextbox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReportTextboxLabel);
            this.Controls.Add(this.IDTextboxLabel);
            this.Controls.Add(this.ReportTextbox);
            this.Name = "SubmitReport1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SubmitReport1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDTextbox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ReportTextboxLabel;
        private System.Windows.Forms.Label IDTextboxLabel;
        private System.Windows.Forms.RichTextBox ReportTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TitleTextbox;
    }
}