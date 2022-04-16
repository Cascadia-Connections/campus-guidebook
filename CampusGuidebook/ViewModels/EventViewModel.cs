using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.ViewModels
{
    public class EventViewModel
    {


        [Required]
        public long id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string ImgUri { get; set; } = string.Empty;

        [Required]
        public String Longitude { get; set; } = String.Empty;

        [Required]
        public String Latitude { get; set; } = String.Empty;

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public int UploadStatus { get; set; } = 0;

    }
}
