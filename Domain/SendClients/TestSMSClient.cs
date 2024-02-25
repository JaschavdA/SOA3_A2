using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SendClients
{
    internal class TestSMSClient
    {
        public void Send(String message)
        {
            Console.WriteLine("This is an SMS: " + message);
        }
    }
}
