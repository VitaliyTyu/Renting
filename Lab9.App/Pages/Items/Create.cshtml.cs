using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Items
{
    public class CreateModel : CountryNamePageModel
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
            if (ModelState.IsValid)
            {
                await _db.Items.AddAsync(Item);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                CountryDropDownList(_db);
                return Page();
            }
        }
    }
}