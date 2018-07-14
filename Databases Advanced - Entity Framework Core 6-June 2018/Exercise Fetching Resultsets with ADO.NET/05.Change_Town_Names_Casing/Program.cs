using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _05.Change_Town_Names_Casing
{

    public class Program
    {
        private const string ConnectionString = @"
            Server=DESKTOP-8DBTK91\SQLEXPRESS02; 
            Database=MinionsDB; 
            Integrated Security=true;";
        private const string Print = "No town names were affected.";
        public static void Main()
        {
            string countryName = Console.ReadLine();

            string getCountry = "SELECT Id FROM Countries WHERE Name=@name";
            string getTowns = "SELECT Name FROM Towns WHERE CountryCode=@country_code";
            using (SqlConnection conection =new SqlConnection(ConnectionString))
            {
                conection.Open();

                int countryId = GetCountryId(countryName,getCountry,conection);
                var cities =new List<string>();
                if (countryId!=0)
                {
                    cities = GetTownsFromCountry(countryId,getTowns,conection);
                    if (cities.Count > 0)
                    {

                        cities.Select(c => c.Select(f => char.ToUpper(f))).ToList();
                        Console.WriteLine($"{cities.Count} town names were affected.");
                        Console.Write($"[{string.Join(", ",cities)}]");
                            
                        
                    }
                    else
                    {
                        PrintResult();
                    }
                }
                else
                {
                    PrintResult();
                }

                conection.Close();
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(Print);
        }

        private static List<string> GetTownsFromCountry(int countryId, string getTowns, SqlConnection conection)
        {
            var result = new List<string>();

            using (SqlCommand command=new SqlCommand(getTowns,conection))
            {
                command.Parameters.AddWithValue("@country_code",countryId);

                using (SqlDataReader reader =command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string townName =(string)reader[0];
                        result.Add(townName);
                    }
                }

            }
            return result;
        }

        private static int GetCountryId(string countryName, string getCountry, SqlConnection conection)
        {
            int result;

            using (SqlCommand command=new SqlCommand(getCountry,conection))
            {
                command.Parameters.AddWithValue("@name",countryName);
                if (command.ExecuteScalar() == null)
                {
                    result = 0;
                }
                else
                {
                    result = (int)command.ExecuteScalar();
                }
            }
            return result;
        }
    }
}
