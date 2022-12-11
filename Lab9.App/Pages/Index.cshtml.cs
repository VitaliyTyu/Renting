using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RentingDbContext _db;

        public IndexModel(RentingDbContext db)
        {
            _db = db;
        }

        public List<Rent> Rents { get; set; }

        public async Task OnGet()
        {
            Rents = await _db.Rents
                .AsNoTracking()
                .Include(x => x.Item)
                .Include(x => x.Customer)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            if (id == null)
                return NotFound();

            var rent = await _db.Rents
                .Include(x => x.Penalties)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rent == null)
                return NotFound();

            _db.Rents.Remove(rent);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}