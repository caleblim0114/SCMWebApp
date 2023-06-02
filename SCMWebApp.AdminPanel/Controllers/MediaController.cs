using Microsoft.AspNetCore.Mvc;
using SCMWebApp.AdminPanel.Pages;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SCMWebApp.AdminPanel.Controllers
{
    public class MediaController : Controller
    {
        private SCMWebAppDatabaseContext _databaseContext;
        private IFileStorageService _fileStorageService;

        public MediaController(SCMWebAppDatabaseContext databaseContext, IFileStorageService fileStorageService)
        {
            _databaseContext = databaseContext;
            _fileStorageService = fileStorageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete("/MediaDetailsDelete")]
        public async Task<IActionResult> DeleteMediaDetails(int id)
        {
            var imgDetails = _databaseContext.Banner
                    .Where(b => b.Id == id)
                    .FirstOrDefault();

            if (imgDetails != null)
            {
                if (imgDetails.ImagePath != null)
                {
                    await _fileStorageService.DeleteFileIfExistsAsync(imgDetails.ImagePath);
                }

                _databaseContext.Banner.Remove(imgDetails);
                await _databaseContext.SaveChangesAsync();
                return Ok();
            }
               
            return BadRequest();
        }
    }
}
