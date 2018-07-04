using System;
using System.Data.SqlClient;
namespace _02.Villain_Names
{
    public class Startup
    {
        private const string ConnectionString = @"
            Server=DESKTOP-8DBTK91\SQLEXPRESS02; 
            Database=MinionsDB; 
            Integrated Security=true;";
       
        static void Main()
        {
            using (SqlConnection conection=new SqlConnection(ConnectionString))
            {
                conection.Open();

                string villiansInfo= "SELECT v.Name,COUNT(mv.MinionId) AS MinioonsCount FROM MinionsVillains AS mv JOIN Villains AS v ON v.Id=mv.VillainId GROUP BY v.Name HAVING COUNT(mv.MinionId)>=3 ORDER BY MinioonsCount DESC";

                using (SqlCommand command=new SqlCommand(villiansInfo,conection))
                {
                    using (SqlDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader[0].ToString();
                            string count = reader[1].ToString();

                            Console.WriteLine($"{name} - {count}");
                        }
                    }
                }

                    conection.Close();
            }
        }
    }
}
