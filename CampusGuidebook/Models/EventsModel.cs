using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.Models
{
    public class EventsModel
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long userID { get; set; }

        [Required]
        public DateTime eventDate { get; set; }

        [Required]
        public TimeSpan eventTime { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public string ImgUri { get; set; } = string.Empty;

        
        public string Longitude { get; set; } = String.Empty;


        public string Latitude { get; set; } = String.Empty;

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public int UploadStatus { get; set; }

    }
}
