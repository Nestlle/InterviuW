using System.Collections.Generic;

namespace InterviuW.Models
{
    public class EventElement
    {
        public EventElement(int organiserId)
        {
            OrganiserId = organiserId;
            Events = new List<Event>();
        }
        public int OrganiserId{get;set;}
        public List<Event> Events{get;set;}
    }
}