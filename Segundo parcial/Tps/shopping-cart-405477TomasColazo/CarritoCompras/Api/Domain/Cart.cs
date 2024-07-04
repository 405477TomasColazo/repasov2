namespace Api.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
