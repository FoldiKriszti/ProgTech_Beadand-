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
    public partial class AddAdoption : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kriszti\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");
        public AddAdoption()
        {
            InitializeComponent();
            displayAnimals();
        }

        public void displayAnimals()
        {
            AdoptionData ad = new AdoptionData();
            List<AdoptionData> listData = ad.AdoptionListData();

            dataGridView1.DataSource = listData;
            dataGridView1.Refresh();
        }

        private void btn_AdoptionUpdate_Click(object sender, EventArgs e)
        {
            if (txtAnimalID.Text == ""
               || txtAnimalName.Text == ""
               || txtAnimalAge.Text == ""
               || txtFamily.Text == ""
               || txtAddress.Text == ""
               || txtPhone.Text == ""
               )
            {
                MessageBox.Show("Please fill all blank fields", "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Animal ID: "
                    + txtAnimalID.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        try
                        {
                            connection.Open();
                            DateTime today = DateTime.Today;

                            string updateData = "UPDATE animals SET name = @Name" +
                            ", age = @Age, isAdoption = @IsAdoption, family = @Family, address = @Address, phone_number = @Phone_Number, update_date = @updateDate" +
                            " WHERE animal_id = @animalID";

                            using (SqlCommand cmd = new SqlCommand(updateData, connection))
                            {

                                cmd.Parameters.AddWithValue("@Name", txtAnimalName.Text.Trim());
                                cmd.Parameters.AddWithValue("@Age", txtAnimalAge.Text.Trim());
                                cmd.Parameters.AddWithValue("@IsAdoption", txtAdoption.Text.Trim());
                                cmd.Parameters.AddWithValue("@Family", txtFamily.Text.Trim());
                                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                                cmd.Parameters.AddWithValue("@Phone_Number", txtPhone.Text.Trim());
                                cmd.Parameters.AddWithValue("@updateDate", today);
                                cmd.Parameters.AddWithValue("@animalID", txtAnimalID.Text.Trim());


                                cmd.ExecuteNonQuery();

                                displayAnimals();

                                MessageBox.Show("Updated successfully!"
                                    , "Information Message", MessageBoxButtons.OK
                                    , MessageBoxIcon.Information);

                                clearFields();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled", "Information Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btn_AdoptionClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtAnimalID.Text = row.Cells[0].Value.ToString();
                txtAnimalName.Text = row.Cells[1].Value.ToString();
                txtAnimalAge.Text = row.Cells[2].Value.ToString();
                txtAdoption.Text = row.Cells[5].Value.ToString();
                txtFamily.Text = row.Cells[6].Value.ToString();
                txtAddress.Text = row.Cells[7].Value.ToString();
                txtPhone.Text = row.Cells[8].Value.ToString();

            }
        }
        public void clearFields()
        {
            txtAnimalID.Text = "";
            txtAnimalName.Text = "";
            txtAnimalAge.Text = "";
            txtFamily.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtAdoption.SelectedIndex = -1;
        }

    }
}
