using Domain.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class OrderObservable
    {
        private List<ISubscriber> SubscriberCount { get; set; } = new List<ISubscriber>();

        public OrderObservable()
        {
            SubscriberCount = new List<ISubscriber>();
        }

        public void NotifyAll()
        {
            foreach (var subscriber in SubscriberCount)
            {
                subscriber.Notify();
            }
        }

        void Subscribe(ISubscriber subscriber)
        {
            this.SubscriberCount.Add(subscriber);
        }

        void Unsubscribe(ISubscriber subscriber)
        {
            this.SubscriberCount.Remove(subscriber);
        }
    }
}
