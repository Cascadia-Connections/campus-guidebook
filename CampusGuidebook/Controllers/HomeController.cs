using CampusGuidebook.Data;
using CampusGuidebook.Models;
using CampusGuidebook.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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


        var EventToProcess = dbContext.EventTable
                                              .Where(e => e.UploadStatus == 0)
                                              .FirstOrDefault();

        if (EventToProcess == null)
        {
            return RedirectToAction("NoPendingEvents");
        }

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
            UploadStatus = EventToProcess.UploadStatus,

        };

        return View(displayEvent);
    }

    [HttpPost]
    public IActionResult EventResponse(EventViewModel DecisionToPost)
    {
        EventsModel UploadToDB = new()
        {
            id = DecisionToPost.id,
            Name = DecisionToPost.Name,
            Description = DecisionToPost.Description,
            Location = DecisionToPost.Location,
            ImgUri = DecisionToPost.ImgUri,
            Latitude = DecisionToPost.Latitude,
            Longitude = DecisionToPost.Longitude,
            LastUpdated = DecisionToPost.LastUpdated,
            UploadStatus = DecisionToPost.UploadStatus
        };

        dbContext.Update(UploadToDB);
        dbContext.SaveChanges();


        return RedirectToAction("EventResponse"); // Returns to next pending Event in DB that is actionable. 
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult EventInfo()
    {
        //Plugging in some data to test view



        //dbContext.SaveChanges();
        //This can be removed for Bogus, but the code runs 

        EventSearchResultVM eventSearchResults = new EventSearchResultVM();
        var tester = dbContext.EventTable;
        if (tester.Count() > 0) 
        {
            eventSearchResults.EventList = tester.ToList();
        }

        return View(eventSearchResults);
    }

    public IActionResult NoPendingEvents()
    {
        return View();
    }

    public IActionResult EventApplication()
    {
        return View(new EventsModel());
    }
    
    [HttpPost]
    public IActionResult AppliedEvent(EventsModel events)
    { 
        //events.userID
        dbContext.Add(events);
        dbContext.SaveChanges();

        return RedirectToAction("EventStatus");
    }

    public IActionResult EventStatus()
    {
        EventSearchResultVM eventSearchResults = new EventSearchResultVM();
        var tester = dbContext.EventTable;
        if (tester.Count() > 0)
        {
            eventSearchResults.EventList = tester.ToList();
        }

        return View(eventSearchResults);

    }
}



