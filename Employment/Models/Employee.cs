namespace Employment.Models
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Represents general count of employees.
        /// </summary>
        protected static uint employeesCount = 0;

        /// <summary>
        /// Represents Id of the employee.
        /// </summary>
        public uint Id { get; protected init; }

        /// <summary>
        /// Represents name of the employee.
        /// </summary>
        public string Name { get; protected init; }

        /// <summary>
        /// Represents salary of the employee.
        /// </summary>
        public uint Salary { get; protected set; } = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">Name of the employee.</param>
        /// <param name="salary">Salary of the employee.</param>
        public Employee(string name, uint salary = 0)
        {
            employeesCount++;

            Id = employeesCount;
            Name = name;
            Salary = salary;
        }

        /// <summary>
        /// Apply bonus to the employee.
        /// </summary>
        /// <param name="bonus">Bonus category.</param>
        public abstract void ApplyBonus(BonusCategory bonus);

        /// <summary>
        /// Apply premium to the employee.
        /// </summary>
        /// <param name="premium">Premium amount.</param>
        public abstract void ApplyPremium(uint premium);
    }
}