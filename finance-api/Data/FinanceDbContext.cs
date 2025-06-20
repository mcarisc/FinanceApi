using finance_api.Models;
using Microsoft.EntityFrameworkCore;

namespace finance_api.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Income>().ToTable("Incomes");
            modelBuilder.Entity<Expense>().ToTable("Expenses");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
