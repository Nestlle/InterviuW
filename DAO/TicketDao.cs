using System.Collections.Generic;
using System.Linq;
using InterviuW.Interfaces;
using InterviuW.Models;

namespace InterviuW.DAO
{
    /// <summary>
    /// Daca access object used to controll operations done on storage
    /// for any ticket
    /// </summary>
    public class TicketDao : ITicketDao
    {
        private readonly IStorage _storage;

        public TicketDao(IStorage storage)
        {
            _storage = storage;
        }

        public void Insert(Event ev, Ticket ticket)
        {
            if(ev.Tickets.Any(x => x.Type == ticket.Type))
                throw new System.Exception($"There is already a ticket of {ticket.Type} type"); //TODO Add proper exception here

            ev.Tickets.Add(ticket);
        }

        public List<EventElement> Select()
        {
            return _storage.GetEvents();
        }

        public void Update(Event ev, List<Ticket> modifiedTickets, out List<Ticket> newTickets)
        {
            newTickets = new List<Ticket>();
            foreach(Ticket modifiedTicket in modifiedTickets)
            {
                if(ev.Tickets.Find(x => x.Type == modifiedTicket.Type) == null)
                    throw new KeyNotFoundException($"Could not find Ticket with type {modifiedTicket.Type.ToString()}");

                newTickets.AddRange(ev.Tickets.Where(x => x.Type == modifiedTicket.Type).Select(x => {
                    if(modifiedTicket.Price != null)
                        x.Price = modifiedTicket.Price;
                    if(modifiedTicket.Description != null)
                        x.Description = modifiedTicket.Description;
                    if(modifiedTicket.NumberOfCopies != null)
                        x.NumberOfCopies = modifiedTicket.NumberOfCopies;
                    return x;
                }));
            }
        }
    }
}