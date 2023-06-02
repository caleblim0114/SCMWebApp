using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class AddStaffModel : PageModel
    {
        private readonly ILogger<AddStaffModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public AddStaffModel(ILogger<AddStaffModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _databaseContext = databaseContext;
            _logger = logger;
            _fileStorageService = fileStorageService;
        }

        [BindProperty]
        public Staff NewStaff { get; set; }

        [BindProperty]
        public IFormFile StaffImage { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var imageUrl = await _fileStorageService.CreateFileAsync("image", StaffImage.FileName, StaffImage.OpenReadStream(), StaffImage.ContentType);
            NewStaff.Image = imageUrl;
            _databaseContext.Add(NewStaff);
            await _databaseContext.SaveChangesAsync();
            return RedirectToPage("./Staff");
        }
    }
}
