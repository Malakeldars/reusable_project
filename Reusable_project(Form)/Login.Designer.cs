namespace Reusable_project_Form_
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.themesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reusable_projectDataSet = new Reusable_project_Form_.Reusable_projectDataSet();
            this.themesTableAdapter = new Reusable_project_Form_.Reusable_projectDataSetTableAdapters.ThemesTableAdapter();
            this.logginbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.signInPagebtn = new System.Windows.Forms.Button();
            this.SignUpPagebtn = new System.Windows.Forms.Button();
            this.ShowPasswordCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.themesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reusable_projectDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // themesBindingSource
            // 
            this.themesBindingSource.DataMember = "Themes";
            this.themesBindingSource.DataSource = this.reusable_projectDataSet;
            // 
            // reusable_projectDataSet
            // 
            this.reusable_projectDataSet.DataSetName = "Reusable_projectDataSet";
            this.reusable_projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // themesTableAdapter
            // 
            this.themesTableAdapter.ClearBeforeFill = true;
            // 
            // logginbtn
            // 
            this.logginbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.logginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logginbtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.logginbtn.Location = new System.Drawing.Point(140, 395);
            this.logginbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logginbtn.Name = "logginbtn";
            this.logginbtn.Size = new System.Drawing.Size(184, 42);
            this.logginbtn.TabIndex = 29;
            this.logginbtn.Text = "Login";
            this.logginbtn.UseVisualStyleBackColor = true;
            this.logginbtn.Click += new System.EventHandler(this.logginbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.signInPagebtn);
            this.panel1.Controls.Add(this.SignUpPagebtn);
            this.panel1.Location = new System.Drawing.Point(549, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 599);
            this.panel1.TabIndex = 31;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // signInPagebtn
            // 
            this.signInPagebtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.signInPagebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInPagebtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.signInPagebtn.Location = new System.Drawing.Point(135, 274);
            this.signInPagebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.signInPagebtn.Name = "signInPagebtn";
            this.signInPagebtn.Size = new System.Drawing.Size(147, 44);
            this.signInPagebtn.TabIndex = 25;
            this.signInPagebtn.Text = "Sign In";
            this.signInPagebtn.UseVisualStyleBackColor = true;
            this.signInPagebtn.Click += new System.EventHandler(this.signInPagebtn_Click_1);
            // 
            // SignUpPagebtn
            // 
            this.SignUpPagebtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SignUpPagebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpPagebtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.SignUpPagebtn.Location = new System.Drawing.Point(135, 174);
            this.SignUpPagebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SignUpPagebtn.Name = "SignUpPagebtn";
            this.SignUpPagebtn.Size = new System.Drawing.Size(147, 46);
            this.SignUpPagebtn.TabIndex = 26;
            this.SignUpPagebtn.Text = "Sign Up";
            this.SignUpPagebtn.UseVisualStyleBackColor = true;
            this.SignUpPagebtn.Click += new System.EventHandler(this.SignUpPagebtn_Click_1);
            // 
            // ShowPasswordCheck
            // 
            this.ShowPasswordCheck.AutoSize = true;
            this.ShowPasswordCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPasswordCheck.Location = new System.Drawing.Point(86, 317);
            this.ShowPasswordCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowPasswordCheck.Name = "ShowPasswordCheck";
            this.ShowPasswordCheck.Size = new System.Drawing.Size(129, 21);
            this.ShowPasswordCheck.TabIndex = 30;
            this.ShowPasswordCheck.Text = "Show Password";
            this.ShowPasswordCheck.UseVisualStyleBackColor = true;
            this.ShowPasswordCheck.CheckedChanged += new System.EventHandler(this.ShowPasswordCheck_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 28;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(81, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "Email";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PasswordTextbox.Location = new System.Drawing.Point(86, 275);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(301, 28);
            this.PasswordTextbox.TabIndex = 26;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            // 
            // emailTextbox
            // 
            this.emailTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailTextbox.Location = new System.Drawing.Point(86, 174);
            this.emailTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 5, 2);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(301, 28);
            this.emailTextbox.TabIndex = 25;
            this.emailTextbox.UseWaitCursor = true;
            this.emailTextbox.TextChanged += new System.EventHandler(this.emailTextbox_TextChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 598);
            this.Controls.Add(this.logginbtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ShowPasswordCheck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.themesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reusable_projectDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource themesBindingSource;
        private Reusable_projectDataSet reusable_projectDataSet;
        private Reusable_projectDataSetTableAdapters.ThemesTableAdapter themesTableAdapter;
        private System.Windows.Forms.Button logginbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button signInPagebtn;
        private System.Windows.Forms.Button SignUpPagebtn;
        private System.Windows.Forms.CheckBox ShowPasswordCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox emailTextbox;
    }
}

