namespace Reusable_project_Form_
{
    partial class SubmitProposal
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
            this.ThemesCombobox = new System.Windows.Forms.ComboBox();
            this.ProposalTextbox = new System.Windows.Forms.RichTextBox();
            this.ThemesComboboxLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThemesCombobox
            // 
            this.ThemesCombobox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ThemesCombobox.FormattingEnabled = true;
            this.ThemesCombobox.Location = new System.Drawing.Point(21, 118);
            this.ThemesCombobox.Name = "ThemesCombobox";
            this.ThemesCombobox.Size = new System.Drawing.Size(281, 24);
            this.ThemesCombobox.TabIndex = 0;
            this.ThemesCombobox.SelectedIndexChanged += new System.EventHandler(this.ThemesCombobox_SelectedIndexChanged);
            // 
            // ProposalTextbox
            // 
            this.ProposalTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ProposalTextbox.Location = new System.Drawing.Point(21, 199);
            this.ProposalTextbox.Name = "ProposalTextbox";
            this.ProposalTextbox.Size = new System.Drawing.Size(381, 148);
            this.ProposalTextbox.TabIndex = 1;
            this.ProposalTextbox.Text = "";
            // 
            // ThemesComboboxLabel
            // 
            this.ThemesComboboxLabel.AutoSize = true;
            this.ThemesComboboxLabel.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThemesComboboxLabel.Location = new System.Drawing.Point(18, 87);
            this.ThemesComboboxLabel.Name = "ThemesComboboxLabel";
            this.ThemesComboboxLabel.Size = new System.Drawing.Size(238, 21);
            this.ThemesComboboxLabel.TabIndex = 2;
            this.ThemesComboboxLabel.Text = "Choose a theme for your project:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter your proposal here:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Proposal Submission";
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SubmitButton.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(22, 372);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SubmitButton.Size = new System.Drawing.Size(94, 29);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(143, 372);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CancelButton.Size = new System.Drawing.Size(94, 29);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SubmitProposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ThemesComboboxLabel);
            this.Controls.Add(this.ProposalTextbox);
            this.Controls.Add(this.ThemesCombobox);
            this.Name = "SubmitProposal";
            this.Text = "SubmitProposal";
            this.Load += new System.EventHandler(this.SubmitProposal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ThemesCombobox;
        private System.Windows.Forms.RichTextBox ProposalTextbox;
        private System.Windows.Forms.Label ThemesComboboxLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
    }
}