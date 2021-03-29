using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpeningTheSaw.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SharpeningTheSaw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private RecipesContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, RecipesContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        public IActionResult Index()
        {
            return View(_context.Recipes
                .FromSqlInterpolated($"SELECT * FROM Recipes ORDER BY RecipeTitle DESC")
                .ToList());
        }

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
