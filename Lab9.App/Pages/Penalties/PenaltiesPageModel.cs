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

        public void RentsDropDownList(RentingDbContext _context, object selectedvalue = null)
        {
            var query = _context.Rents.OrderBy(x => x.Id);

            RentIdSL = new SelectList(query.AsNoTracking(),
                        "Id", "Id", selectedvalue);
        }
    }
}