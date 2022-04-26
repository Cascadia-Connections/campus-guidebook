using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.Models
{
    public class RejectModel
    {
        [Key] [Required]
        public long id { get; set; }
        [Required]
        public string reason { get; set; }
    }
}
