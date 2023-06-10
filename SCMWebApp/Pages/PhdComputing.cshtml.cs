using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.Pages
{
    public class PhdComputingModel : PageModel
    {
        public SCMWebAppDatabaseContext _databaseContext;

        public PhdComputingModel(SCMWebAppDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [BindProperty]
        public Staff? Profile { get; set; } = new();

        [BindProperty]
        public Banner? Banner { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                var profile = _databaseContext.Staff
                    .Where(x => x.PositionId == 5)
                    .FirstOrDefault();

                Profile = profile;

                var banner = _databaseContext.Banner
                    .Where(x => x.BannerTypeId == 1)
                    .FirstOrDefault();

                Banner = banner;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
