using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public class CanceledState : IOrderState
    {
        public string Cancel(Order order)
        {
            throw new InvalidOperationException("Cannot cancel already canceled order");
        }

        public Order Change(Order order)
        {
            throw new InvalidOperationException("Cannot change canceled order");
        }

        public string Pay(Order order)
        {
            throw new InvalidOperationException("Cannot pay for canceled order");
        }

        public string Reserve(Order order)
        {
            throw new InvalidOperationException("Canceled order cannot be reserved anymore");
        }
    }
}
