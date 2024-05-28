using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShelterManagementSys
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Dula-Demkó Emese\Documents\animals.mdf"";Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == " " || txtPass.Text == "")
            {
                MessageBox.Show("Please fill all the blank fields", 
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();

                        string selectData = "SELECT * FROM users WHERE username = @username AND password = @password";

                        using (SqlCommand cmd = new SqlCommand(selectData, connection))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUser.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", txtPass.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Login succesfully", 
                                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Shelter s = new Shelter();
                                s.Show();
                                this.Hide();
                            }

                            else
                            {
                                MessageBox.Show("Incorrect username/password", 
                                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

        }

        private void txtUser_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }

        

        private void exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_sUP_Click(object sender, EventArgs e)
        {
            RegisterUser regForm = new RegisterUser();
            regForm.Show();
            this.Hide();
            
        }

        private void login_check_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = login_check.Checked ? '\0' : '*';            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
