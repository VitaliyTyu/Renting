using System.ComponentModel.DataAnnotations;

namespace Lab9.App.DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(60), Required]
        public string Name { get; set; }
        [Range(0, 150)]
        public int? Age { get; set; }
        [Range(0, 250)]
        public int? Height { get; set; }
        [Range(0, 500)]
        public int? Weight { get; set; }
        [Range(0, 100)]
        public double? ShoeSizeRu { get; set; }
        [Range(0, 100)]
        public double? ClothingSizeRu { get; set; }

        public List<Rent> Rents { get; set; } = new List<Rent>();
    }
}