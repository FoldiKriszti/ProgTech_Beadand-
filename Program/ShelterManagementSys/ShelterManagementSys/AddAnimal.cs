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
    }
}
