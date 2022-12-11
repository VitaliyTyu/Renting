using Lab9.App.DAL;
using Lab9.App.DAL.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Penalties
{
    public class PenaltiesPageModel : PageModel
    {
        public SelectList RentIdSL { get; set; }

        public void CountryDropDownList(RentingDbContext _context, object selectedvalue = null)
        {
            var query = _context.Countries.OrderBy(x => x.Name);

            RentIdSL = new SelectList(query.AsNoTracking(),
                        "Id", "Id", selectedvalue);
        }
    }
}