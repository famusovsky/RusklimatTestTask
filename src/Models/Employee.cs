namespace Employment.Models
{
    internal abstract class Employee
    {
        public string Name { get; init; }
        public uint Salary { get; protected set; }

        public Employee(string name, uint salary)
        {
            Name = name;
            Salary = salary;
        }

        public abstract void ApplyBonus(BonusCategory bonus);

        public abstract void ApplyPremium(uint premium);
    }
}