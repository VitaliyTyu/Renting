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

        public List<Item> Items { get; set; }

        public async Task OnGet()
        {
            Items = await _db.Items
                .AsNoTracking()
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return NotFound();

            _db.Items.Remove(item);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}