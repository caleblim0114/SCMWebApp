using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCMWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace SCMWebApp.Pages
{
    public class BMDPageModel : PageModel
    {
        private SCMWebAppDatabaseContext _databaseContext;
        
        public BMDPageModel(SCMWebAppDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Staff BMDStaff { get; set; } = new();

        [BindProperty]
        public Banner Banner { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                var bmdStaff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 1)
                    .Include(x => x.Position)
                    .FirstOrDefault();

                BMDStaff = bmdStaff;

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
