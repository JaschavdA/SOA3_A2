using Domain.CustomerTypes;
using Domain.ExportStrategies;
using System.Text;
using Domain.OrderStates;
using Domain.Observers;

namespace Domain
{
    public class Order: IOrderObservable
    {
        public int OrderNr { get; set; }
        public bool IsStudentOrder { get; set; }
        public List<MovieTicket> MovieTickets { get; set; }
        public List<ISubscriber> SubscriberList { get; set; }

        public ExportStrategy? ExportStrategy { get; set; } = null;
        public CustomerType customerType { get; set; } = null;

        public IOrderState state { get; set; } 
        public List<ISubscriber> subscribers { get; set; }

        public Order(int OrderNr, CustomerType customerType)
        {
            this.OrderNr = OrderNr;
            this.IsStudentOrder = IsStudentOrder;
            this.MovieTickets = new List<MovieTicket>();
            this.customerType = customerType;
            this.state = new ConceptState();
            SubscriberList = new List<ISubscriber>();
        }

        public void AddSeatReservation(MovieTicket Ticket)
        {
            MovieTickets.Add(Ticket);
        }

        public double CalculatePrice()
        {
            return customerType.CalculatePrice(MovieTickets);
        }

        public string reserveOrder()
        {
            return state.Reserve(this);
        }

        public string changeOrder(Order changedOrder)
        {
            //Changes order
            Order change = state.Change(changedOrder);
            this.MovieTickets = change.MovieTickets;
            return change.ToString();
        }

        public string cancelOrder()
        {
            return state.Cancel(this);
        }

        public string payOrder()
        {
            return state.Pay(this);
        }

        private DateTime getEarliestDateOrder()
        {
            return MovieTickets.Min(ticket => ticket.GetMovieScreening().DateAndTime);
        }

        public void Export(TicketExportFormat Format)
        {
            try
            {
                switch (Format)
                {
                    case TicketExportFormat.JSON:
                        setExportStrategy(new JSONExportStrategy());
                        break;
                    case TicketExportFormat.PLAINTEXT:
                        setExportStrategy(new PlainTextExportStrategy());
                        break;
                }
                ExportStrategy?.Export(this);
            } 
            catch
            {
                Console.WriteLine("No export");
            }
        }

        public void setExportStrategy(ExportStrategy exportStrategy)
        {
            this.ExportStrategy = exportStrategy;
        }

        
        override
        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("OrderNr: " + OrderNr + "\n");
            sb.Append("Is student order: " + IsStudentOrder + "\n");
            MovieTickets.ForEach(t =>
            {
                sb.Append(t.ToString() + "\n");
            });
            return sb.ToString();
        }

        public void SubscribeTo(ISubscriber subscriber)
        {
            SubscriberList.Add(subscriber);
        }

        public void UnSubscribeTo(ISubscriber subscriber)
        {
            SubscriberList.Remove(subscriber);
        }

        public void NotifyAll()
        {
            foreach (var sub in SubscriberList)
            {
                sub.Notify();
            }
        }
    }
}
