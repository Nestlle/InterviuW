using System;
using InterviuW.Models.Enums;
namespace InterviuW.Models
{
    public class Ticket
    {
        public TicketType Type { get; set; }
        public CurrencyType Currency{get;set;}
        public double Price { get; set; }
        public string Description { get; set; }
        public int NumberOfCopies { get; set; }
    }
}