using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public class ReservedState : IOrderState
    {
        public string Cancel(Order order)
        {
            string message = "Order canceled, canceled order can be seen in your order history";
            Console.WriteLine(message);
            order.state = new CanceledState();
            return message;
        }

        public Order Change(Order order)
        {
            Console.WriteLine("Updated order has been returned");
            foreach (var ticket in order.MovieTickets)
            {
                ticket.isAvailable = false; 
            }
            return order;

        }

        public string Pay(Order order)
        {
            string message = "$" + order.CalculatePrice() + " Has been paid";
            Console.WriteLine(message);
            order.state = new PaidState();
            return message;

        }

        public string Reserve(Order order)
        {
            throw new InvalidOperationException("Cannot reserve a reserved order");
        }
    }
}
