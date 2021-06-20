using InterviuW.Exceptions;
using System.Linq;
using InterviuW.Interfaces;
using InterviuW.Models;
using System;

namespace InterviuW.DAO
{
    /// <summary>
    /// Daca access object used to controll operations done on storage
    /// for any events
    /// </summary>
    public class EventDao : IEventDao
    {
        private readonly IStorage _storage;

        public EventDao(IStorage storage)
        {
            _storage = storage;
        }

        public void Insert(int organiserId, Event eventTobeAdded)
        {
            if(!_storage.GetEvents().Exists(x=> x.OrganiserId == organiserId))
            {
               _storage.GetEvents().Add(new EventElement(organiserId));
            }
            var organiserEvents = _storage.GetEvents().Find(x => x.OrganiserId == organiserId).Events;
            if(organiserEvents.Any(x => x.EventId == eventTobeAdded.EventId))
                throw new ArgumentException($"There is already an event with id : {eventTobeAdded.EventId}");

            organiserEvents.Add(eventTobeAdded);
        }

        public Event Find(int organiserId, int eventId)
        {
            var organiserEvents = _storage.GetEvents().Where(x => x.OrganiserId == organiserId).Select(x => x.Events).FirstOrDefault();
            if(organiserEvents == null)
                throw new OrganiserNotFoundException($"Cannot find any events for specified organiser Id : {organiserId}");

            var searchedEvent = organiserEvents.Where(x => x.EventId == eventId).FirstOrDefault();
            if(searchedEvent == null)
                throw new OrganiserNotOwnerException($"Cannot find any event for the give id : {eventId}");

            return searchedEvent;
        }
    }
}