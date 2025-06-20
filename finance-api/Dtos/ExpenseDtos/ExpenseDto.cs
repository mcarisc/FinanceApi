namespace finance_api.Dtos.ExpenseDtos
{
    public class ExpenseDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the expense record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the expense.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the amount of the expense.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date create when the expense.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the date update when the expense.
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
