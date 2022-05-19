using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.Models
{
    public class EventConditions
    {
        [Key]
        public long id { get; set; }
        public string condition { get; set; }
    }
}
