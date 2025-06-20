using finance_api.Dtos.ExpenseDtos;
using finance_api.Dtos.IncomeDtos;
using finance_api.Models;

namespace finance_api.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() 
        {
            // Income
            CreateMap<Income, IncomeDto>();
            CreateMap<CreateIncomeDto, Income>();

            // Expense
            CreateMap<Expense, ExpenseDto>();
            CreateMap<CreateExpenseDto, Expense>();
        }
    }
}
