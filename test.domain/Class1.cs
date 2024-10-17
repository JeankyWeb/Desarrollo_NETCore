using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.domain
{
    public class Transaction
    {
        public Guid Id { get; set; } 
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; } 
        public string Status { get; set; }
    }
    public interface ITransactionRepository
    {
        Task<Transaction> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetByStatusAsync(string status);
        Task CreateAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
    }

    public interface ITransactionService
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<Transaction> EditTransactionAsync(Guid id, Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetTransactionsByStatusAsync(string status);
    }
}
