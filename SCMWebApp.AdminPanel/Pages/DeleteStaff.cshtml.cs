using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class DeleteStaffModel : PageModel
    {
        [BindProperty]
        public Staff Staff { get; set; } = new Staff();

        [BindProperty]
        public Staff NewStaff { get; set; } = new();

        private readonly ILogger<DeleteStaffModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public DeleteStaffModel(ILogger<DeleteStaffModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
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
                var staff = _databaseContext.Staff
                    .Where(b => b.Id == id)
                    .FirstOrDefault();

                Staff = staff;
                NewStaff.Name = Staff.Name;
                NewStaff.PhoneNum = Staff.PhoneNum;
                NewStaff.Email = Staff.Email;
                NewStaff.PositionId = Staff.PositionId;
                NewStaff.ProgrammeId = Staff.ProgrammeId;
                NewStaff.Image = Staff.Image;
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var staffDetails = _databaseContext.Staff
                .Where(b => b.Id == Staff.Id)
                .FirstOrDefault();

            if (staffDetails != null)
            {
                if (staffDetails.Image != null)
                {
                    await _fileStorageService.DeleteFileIfExistsAsync(staffDetails.Image);
                }

                _databaseContext.Staff.Remove(staffDetails);
                await _databaseContext.SaveChangesAsync();
                return RedirectToPage("./Staff");
            }

            return Page();
        }
    }
}
