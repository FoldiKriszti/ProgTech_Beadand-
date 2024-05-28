using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterManagementSys
{
    internal class AdoptionData
    {
        public int ID { get; set; }
        public string AnimalID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Adoption { get; set; }
        public string Family { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }


        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kriszti\Documents\employee.mdf;Integrated Security=True;Connect Timeout=30");

        public List<AdoptionData> AdoptionListData()
        {
            List<AdoptionData> listdata = new List<AdoptionData>();

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
                            AdoptionData ad = new AdoptionData();
                            ad.ID = (int)reader["id"];
                            ad.AnimalID = reader["animal_id"].ToString();
                            ad.Name = reader["name"].ToString();
                            ad.Age = (int)reader["age"];
                            ad.Adoption = reader["isAdoption"].ToString();
                            ad.Family = reader["family"].ToString();
                            ad.Address = reader["address"].ToString();
                            ad.Phone_number = reader["phone_number"].ToString();

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
