using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Banner> Banners { get; set; } = new List<Banner>();

        private readonly ILogger<IndexModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                var banner = _databaseContext.Banner
                    .Include(x => x.BannerType)
                    .ToList();

                Banners = banner;
            }
            catch (Exception ex)
            {

            }
        }
    }
}