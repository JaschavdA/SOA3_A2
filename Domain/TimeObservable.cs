using Domain.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class TimeObservable : IOrderObservable
    {
        private List<ISubscriber> subscribers;
        private Order order;
        public TimeObservable(Order order)
        {
            this.subscribers = new List<ISubscriber>();
            this.order = order;
        }

        public void LessThan24Hours()
        {
            var dateTime = DateTime.Now.AddHours(24);
            foreach (var ticket in order.MovieTickets)
            {
                if (ticket.MovieScreening.DateAndTime <= dateTime)
                {
                    NotifyAll("Less than 24 hours");
                    break;
                }
            }
        }


        public void NotifyAll(string message)
        {
            foreach (var sub in subscribers)
            {
             sub.Notify(message);   
            }
        }

        public void SubscribeTo(ISubscriber subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void UnSubscribeTo(ISubscriber subscriber)
        {
            this.subscribers.Remove(subscriber);
        }
    }
}
