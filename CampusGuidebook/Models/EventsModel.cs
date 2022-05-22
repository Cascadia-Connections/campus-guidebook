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

        [Required]
        public String Latitude { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public int UploadStatus { get; set; }
        [Required]
        public String TypeOfEvent { get; set; }
        [Required(ErrorMessage = "Please enter a reason")]
        public int RejectReason { get; set; }


    }
}
