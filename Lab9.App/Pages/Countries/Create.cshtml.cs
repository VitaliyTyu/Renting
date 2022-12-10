using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab9.App.Pages.Countries
{
    public class CreateModel : PageModel
    {
        private readonly RentingDbContext _db;

        public CreateModel(RentingDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Country Country { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Countries.AddAsync(Country);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}