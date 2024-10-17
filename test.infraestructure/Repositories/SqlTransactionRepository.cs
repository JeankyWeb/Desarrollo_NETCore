using Microsoft.EntityFrameworkCore;
using test.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace;

namespace test.infraestructure
{
    public class SqlTransactionRepository : ITransactionRepository
    {
        private readonly YourDbContext _context;

        public SqlTransactionRepository(YourDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetByStatusAsync(string status)
        {
            return await _context.Transactions
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
