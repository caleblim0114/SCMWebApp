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

        public async void OnGet()
        {
            try
            {
                var banner =  _databaseContext.Banner
                    .Where(x=>x.BannerTypeId == 1)
                    .ToList();

                Banners = banner;
            }
            catch (Exception ex)
            {

            }
        }

    }
}