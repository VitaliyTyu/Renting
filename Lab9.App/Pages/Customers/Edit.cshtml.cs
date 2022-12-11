using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Customers
{
    public class EditModel : PageModel
    {
        private RentingDbContext _db;

        public EditModel(RentingDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (Customer == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == Customer.Id);
                customer.Name = Customer.Name;
                customer.Age = Customer.Age;
                customer.Height = Customer.Height;
                customer.Weight = Customer.Weight;
                customer.ShoeSizeRu = Customer.ShoeSizeRu;
                customer.ClothingSizeRu = Customer.ClothingSizeRu;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
