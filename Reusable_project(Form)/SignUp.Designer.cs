﻿namespace Reusable_project_Form_
{
    partial class SignUp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.signInPagebtn = new System.Windows.Forms.Button();
            this.SignUpPagebtn = new System.Windows.Forms.Button();
            this.usertypeDropDown = new System.Windows.Forms.ComboBox();
            this.SignUpbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNametextbox = new System.Windows.Forms.TextBox();
            this.ShowPasswordCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.signInPagebtn);
            this.panel1.Controls.Add(this.SignUpPagebtn);
            this.panel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 599);
            this.panel1.TabIndex = 33;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // signInPagebtn
            // 
            this.signInPagebtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.signInPagebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInPagebtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.signInPagebtn.Location = new System.Drawing.Point(104, 306);
            this.signInPagebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.signInPagebtn.Name = "signInPagebtn";
            this.signInPagebtn.Size = new System.Drawing.Size(147, 44);
            this.signInPagebtn.TabIndex = 32;
            this.signInPagebtn.Text = "Sign In";
            this.signInPagebtn.UseVisualStyleBackColor = true;
            this.signInPagebtn.Click += new System.EventHandler(this.signInPagebtn_Click_1);
            // 
            // SignUpPagebtn
            // 
            this.SignUpPagebtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SignUpPagebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpPagebtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.SignUpPagebtn.Location = new System.Drawing.Point(104, 208);
            this.SignUpPagebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SignUpPagebtn.Name = "SignUpPagebtn";
            this.SignUpPagebtn.Size = new System.Drawing.Size(147, 46);
            this.SignUpPagebtn.TabIndex = 33;
            this.SignUpPagebtn.Text = "Sign Up";
            this.SignUpPagebtn.UseVisualStyleBackColor = true;
            this.SignUpPagebtn.Click += new System.EventHandler(this.SignUpPagebtn_Click_1);
            // 
            // usertypeDropDown
            // 
            this.usertypeDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertypeDropDown.FormattingEnabled = true;
            this.usertypeDropDown.Items.AddRange(new object[] {
            "User",
            "Referee"});
            this.usertypeDropDown.Location = new System.Drawing.Point(521, 407);
            this.usertypeDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usertypeDropDown.Name = "usertypeDropDown";
            this.usertypeDropDown.Size = new System.Drawing.Size(160, 28);
            this.usertypeDropDown.TabIndex = 42;
            this.usertypeDropDown.SelectedIndexChanged += new System.EventHandler(this.usertypeDropDown_SelectedIndexChanged);
            // 
            // SignUpbtn
            // 
            this.SignUpbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SignUpbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpbtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.SignUpbtn.Location = new System.Drawing.Point(593, 482);
            this.SignUpbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SignUpbtn.Name = "SignUpbtn";
            this.SignUpbtn.Size = new System.Drawing.Size(184, 42);
            this.SignUpbtn.TabIndex = 41;
            this.SignUpbtn.Text = "Login";
            this.SignUpbtn.UseVisualStyleBackColor = true;
            this.SignUpbtn.Click += new System.EventHandler(this.SignUpbtn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(517, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "User Name";
            // 
            // UserNametextbox
            // 
            this.UserNametextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNametextbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserNametextbox.Location = new System.Drawing.Point(523, 118);
            this.UserNametextbox.Margin = new System.Windows.Forms.Padding(3, 4, 5, 2);
            this.UserNametextbox.Name = "UserNametextbox";
            this.UserNametextbox.Size = new System.Drawing.Size(301, 29);
            this.UserNametextbox.TabIndex = 39;
            this.UserNametextbox.UseWaitCursor = true;
            // 
            // ShowPasswordCheck
            // 
            this.ShowPasswordCheck.AutoSize = true;
            this.ShowPasswordCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPasswordCheck.Location = new System.Drawing.Point(521, 347);
            this.ShowPasswordCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowPasswordCheck.Name = "ShowPasswordCheck";
            this.ShowPasswordCheck.Size = new System.Drawing.Size(129, 21);
            this.ShowPasswordCheck.TabIndex = 38;
            this.ShowPasswordCheck.Text = "Show Password";
            this.ShowPasswordCheck.UseVisualStyleBackColor = true;
            this.ShowPasswordCheck.CheckedChanged += new System.EventHandler(this.ShowPasswordCheck_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(517, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 37;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(518, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 24);
            this.label7.TabIndex = 36;
            this.label7.Text = "Email";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PasswordTextbox.Location = new System.Drawing.Point(523, 306);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(301, 28);
            this.PasswordTextbox.TabIndex = 35;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            // 
            // emailTextbox
            // 
            this.emailTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailTextbox.Location = new System.Drawing.Point(523, 208);
            this.emailTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 5, 2);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(301, 28);
            this.emailTextbox.TabIndex = 34;
            this.emailTextbox.UseWaitCursor = true;
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usertypeDropDown);
            this.Controls.Add(this.SignUpbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNametextbox);
            this.Controls.Add(this.ShowPasswordCheck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button signInPagebtn;
        private System.Windows.Forms.Button SignUpPagebtn;
        private System.Windows.Forms.ComboBox usertypeDropDown;
        private System.Windows.Forms.Button SignUpbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserNametextbox;
        private System.Windows.Forms.CheckBox ShowPasswordCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox emailTextbox;
    }
}