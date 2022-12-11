using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Penalties
{
    public class IndexModel : PageModel
    {
        private readonly RentingDbContext _db;

        public IndexModel(RentingDbContext db)
        {
            _db = db;
        }

        public List<Penalty> Penalties { get; set; }

        public async Task OnGet()
        {
            Penalties = await _db.Penalties
                .AsNoTracking()
                .Include(x => x.Rent)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _db.Penalties
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return NotFound();

            _db.Penalties.Remove(item);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}