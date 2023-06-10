using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class StudentApplicationModel : PageModel
    {
        [BindProperty]
        public List<StudentApplication> Students { get; set; } = new List<StudentApplication>();

        private readonly ILogger<StudentApplicationModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public StudentApplicationModel(ILogger<StudentApplicationModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _logger = logger;
            _databaseContext = databaseContext;
            _fileStorageService = fileStorageService;
        }

        public void OnGet()
        {
            var studentList = _databaseContext.StudentApplication
                .Where(x=>x.Email!=null)
                .Include(x=>x.Programme)
                .ToList();

            Students = studentList;
        }
    }
}
