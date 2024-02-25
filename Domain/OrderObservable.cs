using Domain.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IOrderObservable
    {
        void SubscribeTo(ISubscriber subscriber);
        void UnSubscribeTo(ISubscriber subscriber);
        void NotifyAll(string message);
    }
}
