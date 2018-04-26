namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class HarvestingFieldsTest
    {
        static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {

                var type = typeof(HarvestingFields);

                var command = input;
                switch (command)
                {
                    case "private":
                        var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(f=> f.IsPrivate);
                        PrintFields(privateFields);
                        break;
                    case "protected":
                        var protectedFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(f=> f.IsFamily);
                        PrintFields(protectedFields);
                        break;
                    case "public":
                        var publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public)
                            .Where(f => f.IsPublic);
                        PrintFields(publicFields);
                        break;
                    case "all":
                        var allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        PrintFields(allFields);
                        break;
                }
            }
        }

        private static void PrintFields(IEnumerable<FieldInfo> fields)
        {
            foreach (var field in fields)
            {
                Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
