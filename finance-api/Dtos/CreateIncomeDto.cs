namespace finance_api.Dtos
{
    public class CreateIncomeDto
    {
        /// <summary>
        /// Gets or sets the description of the income.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the amount of the income.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date create when the income.
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
