using System;
using System.Linq;
using Employment.Models;
using Employment.DataBase;

public class Program
{
    public static void Main()
    {
        // добавление данных
        using (EmploymentContext db = new EmploymentContext())
        {
            // создаем два объекта Employee
            Employee employee1 = new Manager("Tom", 2500);
            Employee employee2 = new Manager("Alice", 3000);

            // добавляем их в бд
            db.Employees.AddRange(employee1, employee2);
            db.SaveChanges();
        }
        // получение данных
        using (EmploymentContext db = new EmploymentContext())
        {
            // получаем объекты из бд и выводим на консоль
            var employees = db.Employees.ToList();
            Console.WriteLine("Employees list:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.Id}. {employee.Name} - {employee.Salary}");
            }
        }
    }
}