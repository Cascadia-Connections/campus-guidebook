using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CampusGuidebook.ViewModels;
using CampusGuidebook.Data;
using CampusGuidebook.Models;

namespace CampusGuidebook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EventInfoDBContext _context;
    private readonly EventInfoFactory _eventInfoFactory;

    public HomeController(ILogger<HomeController> logger, EventInfoDBContext context, EventInfoFactory eventInfoFactory)
    {
        _logger = logger;
        _context = context;
        _eventInfoFactory = eventInfoFactory;
        
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
     public IActionResult EventInfo()
    {
        _eventInfoFactory.eventInfoModels = _context.EventInfo.ToList();
        return View(_eventInfoFactory);
    }
}

