using System;
using System.Collections.Generic;
using InterviuW.DAO;
using InterviuW.Exceptions;
using InterviuW.Interfaces;
using InterviuW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace InterviuW.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly IStorage _storage;

        public TicketsController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        [Route("getTicketsInformations")]
        public IActionResult GetTicketsInformations()
        {
            ITicketDao ticketDao = new TicketDao(_storage);
            return StatusCode(200, ticketDao.Select());
        }

        [HttpPost]
        [Route("modifyTickets")]
        public IActionResult ModifyTickets([FromQuery] int eventId, [FromBody] List<Ticket> tickets )
        {
            string apiKey = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1];
            IEventDao eventDao = new EventDao(_storage);
            ITicketDao ticketDao = new TicketDao(_storage);
            ITokenDao tokenDao = new TokenDao(_storage);

            try
            {
                int organiserId = tokenDao.GetOrganiserId(apiKey);
                ticketDao.Update(eventDao.Find((int)organiserId, eventId), tickets, out List<Ticket> newTickets);
                return StatusCode(200,
                    new {
                        Message = $"Modified {tickets.Count} for eventID : {eventId}."
                    }
                );
            }
            catch(OrganiserNotFoundException e)
            {
                return StatusCode(403, new ErrorResponse(){
                        StatusCode = 403,
                        Message = e.Message
                });
            }
            catch(OrganiserNotOwnerException e)
            {
                return StatusCode(403, new ErrorResponse(){
                        StatusCode = 403,
                        Message = e.Message
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, new ErrorResponse(){
                        StatusCode = 500,
                        Message = $"There was a problem processing the request. Message : {e.Message}"}
                    );
            }
        }
    }
}
