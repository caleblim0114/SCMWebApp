using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.Pages
{
    public class PostgraduatePageModel : PageModel
    {
        private readonly ILogger<PostgraduatePageModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;

        public PostgraduatePageModel(ILogger<PostgraduatePageModel> logger, SCMWebAppDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Staff SPSStaff { get; set; } = new();

        [BindProperty]
        public Banner CourseBanner { get; set; } = new();        
        
        [BindProperty]
        public Banner WebBanner { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                var spsStaff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 6)
                    .Include(x => x.Position)
                    .FirstOrDefault();
                if (spsStaff != null)
                {
                    SPSStaff = spsStaff;
                }
                var courseBanner = _databaseContext.Banner
                    .Where(x => x.BannerTypeId == 1)
                    .FirstOrDefault();

                CourseBanner = courseBanner;

                var webBanner = _databaseContext.Banner
                    .Where(x => x.BannerTypeId == 1)
                    .FirstOrDefault();

                WebBanner = webBanner;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
