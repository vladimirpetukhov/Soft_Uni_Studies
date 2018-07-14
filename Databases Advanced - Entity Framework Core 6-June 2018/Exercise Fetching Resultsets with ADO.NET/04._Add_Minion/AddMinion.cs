using System;
using System.Linq;
using System.Data.SqlClient;
namespace _04._Add_Minion
{
   public class AddMinion
    {
        private const string ConnectionString = @"
            Server=DESKTOP-8DBTK91\SQLEXPRESS02; 
            Database=MinionsDB; 
            Integrated Security=true;";
        public static void Main()
        {
            var minionInfo = Console.ReadLine().Split().ToArray();
            var minionName = minionInfo[1];
            var minionAge = int.Parse(minionInfo[2]);
            var minionTown = minionInfo[3];

            var villainInfo= Console.ReadLine().Split().ToArray();
            var villainName = villainInfo[1];

            

            using (SqlConnection conection=new SqlConnection(ConnectionString))
            {
                conection.Open();

                string townPatern = $"select t.Id from Towns as t where t.Name=@name";
                string villainPatern = "select v.Id from Villains as v where v.Name=@name";
                int townId=MinionTownName(minionTown,townPatern, conection);
                int villainId = GetVillainId(villainName,villainPatern,conection);
                int minionId = InsertMinionAndGetId(minionName,minionAge,minionTown,conection);
                AssignMinionToVillain(villainId,minionId,conection);
                Console.WriteLine($"Successfully added {minionName} to be minion of {minionTown}.");
                conection.Close();
            }
        }

        private static void AssignMinionToVillain(int villainId, int minionId, SqlConnection conection)
        {
            string inserting = "insert into MinionsVillains(MinionId,VillainId) values (@minionId,@villainId)";
            using (SqlCommand command=new SqlCommand(inserting,conection))
            {
                command.Parameters.AddWithValue("@minionId",minionId);
                command.Parameters.AddWithValue("@villainId",villainId);

                command.ExecuteNonQuery();
            }
        }

        private static int InsertMinionAndGetId(string minionName, int minionAge, string minionTown, SqlConnection conection)
        {
            string insertMinion = "insert into Minions (Name,Age,TownId) values (@name,@age,@townId)";

            using (SqlCommand command=new SqlCommand(insertMinion,conection))
            {
                command.Parameters.AddWithValue("@name",minionName);
                command.Parameters.AddWithValue("@age",minionAge);
                command.Parameters.AddWithValue("@townId",minionTown);
                command.ExecuteNonQuery();
            }
            string minionSql = "select Id from Minions where Name=@name";

            using (SqlCommand command = new SqlCommand(minionSql, conection))
            {
                command.Parameters.AddWithValue("@name", minionName);

                return (int)command.ExecuteScalar();
            }
        }

        private static int GetVillainId(string villainName, string villainPatern, SqlConnection conection)
        {
            using (SqlCommand commmand = new SqlCommand(villainPatern, conection))
            {
                commmand.Parameters.AddWithValue("@name", villainName);

                if (commmand.ExecuteScalar() == null)
                {
                    InsertIntoTowns(villainName, conection);
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                return (int)commmand.ExecuteScalar();

            }
        }

        private static int MinionTownName(string minionTown, string townPatern, SqlConnection conection)
        {
            using (SqlCommand commmand=new SqlCommand(townPatern,conection))
            {
                commmand.Parameters.AddWithValue("@name",minionTown);

                if (commmand.ExecuteScalar() == null)
                {
                    InsertMinionToVillain(minionTown,conection);
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }
                var i= commmand.ExecuteScalar();
                return (int)commmand.ExecuteScalar();
                 
            }
            
        }

        private static void InsertMinionToVillain(string villianName, SqlConnection conection)
        {
            string insertPatern = "INSERT INTO Villains (Name) VALUES ('@villain_name')";

            using (SqlCommand command = new SqlCommand(insertPatern, conection))
            {
                command.Parameters.AddWithValue("@villain_name",villianName );

                command.ExecuteNonQuery();

                

            }
        }

        private static void InsertIntoTowns(string minionTown, SqlConnection conection)
        {
            string insertPatern = "INSERT INTO Towns (Name) VALUES ('@town_name')";

            using (SqlCommand command=new SqlCommand(insertPatern,conection))
            {
                command.Parameters.AddWithValue("@town_name", minionTown);

                command.ExecuteNonQuery();

                //var m= command.ExecuteNonQuery();

            }
        }
    }
}
