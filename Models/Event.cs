using System;
using System.Collections.Generic;

namespace InterviuW.Models
{
    public class Event
    {
        public string OrganiserName { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        private DateTime eventDate;
        public DateTime? EventDate
        {
            get { return eventDate; }
            set
            {
                if(value == null)
                    eventDate = DateTime.Now;
                else
                    eventDate = (DateTime) value;
            }
        }
        public List<Ticket> Tickets { get; set; }
    }
}