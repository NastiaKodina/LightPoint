using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MVC.Data
{
    public static class SampleDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (!context.Orders.Any())
            {
                var order1 = new Order
                {
                    OrderName = "Order #1",
                    TotalPrice = 10,
                };
              
                order1.OrderItems.Add(new OrderItem
                {
                    Name = "Item #1"
                });

                order1.OrderItems.Add(new OrderItem
                {
                    Name = "Item #2"
                });

                order1.OrderItems.Add(new OrderItem
                {
                    Name = "Item #3"
                });

                context.Orders.Add(order1);
                context.SaveChanges();
            }
 

        }
    }
}
