using CampusGuidebook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CampusGuidebook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public DbContext dbConext;

    public HomeController(ILogger<HomeController> logger, DbContext dbContext)
    {
        this.dbConext = dbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

