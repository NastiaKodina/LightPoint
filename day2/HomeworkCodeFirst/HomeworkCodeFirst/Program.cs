using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var orderModel = new Model())
            {
                while (true)
                {
                    Console.WriteLine("Enter: \n 1 - To add new Item \n 2 - To calculate the total price \n");

                    var engine = new Engine();
                    if (Console.ReadKey().KeyChar == 49)
                    {
                        Console.WriteLine("Enter the name of the Item: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the producer of the Item: ");
                        string producer = Console.ReadLine();
                        Console.WriteLine("Enter the unit price of the Item: ");
                        string unitPriceString= Console.ReadLine();
                        int unitPrice = Int32.Parse(unitPriceString);
                        engine.AddItem(orderModel,name,producer,unitPrice);
                    }
                    else
                    {
                        decimal sum = 0;
                        Console.WriteLine("Choose one Item: ");
                        var items = orderModel.OrderItem.ToList();
                        engine.WriteItemsNames(items);
                        Console.WriteLine("Enter the number of the Item: ");
                        string numberString = Console.ReadLine();
                        int itemId = Convert.ToInt32(numberString);
                        var currentItem = items.Where(e => e.Id == itemId).Single();                 
                        decimal unitPrice = currentItem.UnitPrice;
                        var orders = orderModel.Order.ToList();
                        sum = engine.CalculateSum(orders, itemId, unitPrice);
                        Console.WriteLine(sum);
                        Console.ReadLine();
                        

                    }
                }

            }
        }

        
    }
}
