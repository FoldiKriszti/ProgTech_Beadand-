﻿using ShelterManagementSys.User_Control_Panels;
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
            addAnimal1.Visible = true;
            addAdoption1.Visible = false;
            dashboard1.Visible = false;

            AddAnimal addAnForm = addAnimal1 as AddAnimal;

            if (addAnForm != null)
            {
                addAnForm.RefreshData();
            }
        }

        private void adopt_btn_Click(object sender, EventArgs e)
        {
            addAnimal1.Visible = false;
            addAdoption1.Visible = true;
            dashboard1.Visible = false;

            AddAdoption addAdForm = addAdoption1 as AddAdoption;

            if (addAdForm != null)
            {
                addAdForm.RefreshData();
            }
        }

        private void addAdoption1_Load(object sender, EventArgs e)
        {

        }

        private void dash_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            addAnimal1.Visible = false;
            addAdoption1.Visible = false;


            Dashboard dashForm = dashboard1 as Dashboard;

            if (dashForm != null)
            {
                dashForm.RefreshData();
            }

        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void dashboard1_Load_1(object sender, EventArgs e)
        {


        }
    }
}
