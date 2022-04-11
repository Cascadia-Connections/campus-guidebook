using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.ViewModels
{
    public class EventSearchViewModel
    {
        [Required]
        public int UploadStatus { get; set; }
    }
}
