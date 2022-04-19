using Bogus;

namespace CampusGuidebook.Models
{
    public class SeedData
    {

        public Faker<EventsModel> testEventsDB = new Faker<EventsModel>()
              .RuleFor(em => em.id, f => f.IndexFaker)
              .RuleFor(em => em.Name, f => f.Name.JobArea())
              .RuleFor(em => em.Description, f => f.Lorem.Paragraph())
              .RuleFor(em => em.Location, f => f.Address.State())
              .RuleFor(em => em.ImgUri, f => f.Internet.Url())
              .RuleFor(em => em.Longitude, f => f.Rant.Review())
              .RuleFor(em => em.Latitude, f => f.Rant.Review())
              .RuleFor(em => em.LastUpdated, f => f.Date.Past())
              .RuleFor(em => em.UploadStatus, f => f.Random.Int(0, 2));



    }
}
