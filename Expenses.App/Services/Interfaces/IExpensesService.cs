using Expenses.App.Models;
using Expenses.App.Models.Common;

namespace Expenses.App.Services
{
    public interface IExpensesService
	{
        Task<ServiceResult<IEnumerable<Expense>>> FindAll();
        Task<ServiceResult> CreateExpense(Expense data);
        Task<ServiceResult> UpdateExpense(Guid expenseUid, Expense data);
        Task<ServiceResult> DeleteExpense(Guid expenseUid);
    }
}