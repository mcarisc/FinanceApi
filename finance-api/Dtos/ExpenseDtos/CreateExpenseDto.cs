namespace finance_api.Dtos.ExpenseDtos
{
    public class CreateExpenseDto
    {
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
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
