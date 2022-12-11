using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Items
{
    public class EditModel : PageModel
    {
        private RentingDbContext _db;

        public EditModel(RentingDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _db.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == Item.Id);

                item.Name = Item.Name;
                item.Type = Item.Type;
                item.RentPrice = Item.RentPrice;
                item.SizeRu = Item.SizeRu;
                item.Length = Item.Length;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}