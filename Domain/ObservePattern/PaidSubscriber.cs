using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observers
{
    public class PaidSubscriber : ISubscriber
    {
        public PaidSubscriber(Order order) : base(order)
        {
        }

        public override void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
