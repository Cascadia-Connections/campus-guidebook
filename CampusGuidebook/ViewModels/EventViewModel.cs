namespace CampusGuidebook.ViewModels
{
    public class EventViewModel
    {

        public enum UploadStatusEnum
        {
            Pending,
            Accepted,
            Denied
        }


        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string ImgUri { get; set; }

        public String Longitude { get; set; }

        public String Latitude { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public UploadStatusEnum UploadStatusString { get; set; }

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


        public void StatusStringToInt()
        {
            UploadStatus = (int)UploadStatusString;
        }
    }
}
