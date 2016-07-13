using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi2.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private EventsContext _context;
        public EventsController(EventsContext eventsContext)
        {
            _context = eventsContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events.ToList();

        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
        }

       
    }
}
