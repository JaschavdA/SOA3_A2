using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public class PaidState : IOrderState
    {
        public string Cancel(Order order)
        {
            throw new InvalidOperationException("Paid order cannot be canceled");
        }

        public Order Change(Order order)
        {
            throw new InvalidOperationException("Paid order cannot be changed.");
        }

        public string Pay(Order order)
        {
            throw new InvalidOperationException("Paid orders is already paid.");
        }

        public string Reserve(Order order)
        {
            throw new InvalidOperationException("Paid order has already been reserved");
        }
    }
}
