using System.Threading.Tasks;

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

        /// <summary>
        /// Process a call.
        /// </summary>
        /// <returns>Bonus for the manager.</returns>
        public Bonus ProcessCall()
        {
            ProcessedCallsCount++;
            var bonusCategory = GetBonusCategory(ProcessedCallsCount);
            return ApplyBonus(bonusCategory);
        }

        /// <summary>
        /// Process a call async.
        /// </summary>
        /// <returns>Bonus for the manager.</returns>
        public async Task<Bonus> ProcessCallAsync()
        {
            ProcessedCallsCount++;
            var bonusCategory = GetBonusCategory(ProcessedCallsCount);
            return await Task.Run(() => ApplyBonus(bonusCategory));
        }

        /// <summary>
        /// Apply bonus to the employee.
        /// </summary>
        /// <param name="bonus">Bonus category.</param>
        /// <returns>Bonus for the manager.</returns>
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