using System.ComponentModel.DataAnnotations;


namespace CampusGuidebook.Models
{
    public class ClubModel
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public string ClubName { get; set; }
    }
}
