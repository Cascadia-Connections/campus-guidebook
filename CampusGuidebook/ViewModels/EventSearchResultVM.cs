using CampusGuidebook.Models;

namespace CampusGuidebook.ViewModels
{
    public class EventSearchResultVM
    {
        public IQueryable<EventsModel> EventList { get; set; }

    }
}
