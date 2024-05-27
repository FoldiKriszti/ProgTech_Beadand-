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
    public partial class RegisterUser : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kriszti\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reg_check_CheckedChanged(object sender, EventArgs e)
        {
            txtPass_reg.PasswordChar = reg_check.Checked ? '\0' : '*';
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (txtUser_reg.Text == "" || txtPass_reg.Text == "")
            {
                MessageBox.Show("Please fill al the blank fields", 
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else 
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();

                        string selectUsername = "SELECT COUNT(id) FROM users WHERE username = @user";

                        using (SqlCommand checkUser = new SqlCommand(selectUsername,conn))
                        {
                            checkUser.Parameters.AddWithValue("@user", txtUser_reg.Text.Trim());
                            int count = (int)checkUser.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(txtUser_reg.Text.Trim() + " is already taken", 
                                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            else
                            {
                                string insertData = "INSERT INTO users " +
                                    "(username, password) " +
                                    "VALUES(@username, @password)";

                                using (SqlCommand cmd = new SqlCommand(insertData, conn))
                                {
                                    cmd.Parameters.AddWithValue("@username", txtUser_reg.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", txtPass_reg.Text.Trim());

                                    cmd.BeginExecuteNonQuery();

                                    MessageBox.Show("Registered succesfully!", 
                                        "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Form1 loginForm = new Form1();
                                    loginForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally 
                    {
                        conn.Close();
                    }
                }

            }
        }

        private void btn_sIN_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();    
        }
    }
}
