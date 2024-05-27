using ShelterManagementSys.User_Control_Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShelterManagementSys
{
    public partial class Shelter : Form
    {
        public Shelter()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to login?", 
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes) 
            {
                Form1 loginform = new Form1();
                loginform.Show();
                this.Hide();
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
           
        }
    }
}
