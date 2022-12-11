using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Penalties
{
    public class EditModel : PenaltiesPageModel
    {
        private RentingDbContext _db;

        public EditModel(RentingDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Penalty Penalty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Penalty = await _db.Penalties
                .Include(c => c.Rent)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Penalty == null)
                return NotFound();

            RentsDropDownList(_db, Penalty.RentId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var penalty = await _db.Penalties
                    .Include(x => x.Rent)
                    .FirstOrDefaultAsync(x => x.Id == Penalty.Id);

                if (penalty == null)
                    return NotFound();

                penalty.Type = Penalty.Type;
                penalty.Price = Penalty.Price;
                penalty.RentId = Penalty.RentId;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            RentsDropDownList(_db);
            return Page();
        }
    }
}
