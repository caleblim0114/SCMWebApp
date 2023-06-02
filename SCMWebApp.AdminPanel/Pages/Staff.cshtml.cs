using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class StaffModel : PageModel
    {
        [BindProperty]
        public List<Staff> Staffs { get; set; } = new List<Staff>();

        private readonly ILogger<MediaModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public StaffModel(ILogger<MediaModel> logger, SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _logger = logger;
            _databaseContext = databaseContext;
            _fileStorageService = fileStorageService;
        }

        public void OnGet()
        {
            var staffList = _databaseContext.Staff
                .Include(x=>x.Position)
                .Include(x=>x.Programme)
                .ToList();

            Staffs = staffList;
        }
    }
}
