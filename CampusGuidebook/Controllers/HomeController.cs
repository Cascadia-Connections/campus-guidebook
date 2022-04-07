using CampusGuidebook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CampusGuidebook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public DbContext dbContext;

    public HomeController(ILogger<HomeController> logger, DbContext dbContext)
    {
        this.dbContext = dbContext;
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
    /// <summary>
    /// Naming Subject to change based off of project team's work. Returns View for Admin user input with a new EventModel instance.
    /// 
    /// </summary>
    /// <returns>[HttpPost] EventResponse(new EventViewModel)</returns>
    [HttpGet]
    public IActionResult EventResponse()
    {
        return EventResponse(new EventViewModel());
    }

    [HttpPost]
    public IActionResult EventResponse(EventViewModel EventViewModel)
    {
        return EventResponse();
    }
}

