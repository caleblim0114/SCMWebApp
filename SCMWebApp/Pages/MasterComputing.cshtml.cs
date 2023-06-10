using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.Pages
{
    public class MasterComputingModel : PageModel
    {
        private SCMWebAppDatabaseContext _databaseContext;

        public MasterComputingModel(SCMWebAppDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Banner? Banner { get; set; } = new();

        [BindProperty]
        public Staff Profile { get; set; } = new();
        
        public async void OnGet()
        {
            try
            {
                var banner = _databaseContext.Banner
                    .Where(x => x.BannerTypeId == 1)
                    .FirstOrDefault();

                Banner = banner;

                var profile = _databaseContext.Staff
                    .Where(x => x.PositionId == 5)
                    .FirstOrDefault();

                Profile = profile;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
