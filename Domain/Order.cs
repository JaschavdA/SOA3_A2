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

        public Order(int OrderNr, CustomerType customerType)
        {
            this.OrderNr = OrderNr;
            this.IsStudentOrder = IsStudentOrder;
            this.MovieTickets = new List<MovieTicket>();
            this.customerType = customerType;
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
