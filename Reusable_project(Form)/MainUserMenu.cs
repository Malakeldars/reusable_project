﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reusable_project_Form_
{
    public partial class MainUserMenu : Form
    {

        private int _userId;

        public MainUserMenu(int userId)
        {
            _userId = userId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubmitProposal submitProposal = new SubmitProposal(_userId);
            submitProposal.Show();
            this.Hide();
        }

        private void SubmitRepButton_Click(object sender, EventArgs e)
        {
            SubmitReport1 submitReport = new SubmitReport1(_userId);
            submitReport.Show();
            this.Hide();
        }

        private void DeletePropButton_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            update_delete_proposal update_Delete_Proposal = new update_delete_proposal(_userId);
            update_Delete_Proposal.Show();
            this.Hide() ;
        }

        private void MainUserMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
