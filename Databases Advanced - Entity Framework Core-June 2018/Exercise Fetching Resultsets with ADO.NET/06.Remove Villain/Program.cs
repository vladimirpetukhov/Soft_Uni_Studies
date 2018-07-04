using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _06.Remove_Villain
{
   public class Program
    {
        private const string ConnectionString = @"
            Server=DESKTOP-8DBTK91\SQLEXPRESS02; 
            Database=MinionsDB; 
            Integrated Security=true;";
        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection dbCon = new SqlConnection(ConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT Id FROM Villains WHERE Id = @Id", dbCon);
                command.Parameters.AddWithValue("@Id", villainId);

                int? result = (int?)command.ExecuteScalar();

                if (result == null)
                {
                    Console.WriteLine("No such villain was found.");
                    dbCon.Close();
                    return;
                }

                command = new SqlCommand("SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @Id", dbCon);
                command.Parameters.AddWithValue("@Id", villainId);
                int minionsCount = (int)command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @Id", dbCon);
                command.Parameters.AddWithValue("@Id", villainId);
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", dbCon);
                command.Parameters.AddWithValue("@Id", villainId);
                string villainName = (string)command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM Villains WHERE Id = @Id", dbCon);
                command.Parameters.AddWithValue("@Id", villainId);
                command.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }
        } }
}
