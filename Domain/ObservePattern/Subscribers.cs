using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Adapter;

namespace Domain.Observers
{
    public class Subscribers : ISubscriber
    {
        private readonly Order order;
        private readonly IAdapter adapter;

        public Subscribers(IAdapter adapter)
        {
            this.adapter = adapter;
        }
        public void Notify(string message)
        {
            // Adapter converteerd bericht naar bericht.
            // Adapter heeft referenties naar specifieke send client, bijvoorbeeld Outlook. En die verzend de bericht.
            this.adapter.Send(message);

        }
    }
}
