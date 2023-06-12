using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class RemoveStudentApplicationModel : PageModel
    {
        [BindProperty]
        public StudentApplication StudentApplication { get; set; } = new StudentApplication();

        [BindProperty]
        public StudentApplication NewStudentApplication { get; set; } = new();

        private readonly ILogger<RemoveStudentApplicationModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public RemoveStudentApplicationModel(ILogger<RemoveStudentApplicationModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _logger = logger;
            _databaseContext = databaseContext;
            _fileStorageService = fileStorageService;
        }

        public void OnGet(int id)
        {
            try
            {
                var studentApplication = _databaseContext.StudentApplication
                    .Where(b => b.Id == id)
                    .FirstOrDefault();

                StudentApplication = studentApplication;
                NewStudentApplication.Name = StudentApplication.Name;
                NewStudentApplication.PhoneNumber = StudentApplication.PhoneNumber;
                NewStudentApplication.Email = StudentApplication.Email;
                NewStudentApplication.ProgrammeId = StudentApplication.ProgrammeId;
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var studentDetails = _databaseContext.StudentApplication
                .Where(b => b.Id == StudentApplication.Id)
                .FirstOrDefault();

            if (studentDetails != null)
            {
                _databaseContext.StudentApplication.Remove(studentDetails);
                await _databaseContext.SaveChangesAsync();
                return RedirectToPage("./StudentApplication");
            }

            return Page();
        }
    }
}
