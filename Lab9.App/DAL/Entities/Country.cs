namespace Lab9.App.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApprovalRating { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}