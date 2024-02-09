using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public interface IOrderState
    {
        public string Reserve();
        public void Change();
        public int Pay();
        public void Cancel();

    }
}
