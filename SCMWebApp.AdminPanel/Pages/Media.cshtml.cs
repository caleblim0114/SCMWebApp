using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SCMWebApp.AdminPanel.Services;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    public class MediaModel : PageModel
    {
        [BindProperty]
        public List<Banner> Banners { get; set; } = new List<Banner>();

        private readonly ILogger<MediaModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;

        public MediaModel(ILogger<MediaModel> logger, SCMWebAppDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public void OnGet()
        {
            try
            {
                var banner = _databaseContext.Banner
                    .Include(x => x.BannerType)
                    .ToList();

                Banners = banner;
            }
            catch (Exception ex)
            {

            }
        }

        //public async Task<RedirectToPageResult> DeleteMedia(int id)
        //{
        //    var imgDetails = _databaseContext.Banner
        //        .Where(x => x.Id == id)
        //        .FirstOrDefault();

        //    if (imgDetails != null)
        //    {
        //        if (imgDetails.ImagePath != null)
        //        {
        //            await _fileStorageService.DeleteFileIfExistsAsync(imgDetails.ImagePath);
        //        }
        //        _databaseContext.Banner.Remove(imgDetails);
        //        await _databaseContext.SaveChangesAsync();
        //        return RedirectToPage("./Media");
        //    }
        //    return RedirectToPage("./Media");
        //}
    }
}
