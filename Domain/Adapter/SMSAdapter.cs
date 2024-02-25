using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SendClients;

namespace Domain.Adapter
{
    public class SMSAdapter : IAdapter
    {
        private readonly TestSMSClient client = new TestSMSClient();
        public void Send(string message)
        {
            this.client.Send(message);
        }
    }
}
