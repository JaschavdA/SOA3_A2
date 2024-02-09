using Domain.CustomerTypes;
using Domain.ExportStrategies;
using System.Text;

namespace Domain
{
    public class Order
    {
        public int OrderNr { get; set; }
        public bool IsStudentOrder { get; set; }
        public List<MovieTicket> MovieTickets { get; set; }
        public ExportStrategy? ExportStrategy { get; set; } = null;
        public CustomerType customerType { get; set; } = null;
        
        public string state { get; set; }

        public Order(int OrderNr, CustomerType customerType)
        {
            this.OrderNr = OrderNr;
            this.IsStudentOrder = IsStudentOrder;
            this.MovieTickets = new List<MovieTicket>();
            this.customerType = customerType;
            this.state = "Available";
        }

        public void AddSeatReservation(MovieTicket Ticket)
        {
            MovieTickets.Add(Ticket);
        }

        public double CalculatePrice()
        {
            return customerType.CalculatePrice(MovieTickets);
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

        public void reserveOrder(DateTime dateTime)
        {

            if (state == "Available")
            {
                Console.WriteLine("Seat reserved");
            } else if (state == "Reserved")
            {
                Console.WriteLine("Already reserved");
            } else if (state == "Paid")
            {
                Console.WriteLine("Already reserved and paid");
            }
        }

        public void payOrder()
        {
            if (state == "Available")
            {
                Console.WriteLine("Seat needs to be reserved");
            }
            else if (state == "Reserved")
            {
                Console.WriteLine("Paid for ticket");
            }
            else if (state == "Paid")
            {
                Console.WriteLine("Already paid");
            }
        }

        public void changeOrder(int seat)
        {
            if (state == "Available")
            {
                Console.WriteLine("Seat reserved");
                setOrderState("Reserved");
            }
            else if (state == "Reserved")
            {
                Console.WriteLine("Already reserved");
                setOrderState("Paid");
            }
            else if (state == "Paid")
            {
                Console.WriteLine("Already paid");
            }
        }

        public void setOrderState(string state)
        {
            this.state = state;
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
    }
}
