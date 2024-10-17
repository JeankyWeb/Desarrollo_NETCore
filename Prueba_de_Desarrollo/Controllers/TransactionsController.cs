using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.application;
using test.domain;     
using test.webapi.DTOs;

namespace test.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protege todos los endpoints en este controlador
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto dto)
        {
            // Validar el DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crear una nueva instancia de Transaction
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(), // Generar un nuevo GUID
                Amount = dto.Amount,
                Currency = dto.Currency,
                Date = dto.Date,
                Status = dto.Status
            };

            // Llamar al servicio para guardar la transacción
            await _transactionService.CreateTransactionAsync(transaction);

            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TransactionDto>> UpdateTransaction(Guid id, CreateTransactionDto dto)
        {
            var transaction = new Transaction
            {
                Id = id,
                Amount = dto.Amount,
                Currency = dto.Currency,
                Status = dto.Status,
                Date = DateTime.UtcNow
            };

            var updatedTransaction = await _transactionService.EditTransactionAsync(id, transaction);
            return Ok(updatedTransaction);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransactionById(Guid id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactionsByStatus(string status)
        {
            var transactions = await _transactionService.GetTransactionsByStatusAsync(status);
            return Ok(transactions);
        }
    }
}
