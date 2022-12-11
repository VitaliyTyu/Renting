using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Items
{
    public class EditModel : CountryNamePageModel
    {
        private RentingDbContext _db;

        public EditModel(RentingDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _db.Items
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }

            CountryDropDownList(_db, Item.CountryId);
            return Page();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Item = await _db.Items.FirstOrDefaultAsync(x => x.Id == id);

            //if (Item == null)
            //{
            //    return NotFound();
            //}

            //return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == Item.Id);

                if (item == null)
                {
                    return NotFound();
                }

                item.Name = Item.Name;
                item.Type = Item.Type;
                item.RentPrice = Item.RentPrice;
                item.SizeRu = Item.SizeRu;
                item.Length = Item.Length;
                item.Width = Item.Width;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            CountryDropDownList(_db);
            return Page();
        }
    }
}