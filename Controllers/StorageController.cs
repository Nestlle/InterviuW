using System.Collections.Generic;
using InterviuW.DAO;
using InterviuW.Interfaces;
using InterviuW.Models;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller used just to fill the storage.
/// Not part of the project.
/// </summary>
namespace InterviuW.Controllers
{
    [ApiController]
    [Route("storage")]
    public class StorageController : ControllerBase
    {
        private IStorage _storage;

        public StorageController(IStorage storage)
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
            EventDao eventDao = new EventDao(_storage);
            TicketDao ticketDao = new TicketDao(_storage);
            TokenDao tokenDao = new TokenDao(_storage);
            eventDao.Insert(11234, ev);
            eventDao.Insert(11234, ev2);
            ticketDao.Insert(eventDao.Find(11234, 1234), ticket1);
            ticketDao.Insert(eventDao.Find(11234, 1234), ticket2);
            ticketDao.Insert(eventDao.Find(11234, 1234), ticket3);
            ticketDao.Insert(eventDao.Find(11234, 1234), ticket4);

            Token token = new Token();
            token.ApiToken = "qwekasjdj127318273#%$%#^$hasjhd";
            token.OrganiserId = 11234;
            token.ExpirationDate = System.DateTime.Now.AddHours(1);

            tokenDao.Insert(token);
            return Ok();
        }
    }
}