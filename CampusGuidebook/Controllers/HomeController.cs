using CampusGuidebook.Data;
using CampusGuidebook.Models;
using CampusGuidebook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CampusGuidebook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public AppDbContext dbContext;

    public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
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
    /// <returns>EventResponse view to obtain user input. Passes a new EventViewModel object to obtain user data.</returns>
    [HttpGet]
    public IActionResult EventResponse()
    {
        EventsModel EventToProcess = dbContext.EventTable
                                              .Where(e => e.UploadStatus == 0)
                                              .FirstOrDefault();

        EventViewModel displayEvent = new EventViewModel()
        {
            id = EventToProcess.id,
            Name = EventToProcess.Name,
            Description = EventToProcess.Description,
            Location = EventToProcess.Location,
            ImgUri = EventToProcess.ImgUri,
            Longitude = EventToProcess.Longitude,
            Latitude = EventToProcess.Latitude,
            LastUpdated = EventToProcess.LastUpdated,
            UploadStatus = EventToProcess.UploadStatus

        };
        return EventResponse(displayEvent);
    }

    [HttpPost]
    public IActionResult EventResponse(EventViewModel EventViewModel)
    {
        if (!ModelState.IsValid)
        {

            return View(EventViewModel);

        }

        else
        {
            dbContext.EventTable.Find(EventViewModel.id).UploadStatus = EventViewModel.UploadStatus;

        }

        dbContext.SaveChanges();

        return EventResponse();
    }
}

