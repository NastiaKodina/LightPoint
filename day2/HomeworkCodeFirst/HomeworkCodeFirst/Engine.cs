using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCodeFirst
{
    public class Engine
    {
        public void AddItem(Model model, string name, string producer, int unitPrice)
        {
            model.OrderItem.Add(new OrderItem
            {
                ItemName = name,
                Producer = producer,
                UnitPrice = unitPrice

            });
            model.SaveChanges();

        }

        public void WriteItemsNames(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.Id + ". " + item.ItemName);
            }
        }

        public decimal CalculateSum(List<Order> orders, int itemId,decimal unitPrice)
        {
            decimal sum = 0;
            foreach (var order in orders)
            {
                if (order.OrderItemId == itemId)
                {
                    sum = order.ItemsQuantity * unitPrice;

                }
            }
            return sum;
        }
    }
}
