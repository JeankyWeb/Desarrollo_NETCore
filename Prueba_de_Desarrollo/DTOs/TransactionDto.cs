namespace test.webapi.DTOs
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }

    public class CreateTransactionDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}