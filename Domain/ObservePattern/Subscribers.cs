using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observers
{
    public class Subscribers : ISubscriber
    {
        private readonly Order order;

        public Subscribers(Order order)
        {
            this.order = order;    
        }
        public void Notify(string message)
        {
            // Adapter converteerd bericht naar bericht.
            // Adapter heeft referenties naar specifieke send client, bijvoorbeeld Outlook. En die verzend de bericht.
        }
    }
}
