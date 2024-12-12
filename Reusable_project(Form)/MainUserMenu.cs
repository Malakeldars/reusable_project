using System;
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
            InitializeComponent();
            _userId = userId;
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubmitProposal submitProposal = new SubmitProposal();
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

        }

        private void MainUserMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
