namespace Employment.Models
{
    internal class Manager : Employee
    {
        public uint ProcessedCallsCount { get; protected set; }

        public Manager(string name, uint salary) : base(name, salary) { }

        public void ProcessCall()
        {
            ProcessedCallsCount++;
            ApplyBonus(GetBonusCategory(ProcessedCallsCount));
        }

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