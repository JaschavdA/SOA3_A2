using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observers
{
    public abstract class ISubscriber
    {
        private readonly Order order;

        protected ISubscriber(Order order) {
            this.order = order;
        }

        public abstract void Notify();
    }
}
