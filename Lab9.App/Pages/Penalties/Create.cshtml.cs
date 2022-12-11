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
        public Item Item { get; set; }

        public CreateModel(RentingDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            CountryDropDownList(_db);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await TryUpdateModelAsync<Item>(Item))
            {
                _db.Items.Add(Item);
                await _db.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            CountryDropDownList(_db);
            return Page();
        }
    }
}