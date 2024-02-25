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

            order.NotifyAll("Order has been canceled. Thank you for your visit. Ass.");
            return message;
        }

        public Order Change(Order order)
        {
            Console.WriteLine("Updated order has been returned");
            foreach (var ticket in order.MovieTickets)
            {
                ticket.isAvailable = false; 
            }
            order.NotifyAll("Order has been updated to: " + order.ToString());
            return order;

        }

        public string Pay(Order order)
        {
            if (!IsMoreThan12HoursBeforeScreening(order.MovieTickets))
            {
                order.state = new CanceledState();
                throw new InvalidOperationException(
                    "Order has not been paid and is within 12 hours of screening, order has been cancelled");
            }
            string message = "$" + order.CalculatePrice() + " Has been paid";
            Console.WriteLine(message);

            order.NotifyAll("Order has been paid. Have a nice movie!");
            order.state = new PaidState();
            return message;

        }

        private bool IsMoreThan12HoursBeforeScreening(List<MovieTicket> tickets)
        {
            var dateTime = DateTime.Now.AddHours(12);
            foreach (var ticket in tickets)
            {
                if (ticket.MovieScreening.DateAndTime <= dateTime)
                {
                    return false;
                }
            }
            return true;
        }

        public string Reserve(Order order)
        {
            throw new InvalidOperationException("Cannot reserve a reserved order");
        }
    }
}
