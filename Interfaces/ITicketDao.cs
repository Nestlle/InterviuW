using System.Collections.Generic;
using InterviuW.Models;

namespace InterviuW.Interfaces
{
    public interface ITicketDao
    {
         void Insert(Event ev, Ticket ticket);
         void Update(Event ev, List<Ticket> modifiedTickets, out List<Ticket> newTickets);
         List<EventElement> Select();
    }
}