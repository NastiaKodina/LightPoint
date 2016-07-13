using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Models
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
