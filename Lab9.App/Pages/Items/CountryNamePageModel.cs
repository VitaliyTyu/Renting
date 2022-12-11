using Lab9.App.DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab9.App.Pages.Items
{
    public class CountryNamePageModel : PageModel
    {
        public SelectList CountryNameSL { get; set; }

        public void CountryDropDownList(RentingDbContext _context, object selectedCountry = null)
        {
            var countriesQuery = from d in _context.Countries
                                 orderby d.Name
                                 select d;

            CountryNameSL = new SelectList(countriesQuery.AsNoTracking(),
                        "Id", "Name", selectedCountry);
        }
    }
}