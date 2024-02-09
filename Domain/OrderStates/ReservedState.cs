using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public class ReservedState : IOrderState
    {
        public string Cancel(Order order)
        {
            Console.WriteLine();
            throw new NotImplementedException();
        }

        public string Change(Order order)
        {
            throw new NotImplementedException();
        }

        public string Pay(Order order)
        {
            throw new NotImplementedException();
        }

        public string Reserve(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
