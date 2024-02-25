using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observers
{
    public class Subscribers : ISubscriber
    {

        public Subscribers()
        {
            
        }
        public void Notify(string messageType)
        {
            if (messageType.Equals("email"))
            {
                //Call email client
            } else if (messageType.Equals("sms"))
            {
                //call sms client
            }
        }
    }
}
