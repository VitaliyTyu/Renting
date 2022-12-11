using System.ComponentModel.DataAnnotations;

namespace Lab9.App.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [StringLength(60), Required]
        public string? Name { get; set; }
        [Range(0, 10)]
        public int? ApprovalRating { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}