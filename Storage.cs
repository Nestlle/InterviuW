using System;
using System.Collections.Generic;
using System.Linq;
using InterviuW.Models;
namespace InterviuW
{
    public class Storage
    {
        private List<StorageElement> _events;
        public List<StorageElement> GetStorage()
        {
            return _events;
        }
        public Storage()
        {
            _events = new List<StorageElement>();
        }

        public void AddEvent(int organiserId, Event eventTobeAdded)
        {
            if(!_events.Exists(x=> x.OrganiserId == organiserId))
            {
               _events.Add(new StorageElement(organiserId));
            }
            var organiserEvents = _events.Find(x => x.OrganiserId == organiserId).Events;
            if(organiserEvents.Any(x => x.EventId == eventTobeAdded.EventId))
                throw new System.Exception($"There is already an event with id : {eventTobeAdded.EventId}"); //TODO: throw proper exception

            organiserEvents.Add(eventTobeAdded);
        }

        public void AddTicket(int organiserId, int eventId, Ticket ticket)
        {
            var searchedEvent = FindEvent(organiserId, eventId);
            if(searchedEvent.Tickets.Any(x => x.Type == ticket.Type))
                throw new System.Exception($"There is already a ticket of {ticket.Type} type"); //TODO Add proper exception here

            searchedEvent.Tickets.Add(ticket);
        }

        public void ModifyTickets(int organiserId, int eventId, List<Ticket> modifiedTickets, out List<Ticket> newTickets)
        {
            var searchedEvent = FindEvent(organiserId, eventId);
            newTickets = new List<Ticket>();
            foreach(Ticket modifiedTicket in modifiedTickets)
            {
                if(searchedEvent.Tickets.Find(x => x.Type == modifiedTicket.Type) == null)
                    throw new KeyNotFoundException($"Could not find Ticket with type {modifiedTicket.Type.ToString()}");

                newTickets.AddRange(searchedEvent.Tickets.Where(x => x.Type == modifiedTicket.Type).Select(x => {
                    x.Price = modifiedTicket.Price;
                    x.Description = modifiedTicket.Description;
                    x.NumberOfCopies = modifiedTicket.NumberOfCopies;
                    return x;
                }));
            }
        }

        private Event FindEvent(int organiserId, int eventId)
        {
            var organiserEvents = _events.Where(x => x.OrganiserId == organiserId).Select(x => x.Events).FirstOrDefault();
            if(organiserEvents == null)
                throw new System.Exception($"Cannot find any events for specified organiser Id : {organiserId}"); //TODO Add proper exception here

            var searchedEvent = organiserEvents.Where(x => x.EventId == eventId).FirstOrDefault();
            if(searchedEvent == null)
                throw new System.Exception($"Cannot find any event for the give id : {eventId}"); //TODO Add proper exception here

            return searchedEvent;
        }
    }
}