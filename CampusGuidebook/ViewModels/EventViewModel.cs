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

        /// <summary>
        /// UploadStatusString Is an enumeration that is passed from the view, passed to this viewmodel and processed here before setting the interger value to UploadStatus
        /// UploadStatusString DNE in the Model
        ///
        /// </summary>

        [Required]
        public UploadStatusEnum UploadStatusString { get; set; } = 0;

        [Required]
        public int UploadStatus
        {
            get { return UploadStatus; }
            set { StatusStringToInt(); }
        }


        /// Properties, instance variables, Enums above Here
        ///
        /// Methods and input processing below here(Unless through annotations)


        ///<summary>
        /// StatusStringToInt() ensures that the auto indexed INT Value of the above enumeration is passed to 
        /// Upload Value via its setter. 
        ///</summary>
        public void StatusStringToInt()
        {
            UploadStatus = (int)UploadStatusString;
        }

    }
}
