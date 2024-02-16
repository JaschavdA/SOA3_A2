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
            return "Order has been canceled";
        }

        public Order Change(Order order)
        {
            throw new NotImplementedException();
        }

        public string Pay(Order order)
        {
            return "Canceled orders cannot be paid.";
        }

        public string Reserve(Order order)
        {
            return "Order has been reserved";
        }
    }
}
