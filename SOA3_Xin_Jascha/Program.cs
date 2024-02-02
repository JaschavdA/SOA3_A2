namespace SOA3_Xin_Jascha
{
    using Domain;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Export format
            Order Test = new Order(1, true);
            var Movie = new Movie("Steamboat Willie");
            var Screening = new MovieScreening(Movie, DateTime.Now, 10.50);
            var Ticket = new MovieTicket(Screening, false, 1, 1);
            Test.AddSeatReservation(Ticket);
            Test.Export(TicketExportFormat.JSON);

        }
    }
}
