using Domain.ExportStrategies;
using System.Text;

namespace Domain
{
    public class Order
    {
        public int OrderNr { get; set; }
        public bool IsStudentOrder { get; set; }
        public List<MovieTicket> MovieTickets { get; set; }
        
        public ExportStrategy ExportStrategy { get; set; }

        public Order(int OrderNr, bool IsStudentOrder)
        {
            this.OrderNr = OrderNr;
            this.IsStudentOrder = IsStudentOrder;
            this.MovieTickets = new List<MovieTicket>();
        }

        public void AddSeatReservation(MovieTicket Ticket)
        {
            MovieTickets.Add(Ticket);
        }

        public double CalculatePrice()
        {
            int counter = 0;
            double totalPrice = 0;
            for (int i = 0; i < MovieTickets.Count; i++)
            {
                counter++;
                MovieTicket ticket = MovieTickets[i];
                bool isSecond = counter % 2 == 0;
                bool _is_work_Day = IsWorkDay(ticket.GetMovieScreening());
                double singlePrice = CalculatePremiumTicket(ticket);
                // Checks if order is either a studentorder/regular user on weekday and ticket is the second of ticket of the order. 
                totalPrice = CalculateSecondTicket(totalPrice, singlePrice, isSecond, _is_work_Day);
            }
            // Apply discount
            return CalculatePriceAfterDiscount(totalPrice);
        }

        private double CalculateSecondTicket(double currentTotal, double price, bool isSecond, bool isWorkDay)
        {
            if ((isWorkDay || IsStudentOrder) && isSecond)
            {
                return currentTotal;
            }
            else
            {
                return currentTotal + price;
            }
        }
        private double CalculatePremiumTicket(MovieTicket Ticket)
        {
            bool isPremium = Ticket.IsPremiumTicket();
            if (isPremium && IsStudentOrder)
            {
                return Ticket.GetPrice() + 2;
            }
            else if (isPremium)
            {
                return Ticket.GetPrice() + 3;
            }
            else
            {
                return Ticket.GetPrice();
            }
        }
        private double CalculatePriceAfterDiscount(double totalPriceBefore)
        {
            // Returns total after discount
            if (MovieTickets.Count >= 6)
            {
                return totalPriceBefore * 0.9;
            }
            return totalPriceBefore;
        }
        private bool IsWorkDay(MovieScreening movieScreening)
        {
            // Validates for everybody if moviescree is on weekdays.s
            int dayOfWeek = (int)movieScreening.DateAndTime.DayOfWeek;
            return dayOfWeek >= 1 & (dayOfWeek <= 4);
        }

        public void Export(TicketExportFormat Format)
        {
            if (Format == TicketExportFormat.JSON)
            {
                setExportStrategy(new JSONExportStrategy());
            }
            else
            {
                setExportStrategy(new PlainTextExportStrategy());
            }
            this.ExportStrategy.Export(this);
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
