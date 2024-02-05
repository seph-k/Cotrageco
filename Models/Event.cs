namespace Cotrageco.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string Event_Title { get; set; }
        public string Event_Description { get; set; }
        public DateTime Event_Date { get; set; }
        public TimeSpan Event_Time { get; set; }
        public string? Event_Image { get; set; }

        //public string Event_Link { get; set; }
        
    }
}

