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
    public IActionResult EventResponse(int id)
    {


        var EventToProcess = dbContext.EventTable
                                              .Where(e => e.id == id)
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
    public IActionResult EventInfo(EventsModel events)
    {

        EventSearchResultVM eventSearchResults = new EventSearchResultVM();
        var temp = User.Claims.Where(p => p.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        var tester = dbContext.EventTable.OrderBy(d => d.eventDate)
                     .Where(p => p.userID == temp && p.eventDate >= DateTime.Now);
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
        var temp = User.Claims.Where(p => p.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        events.userID = temp;
        dbContext.Add(events);
        dbContext.SaveChanges();

        return RedirectToAction("EventStatus");
    }

    public IActionResult EventStatus()
    {
        EventSearchResultVM eventSearchResults = new EventSearchResultVM();
        var temp = User.Claims.Where(p => p.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        var tester = dbContext.EventTable.OrderBy(d => d.eventDate)
                     .Where(p => p.userID == temp && p.eventDate >= DateTime.Now);
        if (tester.Count() > 0)
        {
            eventSearchResults.EventList = tester.ToList();
        }

        return View(eventSearchResults);

    }

    public IActionResult EditEvent(int id)
    {

        var record = dbContext.EventTable.Where(p => p.id == id).FirstOrDefault();

        return View(record);
    }

    [HttpPost]
    public IActionResult SaveEdit(EventsModel events)
    {
        var getEvent = dbContext.EventTable.OrderBy(d => d.eventDate).Where(p => p.id == events.id).FirstOrDefault(); 
        if (getEvent != null)
        {
            getEvent.eventDate = events.eventDate;
            getEvent.Name = events.Name;
            getEvent.eventTime = events.eventTime;
            getEvent.Location = events.Location;
            getEvent.Description = events.Description;

            dbContext.Update(getEvent);
            dbContext.SaveChanges();
        }
        

        return RedirectToAction("EventStatus");
    }

    public IActionResult DisplayEvent(int id)
    {
        var events = dbContext.EventTable.Where(p => p.id == id).FirstOrDefault();
        return View(events);
    }
}



