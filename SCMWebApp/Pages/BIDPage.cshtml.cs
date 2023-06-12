using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.Pages
{
    public class BIDPageModel : PageModel
    {
        private SCMWebAppDatabaseContext _databaseContext;

        public BIDPageModel(SCMWebAppDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Staff BIDStaff { get; set; } = new();

        [BindProperty]
        public Banner Banner { get; set; } = new();

        public async void OnGet()
        {
            var bidStaff = _databaseContext.Staff
                .Where(x => x.ProgrammeId == 3)
                .Include(x => x.Position)
                .FirstOrDefault();

            BIDStaff = bidStaff;

            var banner = _databaseContext.Banner
                .Where(x => x.BannerTypeId == 1)
                .FirstOrDefault();

            Banner = banner;
        }
    }
}
