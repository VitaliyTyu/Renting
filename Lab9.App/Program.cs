using Lab9.App.DAL;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<RentingDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var db = serviceProvider.GetRequiredService<RentingDbContext>();

    await db.Database.EnsureCreatedAsync();

    await RentingDbContextSeed.InitializeDb(db);
}

app.Run();
