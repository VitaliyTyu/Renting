using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Penalties
{
    public class CreateModel : PenaltiesPageModel
    {
        private readonly RentingDbContext _db;

        [BindProperty]
        public Penalty Penalty { get; set; }

        public CreateModel(RentingDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            RentsDropDownList(_db);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await TryUpdateModelAsync<Penalty>(Penalty))
            {
                _db.Penalties.Add(Penalty);
                await _db.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            RentsDropDownList(_db);
            return Page();
        }
    }
}