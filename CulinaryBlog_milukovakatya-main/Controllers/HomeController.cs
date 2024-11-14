using CulinaryBlog.Domain.ViewModels.LoginAndRegistration;
using CulinaryBlog_milukovakatya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaryBlog_milukovakatya.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult SiteInformation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(model);
            }  
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList();
            return BadRequest(errors);
        }
        [HttpPost]
        public IActionResult Register([FromBody] RegisterViewModel model) 
        { 
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList();
                return BadRequest(errors);
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
