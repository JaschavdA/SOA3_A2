namespace SOA3_Xin_Jascha
{
    using Domain;
    using Xunit;

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

            // Student order
            DateTime monday = new DateTime(2024, 01, 29);
            DateTime friday = new DateTime(2024, 2, 2);
            Movie little_witch = new Movie("Little Witch Academia");

            MovieScreening movieScreening2 = new MovieScreening(little_witch, friday, 3.0);
            MovieScreening movieScreening = new MovieScreening(little_witch, monday, 3.0);

            MovieTicket fridayPrem = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket fridayPrem2 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket fridayPrem3 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket premium = new MovieTicket(movieScreening, false, 1, 1);
            MovieTicket premium2 = new MovieTicket(movieScreening, false, 1, 1);
            MovieTicket premium3 = new MovieTicket(movieScreening, false, 1, 1);

            Order RegularFridayOrder = new Order(1, false);
            Order order = new Order(1, true);
            Order RegularOrder = new Order(1, false);

            order.AddSeatReservation(premium);
            order.AddSeatReservation(premium2);
            order.AddSeatReservation(premium3);
            RegularOrder.AddSeatReservation(premium);
            RegularOrder.AddSeatReservation(premium2);
            RegularOrder.AddSeatReservation(premium3);
            RegularFridayOrder.AddSeatReservation(fridayPrem);
            RegularFridayOrder.AddSeatReservation(fridayPrem2);
            RegularFridayOrder.AddSeatReservation(fridayPrem3);

            double result = order.CalculatePrice();
            double result2 = RegularOrder.CalculatePrice();
            double FridayResult = RegularFridayOrder.CalculatePrice();

            Assert.Equal(6, result);
            Assert.Equal(6, result2);
            Assert.Equal(9, FridayResult);
            // Discount testing
            fridayPrem2.IsPremium = true;
            premium.IsPremium = true;

            FridayResult = RegularFridayOrder.CalculatePrice();
            result = order.CalculatePrice();
            // Discount student
            Assert.Equal(12, FridayResult);
            Assert.Equal(8, result);
        }
    }
}
