using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public interface IOrderState
    {
        public string Reserve(Order order);
        public string Change(Order order);
        public string Pay(Order order);
        public string Cancel(Order order);

    }
}
