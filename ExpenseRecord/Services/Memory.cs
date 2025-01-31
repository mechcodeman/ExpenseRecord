﻿using Expense.Models;


namespace Expense.Services
{
    public class MemoryService : IExpenseService
    {
        private static readonly List<Dto> _ExpenseRecords = new();

        public Task CreateAsync(Dto newExpenseRecord)
        {
            _ExpenseRecords.Add(newExpenseRecord);
            return Task.CompletedTask;
        }


        public Task<List<Dto>> GetAsync()
        {
            return Task.FromResult(_ExpenseRecords);

        }

        public Task<Dto?> GetAsync(string id)
        {
            var ExpenseRecord = _ExpenseRecords.Find(x => x.Id == id);
            return Task.FromResult(ExpenseRecord);

        }



        public Task<bool> RemoveAsync(string id)
        {
            var itemToBeRemoved = _ExpenseRecords.Find(x => x.Id == id);
            if (itemToBeRemoved is null)
            {
                return Task.FromResult(false);
            }
            _ExpenseRecords.Remove(itemToBeRemoved);
            return Task.FromResult(true);
        }



        public Task ReplaceAsync(string id, Dto updatedExpenseRecord)
        {
            var index = _ExpenseRecords.FindIndex(x => x.Id == id);
            if (index >= 0)
            {
                updatedExpenseRecord.CreatedTime = _ExpenseRecords[index].CreatedTime;
                _ExpenseRecords[index] = updatedExpenseRecord;
            }
            return Task.CompletedTask;
        }
    }
}