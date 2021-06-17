using System;
using System.Collections.Generic;
using InterviuW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviuW.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly Storage _storage;

        public TicketsController(ILogger<TicketsController> logger, Storage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpGet]
        [Route("getAllTickets")]
        public IActionResult GetAllTickets()
        {
            return StatusCode(200, _storage.GetStorage());
        }

        [HttpPost]
        [Route("modifyTickets")]
        public IActionResult ModifyTickets([FromQuery] int organiserId,
            [FromQuery] int eventId,
            [FromBody] List<Ticket> tickets )
        {
            try
            {
                if(!_storage.GetStorage().Exists(x => x.OrganiserId == organiserId))
                    return StatusCode(400, new ErrorResponse(){
                        StatusCode = 400,
                        Message = $"Cannot find any organiser id with key : {organiserId}"}
                    );
                _storage.ModifyTickets(organiserId, eventId, tickets, out List<Ticket> newTickets);

                return StatusCode(200, 
                    new {
                        Message = $"Modified {tickets.Count} for eventID : {eventId}"
                    }
                );
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
