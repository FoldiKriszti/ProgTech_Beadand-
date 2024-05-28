using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterManagementSys
{
    internal class AnimalsData
    {
        
        public int ID { get; set; }
        public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string Adoption { get; set; }
        public string Sick { get; set; }
        public string Vaccination { get; set; }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Dula-Demkó Emese\Documents\animals.mdf"";Integrated Security=True;Connect Timeout=30");

        public List<AnimalsData> animalsListData()
        {
            List<AnimalsData> listdata = new List<AnimalsData>();

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    string selectData = "SELECT * FROM animals WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AnimalsData ad = new AnimalsData();
                            ad.ID = (int)reader["id"];
                            ad.AnimalID = reader["animal_id"].ToString();
                            ad.Name = reader["name"].ToString();
                            ad.Species = reader["species"].ToString();
                            ad.Age = (int)reader["age"];
                            ad.Adoption = reader["isAdoption"].ToString();
                            ad.Sick = reader["sick"].ToString();
                            ad.Vaccination = reader["vaccina"].ToString();

                            listdata.Add(ad);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connection.Close();
                }

            }

            return listdata;
        }
    }
}
