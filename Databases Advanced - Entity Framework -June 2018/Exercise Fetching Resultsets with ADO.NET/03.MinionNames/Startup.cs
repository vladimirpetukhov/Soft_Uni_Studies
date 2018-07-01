using System;
using Fetching_Resultsets_with_ADO.NET;
using System.Data.SqlClient;
namespace _03.MinionNames
{
    public class Startup
    {

        private const string Config = @"
            Server=DESKTOP-8DBTK91\SQLEXPRESS02; 
            Database=MinionsDB; 
            Integrated Security=true;";
        public static void Main()
        {
            int vilianId = int.Parse(Console.ReadLine());

            using (SqlConnection conection = new SqlConnection(Config))
            {
                conection.Open();

                string vilianName = GetVilianName(vilianId, conection);

                if (vilianName == null)
                {
                    Console.WriteLine($"No villain with ID {vilianId} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {vilianName}");
                    PrintMinoinsNames(vilianId, conection);
                }
                conection.Close();
            }
        }

        private static void PrintMinoinsNames(int vilianId, SqlConnection conection)
        {
            string minionNames = "SELECT Name,Age FROM Minions AS m JOIN MinionsVillains AS mv ON mv.MinionId=m.Id WHERE mv.VillainId=@Id";

            using (SqlCommand comand = new SqlCommand(minionNames, conection))
            {
                comand.Parameters.AddWithValue("Id", vilianId);
                using (SqlDataReader reader = comand.ExecuteReader())
                {
                    
                        int counter = 1;
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        else
                        {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{counter++}. {reader[0]} {reader[1]}");
                        }
                        }
                    
                }
            }
        }

        private static string GetVilianName(int vilianId, SqlConnection conection)
        {
            string minionsInfo = "SELECT Name FROM Villains   WHERE Id=@id";

            using (SqlCommand comand = new SqlCommand(minionsInfo, conection))
            {
                comand.Parameters.AddWithValue("id", vilianId);
                string value = (string)comand.ExecuteScalar();
                return (string)comand.ExecuteScalar();
            }
        }
    }
}
