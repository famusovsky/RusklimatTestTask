namespace Employment.Models.Management
{
    /// <summary>
    /// Represents a manager.
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Represents count of processed calls.
        /// </summary>
        public uint ProcessedCallsCount { get; set; } = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="id">Id of the manager.</param>
        /// <param name="name">Name of the manager.</param>
        /// <param name="salary">Salary of the manager.</param>
        /// <param name="processedCallsCount">Count of processed calls.</param>
        public Manager(uint id = 0, string name = "", uint salary = 0, uint processedCallsCount = 0) : base(id, name, salary)
        {
            ProcessedCallsCount = processedCallsCount;
        }

        /// <summary>
        /// Process a call.
        /// </summary>
        public void ProcessCall()
        {
            ProcessedCallsCount++;
            ApplyBonus(GetBonusCategory(ProcessedCallsCount));
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

        public override void ApplyBonus(BonusCategory bonus)
        {
            switch (bonus)
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
        }

        public override void ApplyPremium(uint premium)
        {
            // TODO
        }
    }
}