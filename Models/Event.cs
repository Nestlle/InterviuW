using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviuW.Models
{
    public class Event
    {
        [Required]
        public string OrganiserName { get; set; }
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        private DateTime eventDate;
        [Required]
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