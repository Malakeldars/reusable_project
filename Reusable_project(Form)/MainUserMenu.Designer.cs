namespace Reusable_project_Form_
{
    partial class MainUserMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.SubmitPropButton = new System.Windows.Forms.Button();
            this.SubmitRepButton = new System.Windows.Forms.Button();
            this.DeletePropButton = new System.Windows.Forms.Button();
            this.UpdatePropButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome 3amo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SubmitPropButton
            // 
            this.SubmitPropButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SubmitPropButton.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.SubmitPropButton.Location = new System.Drawing.Point(39, 111);
            this.SubmitPropButton.Name = "SubmitPropButton";
            this.SubmitPropButton.Size = new System.Drawing.Size(203, 33);
            this.SubmitPropButton.TabIndex = 1;
            this.SubmitPropButton.Text = "Submit a proposal";
            this.SubmitPropButton.UseVisualStyleBackColor = false;
            this.SubmitPropButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubmitRepButton
            // 
            this.SubmitRepButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SubmitRepButton.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.SubmitRepButton.Location = new System.Drawing.Point(39, 163);
            this.SubmitRepButton.Name = "SubmitRepButton";
            this.SubmitRepButton.Size = new System.Drawing.Size(203, 33);
            this.SubmitRepButton.TabIndex = 2;
            this.SubmitRepButton.Text = "Submit a report";
            this.SubmitRepButton.UseVisualStyleBackColor = false;
            this.SubmitRepButton.Click += new System.EventHandler(this.SubmitRepButton_Click);
            // 
            // DeletePropButton
            // 
            this.DeletePropButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeletePropButton.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.DeletePropButton.Location = new System.Drawing.Point(39, 218);
            this.DeletePropButton.Name = "DeletePropButton";
            this.DeletePropButton.Size = new System.Drawing.Size(203, 33);
            this.DeletePropButton.TabIndex = 3;
            this.DeletePropButton.Text = "Delete a proposal";
            this.DeletePropButton.UseVisualStyleBackColor = false;
            this.DeletePropButton.Click += new System.EventHandler(this.DeletePropButton_Click);
            // 
            // UpdatePropButton
            // 
            this.UpdatePropButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UpdatePropButton.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.UpdatePropButton.Location = new System.Drawing.Point(39, 270);
            this.UpdatePropButton.Name = "UpdatePropButton";
            this.UpdatePropButton.Size = new System.Drawing.Size(203, 33);
            this.UpdatePropButton.TabIndex = 4;
            this.UpdatePropButton.Text = "Update a proposal";
            this.UpdatePropButton.UseVisualStyleBackColor = false;
            this.UpdatePropButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainUserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UpdatePropButton);
            this.Controls.Add(this.DeletePropButton);
            this.Controls.Add(this.SubmitRepButton);
            this.Controls.Add(this.SubmitPropButton);
            this.Controls.Add(this.label1);
            this.Name = "MainUserMenu";
            this.Text = "MainUserMenu";
            this.Load += new System.EventHandler(this.MainUserMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SubmitPropButton;
        private System.Windows.Forms.Button SubmitRepButton;
        private System.Windows.Forms.Button DeletePropButton;
        private System.Windows.Forms.Button UpdatePropButton;
    }
}