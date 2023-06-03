namespace Employment.Models
{
    /// <summary>
    /// Represents a manager.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Represents Id of the employee.
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Represents name of the employee.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Represents salary of the employee.
        /// </summary>
        public uint Salary { get; set; } = 0;

        /// <summary>
        /// Represents count of processed calls.
        /// </summary>
        public uint ProcessedCallsCount { get; set; } = 0;

        /// <summary>
        /// Process a call.
        /// </summary>
        public Bonus ProcessCall()
        {
            ProcessedCallsCount++;
            return ApplyBonus(GetBonusCategory(ProcessedCallsCount));
        }

        /// <summary>
        /// Get bonus category for the manager.
        /// </summary>
        /// </param name="processedCallsCount">Count of processed calls.</param>
        public static BonusCategory GetBonusCategory(uint processedCallsCount)
        {
            switch (processedCallsCount)
            {
                case <= 100:
                    return BonusCategory.Low;
                case <= 200:
                    return BonusCategory.Medium;
                default:
                    return BonusCategory.High;
            }
        }

        /// <summary>
        /// Apply bonus to the employee.
        /// </summary>
        /// <param name="bonus">Bonus category.</param>
        public Bonus ApplyBonus(BonusCategory bonusCategory)
        {
            var bonus = new Bonus { Category = bonusCategory, EmployeeId = (uint)Id };

            switch (bonus.Category)
            {
                case BonusCategory.Low:
                    Salary += 100;
                    break;
                case BonusCategory.Medium:
                    Salary += 200;
                    break;
                case BonusCategory.High:
                    Salary += 300;
                    break;
            }

            return bonus;
        }
    }
}