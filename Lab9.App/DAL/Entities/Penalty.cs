using System.ComponentModel.DataAnnotations;

namespace Lab9.App.DAL.Entities
{
    public class Penalty
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string? Type { get; set; }
        [Range(0, 1000000)]
        public decimal? Price { get; set; }

        public int? RentId { get; set; }
        public Rent? Rent { get; set; }
    }
}