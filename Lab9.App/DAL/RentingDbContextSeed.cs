using Lab9.App.DAL.Entities;

namespace Lab9.App.DAL
{
    public class RentingDbContextSeed
    {
        public static async Task InitializeDb(RentingDbContext db)
        {
            if (db.Items.Any())
                return;

            var country1 = new Country() { Name = "�����" };
            var country2 = new Country() { Name = "������" };
            var country3 = new Country() { Name = "��������" };
            await db.Countries.AddRangeAsync(country1, country2, country3);
            await db.SaveChangesAsync();


            var item1 = new Item() { Name = "����", RentPrice = 100.00m, Length = 150, Country = country1 };
            var item2 = new Item() { Name = "�����", RentPrice = 75.00m, Length = 100, Country = country2 };
            var item3 = new Item() { Name = "�������", RentPrice = 10.00m, Country = country2 };
            var item4 = new Item() { Name = "����", RentPrice = 10.00m, Length = 2000, Country = country3 };
            await db.Items.AddRangeAsync(item1, item2, item3, item4);
            await db.SaveChangesAsync();

            await db.SaveChangesAsync();
        }
    }
}