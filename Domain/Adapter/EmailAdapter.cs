using Domain.SendClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Adapter
{
    public class EmailAdapter : IAdapter
    {
        private readonly TestEmailClient client;

        public EmailAdapter() { 
            client = new TestEmailClient();
        }

        public void Send(string message)
        {
            client.SendTo(message);
        }
    }
}
