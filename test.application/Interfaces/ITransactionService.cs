using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.domain;

namespace test.application.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<Transaction> EditTransactionAsync(Guid id, Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetTransactionsByStatusAsync(string status);
    }
}
