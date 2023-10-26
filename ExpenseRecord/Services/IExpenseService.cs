using Expense.Models;

namespace Expense.Services
{
    public interface IExpenseService
    {
        Task CreateAsync(Dto newExpenseRecord);
        Task<List<Dto>> GetAsync();
        Task<Dto?> GetAsync(string id);
        Task<bool> RemoveAsync(string id);
        Task ReplaceAsync(string id, Dto updatedExpenseRecord);
    }
}
