
using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.Models
{
    public class EventsModel
    {
        [Key]
        [Required]
        public long id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string ImgUri { get; set; }

        [Required]
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        //[Required]
        //public TimeZoneInfo LastUpdated { get; set; }


        [Required]
        public int uploadStatus { get; set; }


    }
}
