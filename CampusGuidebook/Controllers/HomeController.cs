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
    public IActionResult EventResponse()// todo: add rejection list for dropdown
    {

        EventsModel EventToProcess = dbContext.EventTable
                                              .Where(e => e.UploadStatus == 0)
                                              .FirstOrDefault();
        ClubModel ClubToProcess = dbContext.ClubTable.Where(e => e.Id.Equals(EventToProcess.id)).FirstOrDefault();

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
            LastUpdated = EventToProcess.LastUpdated,
            UploadStatus = EventToProcess.UploadStatus,
            ClubName = ClubToProcess.ClubName, //dummy
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
            LastUpdated = DecisionToPost.LastUpdated,
            UploadStatus = DecisionToPost.UploadStatus
        };

        dbContext.Update(UploadToDB);
        dbContext.SaveChanges();


        return RedirectToAction("EventResponse"); // Returns to next pending Event in DB that is actionable. 
    }



    [HttpGet]
    public IActionResult EventInfo()
    {

        //-------------- Populate database --------------------- todo: make it populate once instaid of every time
        List<EventsModel> EventSeedList = new List<EventsModel>();
        List<RejectModel> rejectSeedList = new List<RejectModel>();
        List<ClubModel> ClubSeedList = new List<ClubModel>();
        EventsModel Event = new EventsModel();
        RejectModel Reject = new RejectModel();
        ClubModel Club = new ClubModel();
        for (int i = 0; i < 15; i++)
        {
            Event = new SeedData().testEventsDB.Generate();
            EventSeedList.Add(Event);
            Reject = new SeedData().testReasonsDB.Generate();
            rejectSeedList.Add(Reject);
            Club = new SeedData().testClubDB.Generate();
            ClubSeedList.Add(Club);
        }
        dbContext.EventTable.AddRange(EventSeedList);
        dbContext.RejectTable.AddRange(rejectSeedList);
        dbContext.ClubTable.AddRange(ClubSeedList);
        dbContext.SaveChanges();
        //-------------------------------------------------------

        EventSearchResultVM eventSearchResults = new EventSearchResultVM();
        eventSearchResults.EventList = dbContext.EventTable.Where(e => e.id >= 0);

        return View(eventSearchResults);
    }

    public IActionResult NoPendingEvents() {
        return View();
    }

    public IActionResult OpenReason(EventViewModel hi) {// Redisplays the view with text boxes for reasons
        hi.ShowReject = true;
        return View(hi);
    }
    public IActionResult CloseReason(EventViewModel hello) { // closes the text box
        hello.ShowReject = true;
        return View(hello);
    }

    [HttpPost]
    public IActionResult storeRejectReason(string reason, EventsModel _event) { //stores rejection reason with event relations
        return View();
        RejectModel Passin = new RejectModel();
        Passin.reason = reason;
        _event.reasonid = reason.id;

        
        dbContext.RejectTable.Add(Passin);
        dbContext.SaveChanges();
    }
}