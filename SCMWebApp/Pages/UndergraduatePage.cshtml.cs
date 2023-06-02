using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.Pages
{
    public class UndergraduatePageModel : PageModel
    {
        private readonly ILogger<UndergraduatePageModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;

        public UndergraduatePageModel(ILogger<UndergraduatePageModel> logger, SCMWebAppDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Staff SCM_Staff { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                var scm_staff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 5)
                    .Include(x => x.Position)
                    .FirstOrDefault();
                if (scm_staff != null)
                {
                    SCM_Staff = scm_staff;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
