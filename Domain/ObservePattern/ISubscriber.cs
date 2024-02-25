using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observers
{
    public interface ISubscriber
    {

        public void Notify(string message);
    }
}
