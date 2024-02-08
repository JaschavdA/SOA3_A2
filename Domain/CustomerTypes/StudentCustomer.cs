using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomerTypes
{
    public class StudentCustomer : CustomerType
    {
        public double CalculatePrice(List<MovieTicket> tickets)
        {
            int counter = 0;
            double totalPrice = 0;
            for (int i = 0; i < tickets.Count; i++)
            {
                counter++;
                var ticket = tickets[i];
                bool isSecondTicket = counter % 2 == 0;
                double ticketPrice = CalculatePremiumTicket(ticket);
                totalPrice += CalculateSecondTicket(ticketPrice, isSecondTicket);
            }
            return totalPrice;
        }

        private double CalculateSecondTicket(double ticketPrice, bool isSecondTicket)
        {
            return (isSecondTicket) ? 0 : ticketPrice;
        }

        private double CalculatePremiumTicket(MovieTicket ticket)
        {
            return (ticket.IsPremium) ? ticket.GetPrice() + 2 : ticket.GetPrice();
        }




    }
}
