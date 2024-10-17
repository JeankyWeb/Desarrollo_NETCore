using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.domain;

namespace test.infraestructure.Interfaces
{
    public interface ITransactionRepository
    {
        Task CreateAsync(Transaction transaction);
        Task<Transaction> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetByStatusAsync(string status);
        Task UpdateAsync(Transaction transaction);
    }
}
