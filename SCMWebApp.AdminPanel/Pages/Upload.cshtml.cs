using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class UploadModel : PageModel
    {
        private readonly ILogger<UploadModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public UploadModel (ILogger<UploadModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _databaseContext = databaseContext;
            _logger = logger;
            _fileStorageService = fileStorageService;
        }

        [BindProperty]
        public Banner ImageType { get; set; }

        [BindProperty]
        public  IFormFile Image { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var imageUrl = await _fileStorageService.CreateFileAsync("image", Image.FileName, Image.OpenReadStream(), Image.ContentType);
            ImageType.ImagePath = imageUrl;
            _databaseContext.Add(ImageType);
            await _databaseContext.SaveChangesAsync();
            return RedirectToPage("./Upload");
        }
    }
}
