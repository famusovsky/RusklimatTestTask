using System;

namespace Employment.Models
{
    /// <summary>
    /// Represents processed calls record.
    /// </summary>
    public class ProcessedCallsRecord
    {
        /// <summary>
        /// Represents id of the processed calls record.
        /// </summary>
        public int Id { get; init; } = 0;

        /// <summary>
        /// Represents date of processed calls record.
        /// </summary>
        public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.Now);

        /// <summary>
        /// Represents id of the employee who processed calls.
        /// </summary>
        public required uint EmployeeId { get; set; }

        /// <summary>
        /// Represents count of processed calls.
        /// </summary>
        public required uint Count { get; set; }
    }
}