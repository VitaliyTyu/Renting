namespace Lab9.App.DAL.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset ExpectedEndDate { get; set; }
        public DateTimeOffset ActualEndDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public List<Penalty> Penalties { get; set; } = new List<Penalty>();

    }
}