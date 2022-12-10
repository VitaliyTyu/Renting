using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab9.App.Pages.Countries
{
    public class EditModel : PageModel
    {
        private RentingDbContext _db;

        public EditModel(RentingDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Country Country { get; set; }

        public async Task OnGet(int id)
        {
            Country = await _db.Countries.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var country = await _db.Countries.FindAsync(Country.Id);
                country.Name = Country.Name;
                country.ApprovalRating = Country.ApprovalRating;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}