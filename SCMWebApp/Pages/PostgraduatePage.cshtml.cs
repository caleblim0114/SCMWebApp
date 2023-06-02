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
            }
            catch (Exception ex)
            {

            }
        }
    }
}
