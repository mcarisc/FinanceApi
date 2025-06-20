namespace finance_api.Dtos.IncomeDtos
{
    public class IncomeDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the income record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the source of the income.
        /// </summary>
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the amount of the income.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date create when the income.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the date update when the income.
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
