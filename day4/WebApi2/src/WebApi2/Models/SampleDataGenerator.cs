using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi2.Models
{
    public static class SampleDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<EventsContext>();

            if (!context.Events.Any())
            {
                var location1 = new Location
                {
                    Name = "location #1",
                    Lat = 13.0,
                    Long = 150.34
                };

                location1.Events.Add(new Event
                {
                    Name = "event #1",
                    Description = "descrition #1",
                    
                });

                location1.Events.Add(new Event
                {
                    Name = "event #2",
                    Description = "descrition #2",

                });

                location1.Events.Add(new Event
                {
                    Name = "event #3",
                    Description = "descrition #3",

                });

                context.Locations.Add(location1);
                context.SaveChanges();
            }


        }
    }
}
