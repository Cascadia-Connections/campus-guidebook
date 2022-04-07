using System.ComponentModel.DataAnnotations;

namespace CampusGuidebook.ViewModels
{
    public class EventViewModel
    {
        /// <summary>
        /// Enumeration for adminstrator Event Decision input. 
        /// </summary>
        public enum UploadStatusEnum
        {
            Pending,     // 0
            Accepted,    // 1
            Denied       // 2
        }

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
        public UploadStatusEnum UploadStatusString { get; set; }

        [Required]
        public int UploadStatus
        {
            get { return UploadStatus; }
            set { StatusStringToInt(); }
        }

        ///<summary>
        ///Properties, instance variables, Enums above Here
        ///
        /// Methods and input processing below here (Unless through annotations)
        ///</summary>

        /// Although enumerations are auto indexed, properties may not be automatically assigned to each other in their declaration fields.
        /// The purpose of this method is simply to assign the auto generated integer Enum value to to exisitng UploadStatus int property.
        /// 
        public void StatusStringToInt()
        {
            UploadStatus = (int)UploadStatusString;
        }

    }
}
