using MongoDB.Driver;
using test.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.infraestructure
{
    public class MongoTransactionRepository : ITransactionRepository
    {
        private readonly IMongoCollection<Transaction> _transactions;

        public MongoTransactionRepository(IMongoClient client)
        {
            var database = client.GetDatabase("TransactionDb");
            _transactions = database.GetCollection<Transaction>("Transactions");
        }

        public async Task CreateAsync(Transaction transaction)
        {
            await _transactions.InsertOneAsync(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetByStatusAsync(string status)
        {
            return await _transactions.Find(t => t.Status == status).ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _transactions.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            await _transactions.ReplaceOneAsync(t => t.Id == transaction.Id, transaction);
        }
    }
}
