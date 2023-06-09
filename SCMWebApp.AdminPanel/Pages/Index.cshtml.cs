﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SCMWebApp.Shared.Models;

namespace SCMWebApp.AdminPanel.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Banner> Banners { get; set; } = new List<Banner>();

        private readonly ILogger<IndexModel> _logger;
        private SCMWebAppDatabaseContext _databaseContext;

        public IndexModel(ILogger<IndexModel> logger, SCMWebAppDatabaseContext databaseContext)
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
    }
}