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
        //Merge all branches into 1 test branch and then have 'bogus' apply in the database so we can check to make sure it works
        //Done before midnight on tuesday

    }
}
