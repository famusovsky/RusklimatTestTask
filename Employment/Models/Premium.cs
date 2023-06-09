using System;

namespace Employment.Models
{
    /// <summary>
    /// Represents a Premium.
    /// </summary>
    public class Premium
    {
        /// <summary>
        /// Represents id of the premium.
        /// </summary>
        public uint Id { get; private init; }

        /// <summary>
        /// Represents date of the premium.
        /// </summary>
        public DateOnly CreationDate { get; init; } = DateOnly.FromDateTime(DateTime.Now);

        /// <summary>
        /// Represents id of the employee who got the premium.
        /// </summary>
        public required uint EmployeeId { get; set; }

        /// <summary>
        /// Represents volume of the premium.
        /// </summary>
        public required uint Volume { get; set; }
    }
}