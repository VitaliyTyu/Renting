using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly RentingDbContext _db;

        public IndexModel(RentingDbContext db)
        {
            _db = db;
        }

        public List<Country> Countries { get; set; }

        public async Task OnGet()
        {
            Countries = await _db.Countries.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var country = await _db.Countries.FindAsync(id);

            if (country == null)
                return NotFound();

            _db.Countries.Remove(country);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}