using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;


namespace SCMWebApp.Pages
{
    public class BCSPageModel : PageModel
    {
        private SCMWebAppDatabaseContext _databaseContext;

        public BCSPageModel(SCMWebAppDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public Staff? BCS_Staff { get; set; } = new();

        [BindProperty]
        public Banner? Banner { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                var bcs_staff = _databaseContext.Staff
                    .Where(x => x.ProgrammeId == 2)
                    .Include(x=>x.Position)
                    .FirstOrDefault();

                BCS_Staff = bcs_staff;

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