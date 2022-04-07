using System.ComponentModel.DataAnnotations;


namespace CampusGuidebook.Models
{
    public class EventInfoModel
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }
        public string EventStatus { get; set; }

        public static List<EventInfoModel> eventModelHolder = new List<EventInfoModel>();

    }
}
