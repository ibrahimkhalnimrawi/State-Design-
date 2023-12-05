namespace State.Design.Pattern.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public OrderState State { get; set; } = null!;

    }
}
