using System;

namespace Employment.Models
{
    /// <summary>
    /// Represents a bonus.
    /// </summary>
    public class Bonus
    {
        /// <summary>
        /// Gets or sets the Id of the bonus.
        /// </summary>
        public uint Id { get; init; }
        /// <summary>
        /// Gets or sets the Id of the employee who received the bonus.
        /// </summary>
        public uint EmployeeId { get; init; }

        /// <summary>
        /// Gets or sets the category of the bonus.
        /// </summary>
        public BonusCategory Category { get; init; }

        /// <summary>
        /// Gets or sets the creation date of the bonus.
        /// </summary>
        public DateOnly CreationDate { get; private init; } = DateOnly.FromDateTime(DateTime.Now);
    }
}