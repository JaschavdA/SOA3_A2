using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomerTypes
{
    public class RegularCustomer : CustomerType
    {
        public double CalculatePrice(List<MovieTicket> tickets)
        {
            int counter = 0;
            double totalPrice = 0;
            bool isWorkDay = false; 

            for (int i = 0; i < tickets.Count; i++)
            {
                counter++;
                var ticket = tickets[i];
                bool isSecondTicket = counter % 2 == 0;
                isWorkDay = IsWorkDay(ticket.MovieScreening);
                double ticketPrice = CalculatePremiumTicket(ticket);
                totalPrice += CalculateSecondTicket(ticketPrice, isSecondTicket, isWorkDay);
            }
            return ApplyGroupDiscount(counter, totalPrice, isWorkDay);
        }

        private bool IsWorkDay(MovieScreening movieScreening)
        {
            // Validates for everybody if moviescree is on weekdays.s
            int dayOfWeek = (int)movieScreening.DateAndTime.DayOfWeek;
            return dayOfWeek >= 1 & (dayOfWeek <= 4);
        }

        private double CalculatePremiumTicket(MovieTicket ticket)
        {
            return (ticket.IsPremium) ? ticket.GetPrice() + 3 : ticket.GetPrice();
        }

        private double CalculateSecondTicket(double ticketPrice, bool isSecondTicket, bool isWorkDay)
        {
            return (isSecondTicket && isWorkDay) ? 0 : ticketPrice;
        }

        //Currently assuming that all tickets are for the same day.
        private double ApplyGroupDiscount(int numberOfTickets, double totalPrice, bool isWorkDay)
        {
            return (numberOfTickets > 5 && !isWorkDay) ? totalPrice * 0.9 : totalPrice;
        }
    }
}
