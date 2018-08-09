namespace FastFood.DataProcessor
{
    using System;
    using FastFood.Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Text;

    using Dto.Import;
    using Models;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;
    using FastFood.Models.Enums;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var json = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var sb = new StringBuilder();

            var validEmployees = new HashSet<Employee>();

            foreach (var dto in json)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var postion = GetPostion(context, dto.Position);

                var employee = new Employee
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Position = postion
                };

                validEmployees.Add(employee);

                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().Trim();

        }



        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var itemsJson = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var sb = new StringBuilder();

            var validItems = new HashSet<Item>();

            foreach (var itemDto in itemsJson)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var itemExist = validItems.Any(i => i.Name == itemDto.Name);

                if (itemExist == true)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = GetCategory(context, itemDto.Category);

                var item = new Item
                {
                    Name = itemDto.Name,
                    Category = category,
                    Price = itemDto.Price
                };

                validItems.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.AddRange(validItems);
            context.SaveChanges();

            return sb.ToString().Trim();
        }



        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));

            var deserializer = (OrderDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var validOrders = new HashSet<Order>();
            var orderItems = new HashSet<OrderItem>();

            foreach (var dto in deserializer)
            {
                bool isValidItem = true;

                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var item in dto.ItemOrderDto)
                {
                    if (!IsValid(item))
                    {
                        sb.AppendLine(FailureMessage);
                        isValidItem = false;
                        break;
                    }
                }

                if (!isValidItem)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var employee = context.Employees.FirstOrDefault(n => n.Name == dto.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var areItemValid = AreItemValid(context, dto.ItemOrderDto);

                if (!areItemValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var date = DateTime.ParseExact(dto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var type = Enum.Parse<OrderType>(dto.Type);

                var order = new Order
                {
                    Customer = dto.Customer,
                    Employee = employee,
                    DateTime = date,
                    Type = type

                };

                validOrders.Add(order);
                
                foreach (var itemDto in dto.ItemOrderDto)
                {
                    var item = context.Items.FirstOrDefault(n => n.Name == itemDto.Name);

                    var orderItem = new OrderItem
                    {
                        Order = order,
                        Item = item,
                        Quantity = itemDto.Quantity
                    };

                    orderItems.Add(orderItem);

                   
                }
                sb.AppendLine($"Order for {dto.Customer} on {date.ToString("dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture)} added");
            }
            context.AddRange(validOrders);
            context.SaveChanges();

            context.AddRange(orderItems);
            context.SaveChanges();

            return sb.ToString().Trim();
        }



        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }

        private static Position GetPostion(FastFoodDbContext context, string position)
        {
            var pos = context.Positions.FirstOrDefault(n => n.Name == position);

            if (pos == null)
            {
                pos = new Position
                {
                    Name = position
                };

                context.Add(pos);
                context.SaveChanges();
            }



            return pos;
        }

        private static Category GetCategory(FastFoodDbContext context, string categoryName)
        {
            var category = context.Categories.FirstOrDefault(n => n.Name == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName
                };

                context.Add(category);

                context.SaveChanges();
            }

            return category;
        }

        private static bool AreItemValid(FastFoodDbContext context, ItemOrderDto[] itemOrderDto)
        {
            bool exist = true;

            foreach (var item in itemOrderDto)
            {
                var itemExist = context.Items.Any(n => n.Name == item.Name);

                if (itemExist == false)
                {
                    return false;
                }

            }

            return exist;
        }
    }
}