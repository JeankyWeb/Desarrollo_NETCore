using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.domain;

namespace test.application
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            // Validaciones
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction), "La transacción no puede ser nula.");
            if (transaction.Amount <= 0)
                throw new ArgumentException("El monto debe ser mayor que cero.", nameof(transaction.Amount));
            if (string.IsNullOrWhiteSpace(transaction.Currency))
                throw new ArgumentException("La moneda no puede estar vacía.", nameof(transaction.Currency));
            if (string.IsNullOrWhiteSpace(transaction.Status))
                throw new ArgumentException("El estado no puede estar vacío.", nameof(transaction.Status));

            transaction.Id = Guid.NewGuid(); // Genera un nuevo ID
            await _transactionRepository.CreateAsync(transaction);
            return transaction;
        }

        public async Task<Transaction> EditTransactionAsync(Guid id, Transaction transaction)
        {
            // Validaciones
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction), "La transacción no puede ser nula.");
            if (transaction.Amount <= 0)
                throw new ArgumentException("El monto debe ser mayor que cero.", nameof(transaction.Amount));
            if (string.IsNullOrWhiteSpace(transaction.Currency))
                throw new ArgumentException("La moneda no puede estar vacía.", nameof(transaction.Currency));
            if (string.IsNullOrWhiteSpace(transaction.Status))
                throw new ArgumentException("El estado no puede estar vacío.", nameof(transaction.Status));

            transaction.Id = id; // Asegura que el ID sea el correcto
            await _transactionRepository.UpdateAsync(transaction);
            return transaction;
        }

        public async Task<Transaction> GetTransactionByIdAsync(Guid id)
        {
            return await _transactionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByStatusAsync(string status)
        {
            return await _transactionRepository.GetByStatusAsync(status);
        }
    }
}
