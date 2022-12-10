using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public ItemViewModel Item { get; set; }

        public async Task OnGet(int id)
        {
            var item = await _db.Items.FindAsync(id);
            Item = item.MapToItemVM();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var item = await _db.Items.FindAsync(Item.Id);
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