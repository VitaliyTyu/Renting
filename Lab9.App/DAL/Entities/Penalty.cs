namespace Lab9.App.DAL.Entities
{
    public class Penalty
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public int RentId { get; set; }
        public Rent Rent { get; set; }
    }
}