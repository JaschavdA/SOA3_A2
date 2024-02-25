using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Adapter
{
    public interface IAdapter
    {

        void Send(string message);
    }
}
