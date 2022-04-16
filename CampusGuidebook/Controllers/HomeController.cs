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
    /// Naming Subject to change based off of project team's work. Returns View for Admin user input with a new EventViewModel instance.
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
            UploadStatus = EventToProcess.UploadStatus //Should call it's own setter and resolve to an integer value 0 <= x <= 2, in this instance it should always resolve to 0; 

        };
        return EventResponse(displayEvent);
    }

    [HttpPost]
    public IActionResult EventResponse(EventViewModel EventViewModel)
    {


        dbContext.EventTable.Find(EventViewModel.id).UploadStatus = EventViewModel.UploadStatus;


        dbContext.SaveChanges();

        return EventResponse(); // Returns to next pending Event in DB that is actionable. 
    }


    [HttpGet]
    public IActionResult EventInfo()
    {
        //Plugging in some data to test view

        EventsModel Test = new EventsModel()
        {
            Name = "Test",
            Description = "Test",
            Location = "Test",
            Latitude = "Test",
            Longitude = "Test",
            ImgUri = "Test",
            LastUpdated = DateTime.Now,
            UploadStatus = 0

        };
        dbContext.Add(Test);
        dbContext.SaveChanges();
        //This can be removed for Bogus, but the code runs 

        EventSearchResultVM eventSearchResults = new EventSearchResultVM();
        eventSearchResults.EventList = dbContext.EventTable.Where(e => e.id >= 0);

        return View(eventSearchResults);
    }
}



