using Lab9.App.DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages
{
    public class RentsPageModel : PageModel
    {
        public SelectList ItemNameSL { get; set; }
        public SelectList CustomerNameSL { get; set; }

        public void ItemDropDownList(RentingDbContext _context, object selectedValue = null)
        {
            var query = _context.Items.OrderBy(x => x.Name);

            ItemNameSL = new SelectList(query.AsNoTracking(),
                        "Id", "Name", selectedValue);
        }

        public void CustomerDropDownList(RentingDbContext _context, object selectedValue = null)
        {
            var query = _context.Customers.OrderBy(x => x.Name);

            CustomerNameSL = new SelectList(query.AsNoTracking(),
                        "Id", "Name", selectedValue);
        }
    }
}