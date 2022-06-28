
using JuliePro_DataAccess.Data;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;

        //private readonly IStringLocalizer<SharedResource> _sharedResource;

        private readonly JulieProDbContext _db;

        public HomeController(ILogger<HomeController>
          logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = this._localizer["HomeIndexTitle"];
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Title = _localizer["PrivacyTitle"];
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var cookie = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
            var name = CookieRequestCultureProvider.DefaultCookieName;

            Response.Cookies.Append(name, cookie, new CookieOptions
            {
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddYears(1),
            }) ;
            return LocalRedirect(returnUrl);

        }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

    }
}
