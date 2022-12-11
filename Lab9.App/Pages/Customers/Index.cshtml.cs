using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly RentingDbContext _db;

        public IndexModel(RentingDbContext db)
        {
            _db = db;
        }

        public List<Customer> Customers { get; set; }

        public async Task OnGet()
        {
            Customers = await _db.Customers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _db.Customers
                .Include(x => x.Rents)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
                return NotFound();

            _db.Customers.Remove(customer);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}