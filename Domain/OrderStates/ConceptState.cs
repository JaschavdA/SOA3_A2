using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public class ConceptState : IOrderState
    {
        public string Cancel(Order order)
        {
            string message = "Order canceled, canceled order can be seen in your order history";
            Console.WriteLine(message);

            order.NotifyAll("Order has been canceled. I am sorry for changing your mind. Should your mother have done that about you");
            return message;
        }

        public Order Change(Order order)
        {
            Console.WriteLine("Updated order returned");
            return order;
        }

        public string Pay(Order order)
        {
            throw new InvalidOperationException("Concept order cannot be paid, please reserve tickets first");
        }

        public string Reserve(Order order)
        {
            foreach (var ticket in order.MovieTickets)
            {
                ticket.isAvailable = false;
            }

            string message = "Tickets have been reserved";
            Console.WriteLine(message);
            order.state = new ReservedState();
            return message;
        }
    }
}
