using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;
using SCMWebAppDatabaseContext = SCMWebApp.Shared.Models.SCMWebAppDatabaseContext;

namespace SCMWebApp.AdminPanel.Pages
{
    public class DeleteImageModel : PageModel
    {
        [BindProperty]
        public Banner Banner { get; set; } = new Banner();

        [BindProperty]
        public Banner NewBanner { get; set; } = new();

        private readonly ILogger<DeleteImageModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public DeleteImageModel(ILogger<DeleteImageModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _logger = logger;
            _databaseContext = databaseContext;
            _fileStorageService = fileStorageService;
        }

        [BindProperty]
        public IFormFile Image { get; set; }

        public void OnGet(int id)
        {
            try
            {
                var banner = _databaseContext.Banner
                    .Where(b => b.Id == id)
                    .FirstOrDefault();

                Banner = banner;
                NewBanner.Title = Banner.Title;
                NewBanner.Description = Banner.Description;
                NewBanner.BannerTypeId = 3;
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var imgDetails = _databaseContext.Banner
                .Where(b => b.Id == Banner.Id)
                .FirstOrDefault();

            if (imgDetails != null)
            {
                if (imgDetails.ImagePath != null)
                {
                    await _fileStorageService.DeleteFileIfExistsAsync(imgDetails.ImagePath);
                }

                _databaseContext.Banner.Remove(imgDetails);
                await _databaseContext.SaveChangesAsync();
                return RedirectToPage("./Media");
            }

            return Page();
        }
    }
}
