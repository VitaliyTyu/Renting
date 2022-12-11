using Lab9.App.DAL.Entities;

namespace Lab9.App.DAL
{
    public class RentingDbContextSeed
    {

        private static Random rnd = new Random();
        public static async Task InitializeDb(RentingDbContext db)
        {
            if (db.Items.Any())
                return;

            var countries = new List<Country>();

            for (int i = 0; i < 5; i++)
            {
                countries.Add(new Country { Name = $"country{i}", Items = GenerateItems()});
            }


            await db.Countries.AddRangeAsync(countries);

            await db.SaveChangesAsync();
        }

        private static List<Item> GenerateItems()
        {
            var items = new List<Item>();

            for (int i = 0; i < 10; i++)
            {
                int index = rnd.Next(1000);
                items.Add(new Item { Name = $"item_name{index}", Type = $"item_type{index}" });
            }
            return items;
        }
    }
}