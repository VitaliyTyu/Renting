namespace Lab9.App.DAL.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOnStock { get; set; }
        public int QuantityOnLease { get; set; }
        public string Type { get; set; }
        public decimal RentPrice { get; set; }
        public decimal CostIfBroken { get; set; }
        public double SizeRu { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<Rent> Rents { get; set; } = new List<Rent>();
    }
}