using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;

        public IndexModel(ILogger<IndexModel> logger, SCMWebAppDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public List<Banner> Banners { get; set; } = new List<Banner>();

        [BindProperty]
        public Banner About_Banner { get; set; }

        [BindProperty]
        public Staff? BMD_Staff { get; set; } = new();

        [BindProperty]
        public Staff? BCS_Staff { get; set; } = new();

        [BindProperty]
        public Staff? BID_Staff { get; set; } = new();

        [BindProperty]
        public Staff? BDM_Staff { get; set; } = new();        
        
        [BindProperty]
        public Staff? SCM_Staff { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                var banner = _databaseContext.Banner
                    .Where(x => x.BannerTypeId == 1)
                    .ToList();

                Banners = banner;

                var bmd_staff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 1)
                    .FirstOrDefault();

                BMD_Staff = bmd_staff;

                var bcs_staff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 2)
                    .FirstOrDefault();

                BCS_Staff = bcs_staff;

                var bid_staff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 3)
                    .FirstOrDefault();

                BID_Staff = bid_staff;

                var bdm_staff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 4)
                    .FirstOrDefault();

                BDM_Staff = bdm_staff;                
                
                var scm_staff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 5)
                    .FirstOrDefault();

                SCM_Staff = scm_staff;

                var about_banner = _databaseContext.Banner
                    .Where(x => x.BannerTypeId == 4)
                    .FirstOrDefault();

                About_Banner = about_banner;

            }
            catch (Exception ex)
            {

            }
        }

    }
}