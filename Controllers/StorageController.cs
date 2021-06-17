using System.Collections.Generic;
using InterviuW.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviuW.Controllers
{
    [ApiController]
    [Route("storage")]
    public class StorageController : ControllerBase
    {
        private Storage _storage;

        public StorageController(Storage storage)
        {
            _storage = storage;
        }

        [HttpPut]
        [Route("fillStorage")]
        public IActionResult FillStorage()
        {
            Event ev = new Event(){
                City = "Brasov",
                Description = "Rock the city",
                EventId = 1234,
                EventDate = new System.DateTime(2021, 09, 15),
                OrganiserName = "Vlad Toma",
                Tickets = new List<Ticket>()
            };
            Event ev2 = new Event(){
                City = "Cluj-Napoca",
                Description = "Rock the city2",
                EventId = 44556,
                EventDate = new System.DateTime(2021, 10, 22),
                OrganiserName = "Vlad Toma2",
                Tickets = new List<Ticket>()
            };
            Ticket ticket1 = new Ticket(){
                NumberOfCopies = 200,
                Currency = Models.Enums.CurrencyType.RON,
                Description = "Bilet in prima loja la Rock the city",
                Price = 200,
                Type = Models.Enums.TicketType.Prio
            };
            Ticket ticket2 = new Ticket(){
                NumberOfCopies = 200,
                Currency = Models.Enums.CurrencyType.RON,
                Description = "Bilet ",
                Price = 200,
                Type = Models.Enums.TicketType.Duo
            };
            Ticket ticket3 = new Ticket(){
                NumberOfCopies = 200,
                Currency = Models.Enums.CurrencyType.EURO,
                Description = "Bilet in prima",
                Price = 200,
                Type = Models.Enums.TicketType.Student
            };

            Ticket ticket4 = new Ticket(){
                NumberOfCopies = 200,
                Currency = Models.Enums.CurrencyType.DOLLAR,
                Description = "Rock the city",
                Price = 200,
                Type = Models.Enums.TicketType.Vip
            };
            _storage.AddEvent(11234, ev);
            _storage.AddEvent(11234, ev2);
            _storage.AddTicket(11234, 1234, ticket1);
            _storage.AddTicket(11234, 1234, ticket2);
            _storage.AddTicket(11234, 44556, ticket3);
            _storage.AddTicket(11234, 44556, ticket4);
            return Ok();
        }
    }
}