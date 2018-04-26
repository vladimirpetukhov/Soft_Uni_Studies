namespace _08.PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static readonly Dictionary<string, Pet> Pets = new Dictionary<string, Pet>();
        private static readonly Dictionary<string, Clinic> Clinics = new Dictionary<string, Clinic>();

        public static void Main()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandTokens = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();
                var command = commandTokens[0];
                commandTokens = commandTokens.Skip(1).ToList();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            CreateEntity(commandTokens);
                            break;
                        case "Add":
                            Console.WriteLine(AddPetToClinic(commandTokens));
                            break;
                        case "Release":
                            Console.WriteLine(ReleasePetFromClinic(commandTokens[0]));
                            break;
                        case "HasEmptyRooms":
                            Console.WriteLine(FindEmptyRoomsInClinic(commandTokens[0]));
                            break;
                        case "Print":
                            PrintClinicRooms(commandTokens);
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }
        }

        private static void PrintClinicRooms(IReadOnlyList<string> commandTokens)
        {
            var clinicName = commandTokens[0];
            var clinic = Clinics[clinicName];

            switch (commandTokens.Count)
            {
                case 1:
                    clinic.PrintAllRooms();
                    break;
                case 2:
                    clinic.PrintRoom(int.Parse(commandTokens[1]) - 1);
                    break;
            }
        }

        private static bool FindEmptyRoomsInClinic(string clinicName)
        {
            return Clinics[clinicName].HasEmptyRooms();
        }

        private static bool ReleasePetFromClinic(string clinicName)
        {
            return Clinics[clinicName].TryReleasePet();
        }

        private static bool AddPetToClinic(IReadOnlyList<string> commandTokens)
        {
            var petName = commandTokens[0];
            var clinicName = commandTokens[1];
            var pet = Pets[petName];
            var clinic = Clinics[clinicName];

            if (!clinic.TryAddPet(pet)) return false;
            Pets.Remove(petName);
            return true;
        }

        private static void CreateEntity(IReadOnlyList<string> commandTokens)
        {
            var entityType = commandTokens[0];
            var name = commandTokens[1];

            switch (entityType)
            {
                case "Pet":
                    int age = int.Parse(commandTokens[2]);
                    string type = commandTokens[3];
                    Pets[name] = new Pet(name, age, type);
                    break;
                case "Clinic":
                    int numberOfRooms = int.Parse(commandTokens[2]);
                    Clinics[name] = new Clinic(name, numberOfRooms);
                    break;
            }
        }

    }
}
