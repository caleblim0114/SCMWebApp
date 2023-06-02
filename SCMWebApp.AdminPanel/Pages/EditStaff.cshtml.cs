using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SCMWebApp.AdminPanel.Pages
{
    public class EditStaffModel : PageModel
    {
        private readonly ILogger<EditStaffModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public EditStaffModel(ILogger<EditStaffModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _databaseContext = databaseContext;
            _logger = logger;
            _fileStorageService = fileStorageService;
        }

        [BindProperty]
        public Staff Staff { get; set; }

        [BindProperty]
        public IFormFile? StaffImage { get; set; }

        public void OnGet(int id)
        {
            var staff = _databaseContext.Staff
                .Where(s => s.Id == id)
                .FirstOrDefault();

            Staff = staff;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var staff = _databaseContext.Staff
                .Where(s => s.Id == Staff.Id)
                .FirstOrDefault();

            if (StaffImage != null)
            {
                if (staff != null)
                {
                    if (staff.Image != null)
                    {
                        await _fileStorageService.DeleteFileIfExistsAsync(staff.Image);
                    }

                    var newImage = await _fileStorageService.CreateFileAsync("image", StaffImage.FileName, StaffImage.OpenReadStream(), StaffImage.ContentType);
                    staff.Image = newImage;
                }
            }

            staff.Name = Staff.Name;
            staff.PhoneNum = Staff.PhoneNum;
            staff.Email = Staff.Email;
            staff.PositionId = Staff.PositionId;
            staff.ProgrammeId = Staff.ProgrammeId;
            await _databaseContext.SaveChangesAsync();
            return RedirectToPage("./Staff");
        }
    }
}
