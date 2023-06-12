using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.Pages
{
    public class BDMPageModel : PageModel
    {
        private SCMWebAppDatabaseContext _databaseContext;

        public BDMPageModel(SCMWebAppDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Staff BDMStaff { get; set; } = new();

        [BindProperty]
        public Banner Banner { get; set; } = new();

        public async void OnGet()
        {
            var bdmStaff = _databaseContext.Staff
                .Where(x=>x.ProgrammeId == 4)
                .Include(x=>x.Position)
                .FirstOrDefault();

            BDMStaff = bdmStaff;

            var banner = _databaseContext.Banner
                .Where(x => x.BannerTypeId == 1)
                .FirstOrDefault();

            Banner = banner;
        }
    }
}
