using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;


namespace SCMWebApp.Pages
{
    public class BCSPageModel : PageModel
    {
        private readonly ILogger<BCSPageModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;

        public BCSPageModel(ILogger<BCSPageModel> logger, SCMWebAppDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Staff? BMD_Staff { get; set; } = new();

        [BindProperty]
        public Staff? BCS_Staff { get; set; } = new();

        [BindProperty]
        public Staff? BDM_Staff { get; set; } = new();

        [BindProperty]
        public Staff? BID_Staff { get; set; } = new();

        public async void OnGet()
        {
            try
            {
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
            }
            catch (Exception ex)
            {

            }
        }
    }
}
