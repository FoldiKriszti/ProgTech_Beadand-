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

namespace ShelterManagementSys.User_Control_Panels
{
    public partial class AddAnimal : UserControl
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kriszti\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");
        public AddAnimal()
        {
            InitializeComponent();
            displayAnimalsData();
        }
        public void displayAnimalsData()
        {
            AnimalsData ad = new AnimalsData();
            List<AnimalsData> listData = ad.animalsListData();

            dataGridView1.DataSource = listData;
        }

        public void clearFields()
        {
            addAnimalID.Text = "";
            addName.Text = "";
            addSpecies.SelectedIndex = -1;
            addAge.Text = "";
            addAdoption.SelectedIndex = -1;
            addSick.SelectedIndex = -1;
            addVaccina.SelectedIndex = -1;  
        }
        private void btn_AddAnimal_Click(object sender, EventArgs e)
        {
            if (addAnimalID.Text == "" || addName.Text == "" || addSpecies.Text == ""
                || addAge.Text == "" || addAdoption.Text == "" 
                || addSick.Text == "" || addVaccina.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", 
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();

                        string checkAnID = "SELECT COUNT(*) FROM animals WHERE animal_id = @anID AND delete_date IS NULL";

                        using (SqlCommand checkAN = new SqlCommand(checkAnID, connection))
                        {
                            checkAN.Parameters.AddWithValue("@anID", addAnimalID.Text.Trim());
                            int count = (int)checkAN.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(addAnimalID.Text.Trim() + " is already taken", 
                                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO animals" +
                                    "(animal_id, name, species, age, insert_date, isAdoption, sick, vaccina)" +
                                    "VALUES(@animalID, @Name, @Species, @Age, @insertDate, @IsAdoption, @sick, @vaccina)";

                                using (SqlCommand cmd = new SqlCommand(insertData, connection))
                                {
                                    cmd.Parameters.AddWithValue("@animalID", addAnimalID.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Name", addName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Species", addSpecies.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Age", addAge.Text.Trim());
                                    cmd.Parameters.AddWithValue("@IsAdoption", addAdoption.Text.Trim());
                                    cmd.Parameters.AddWithValue("@insertDate", today);
                                    cmd.Parameters.AddWithValue("@sick", addSick.Text.Trim());
                                    cmd.Parameters.AddWithValue("@vaccina", addVaccina.Text.Trim());

                                    cmd.ExecuteNonQuery();

                                    displayAnimalsData();

                                    MessageBox.Show("Added succesfully!", 
                                        "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { connection.Close(); }
                }
            }
        }

        private void btn_UpdateAnimal_Click(object sender, EventArgs e)
        {
            if (addAnimalID.Text == "" || addName.Text == "" || addSpecies.Text == ""
                || addAge.Text == "" || addAdoption.Text == ""
                || addSick.Text == "" || addVaccina.Text == "")
            {
                MessageBox.Show("Please fill all blank fields",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are u sure u want to UPDATE " +
                    "Animal ID: " + addAnimalID.Text.Trim() + "?", "Confirmation Message", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE animals SET name = @Name" +
                            ", species = @Species, age = @Age" +
                            ", isAdoption = @IsAdoption, update_date = @updateDate, sick = @sick, vaccina = @vaccina" +
                            " WHERE animal_id = @animalID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connection))
                        {
                            cmd.Parameters.AddWithValue("@Name", addName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Species", addSpecies.Text.Trim());
                            cmd.Parameters.AddWithValue("@Age", addAge.Text.Trim());
                            cmd.Parameters.AddWithValue("@IsAdoption", addAdoption.Text.Trim());
                            cmd.Parameters.AddWithValue("@sick", addSick.Text.Trim());
                            cmd.Parameters.AddWithValue("@vaccina", addVaccina.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);
                            cmd.Parameters.AddWithValue("@animalID", addAnimalID.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayAnimalsData();

                            MessageBox.Show("UPDATED successfully!", 
                                "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
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

                else
                {
                    MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void btn_DeleteAnimal_Click(object sender, EventArgs e)
        {
            if (addAnimalID.Text == "" || addName.Text == "" || addSpecies.Text == ""
                 || addAge.Text == "" || addAdoption.Text == ""
                 || addSick.Text == "" || addVaccina.Text == "")
            {
                MessageBox.Show("Please fill all blank fields",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are u sure u want to DELETE " +
                    "Animal ID: " + addAnimalID.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE animals SET delete_date = @deleteDate " +
                            "WHERE animal_id = @animalID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connection))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@animalID", addAnimalID.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayAnimalsData();

                            MessageBox.Show("Update successfully!", 
                                "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, 
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled.", 
                        "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                addAnimalID.Text = row.Cells[1].Value.ToString();
                addName.Text = row.Cells[2].Value.ToString();
                addSpecies.Text = row.Cells[3].Value.ToString();
                addAge.Text = row.Cells[4].Value.ToString();
                addAdoption.Text = row.Cells[5].Value.ToString();
                addSick.Text = row.Cells[6].Value.ToString();
                addVaccina.Text = row.Cells[7].Value.ToString();
            }
        }

        private void AddAnimal_Load(object sender, EventArgs e)
        {

        }
    }
}
