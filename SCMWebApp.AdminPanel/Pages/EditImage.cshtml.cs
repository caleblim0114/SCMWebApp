using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SCMWebApp.AdminPanel.Pages
{
    public class EditImageModel : PageModel
    {
        [BindProperty]
        public Banner Banner { get; set; } = new Banner();

        private readonly ILogger<EditImageModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public EditImageModel(ILogger<EditImageModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
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
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var imgDetails = _databaseContext.Banner
                .Where(b => b.Id == Banner.Id)
                .FirstOrDefault();

            if (Image != null)
            {
                if (imgDetails != null)
                {
                    if (imgDetails.ImagePath != null)
                    {
                        await _fileStorageService.DeleteFileIfExistsAsync(imgDetails.ImagePath);
                    }

                    var newImage = await _fileStorageService.CreateFileAsync("image", Image.FileName, Image.OpenReadStream(), Image.ContentType);
                    imgDetails.ImagePath = newImage;
                }
            }

            imgDetails.Title = Banner.Title;
            imgDetails.Description = Banner.Description;
            imgDetails.BannerTypeId = Banner.BannerTypeId;
            await _databaseContext.SaveChangesAsync();
            return RedirectToPage("./Media");
        }
    }
}
