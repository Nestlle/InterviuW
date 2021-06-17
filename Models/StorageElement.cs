using System.Collections.Generic;

namespace InterviuW.Models
{
    public class StorageElement
    {
        public StorageElement(int organiserId)
        {
            OrganiserId = organiserId;
            Events = new List<Event>();
        }
        public int OrganiserId{get;set;}
        public List<Event> Events{get;set;}
    }
}