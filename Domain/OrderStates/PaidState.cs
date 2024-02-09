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
            return "Paid order cannot be canceled";
        }

        public string Change(Order order)
        {
            return "Paid order cannot be changed.";
        }

        public string Pay(Order order)
        {
            return "Paid orders is already paid.";
        }

        public string Reserve(Order order)
        {
            return "Paid order has already been reserved";
        }
    }
}
