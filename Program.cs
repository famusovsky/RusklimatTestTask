using System;
using System.IO;
using System.Linq;
using Employment.Models;
using Employment.DataBase;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main()
    {
        // XXX: Testing
        IConfiguration config;

        try
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.InnerException.Message);
            return;
        }

        try
        {
            using (ManagementDbContext db = new ManagementDbContext(config))
            {
                do
                {
                    Console.WriteLine("Enter manager name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter manager salary:");
                    uint salary = uint.Parse(Console.ReadLine());
                    db.Managers.Add(new Manager(name: name, salary: salary));
                    db.SaveChanges();
                    Console.WriteLine("Manager added", "Add new manager? (y/...)");
                }
                while (Console.ReadLine() == "y");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.InnerException.Message);
        }

        try
        {
            using (ManagementDbContext db = new ManagementDbContext(config))
            {
                // получаем объекты из бд и выводим на консоль
                var employees = db.Managers.ToList();
                Console.WriteLine("Employees list:");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"{employee.Id}. {employee.Name} - {employee.Salary}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.InnerException.Message);
        }
    }
}