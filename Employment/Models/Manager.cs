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
        public uint Id { get; private init; }

        /// <summary>
        /// Represents name of the employee.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Represents salary of the employee.
        /// </summary>
        public uint DefaultSalary { get; set; } = 0;

        /// <summary>
        /// Get bonus category for the manager.
        /// </summary>
        /// </param name="processedCallsCount">Count of processed calls.</param>
        /// <returns>Bonus category.</returns>
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
    }
}