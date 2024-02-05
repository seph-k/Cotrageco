using Cotrageco.Models;

//namespace Cotrageco.ViewModel
//{
//    public class EventsViewModel
//    {
//        public IEnumerable<Event> Events { get; set; }

//    }
//}

namespace Cotrageco.ViewModel
{
    public class EventsViewModel
    {
        public IEnumerable<Banner> Banner { get; set; }
        public IEnumerable<Cotrageco_Content> cotrageco_Contents { get; set; }
        public List<Event> Events { get; set; }

        public List<Event> UpcomingEvents
        {
            get
            {
                return Events
                    .Where(e => e.Event_Date > DateTime.Now || (e.Event_Date.Date == DateTime.Now.Date && e.Event_Time > DateTime.Now.TimeOfDay))
                    .OrderBy(e => e.Event_Date)
                    .ToList();
            }
        }

        public List<Event> PastEvents
        {
            get
            {
                return Events
                    .Where(e => e.Event_Date < DateTime.Now || (e.Event_Date.Date == DateTime.Now.Date && e.Event_Time < DateTime.Now.TimeOfDay))
                    .OrderByDescending(e => e.Event_Date)
                    .ToList();
            }
        }
    }
}

