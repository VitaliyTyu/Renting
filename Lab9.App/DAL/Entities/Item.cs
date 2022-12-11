using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab9.App.DAL.Entities
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(60)]
        [Required]
        public string Name { get; set; }
        [StringLength(60)]
        public string? Type { get; set; }
        [Range(0, 1000000)]
        public decimal? RentPrice { get; set; }
        [Range(0, 100)]
        public double? SizeRu { get; set; }
        [Range(0, 10000)]
        public double? Length { get; set; }
        [Range(0, 10000)]
        public double? Width { get; set; }


        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public List<Rent> Rents { get; set; } = new List<Rent>();
    }
}