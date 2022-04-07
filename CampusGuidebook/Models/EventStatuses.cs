using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.Models
{
    public class EventStatuses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string status { get; set; }
    }
}
