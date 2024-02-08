using Domain;
using Domain.CustomerTypes;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestStudentNoPremium()
        {
            DateTime monday = new DateTime(2024, 01, 29);
            Movie little_witch = new Movie("Little Witch Academia");
            MovieScreening movieScreening = new MovieScreening(little_witch, monday, 3.0);
            MovieTicket premium = new MovieTicket(movieScreening, false, 1, 1);
            MovieTicket premium2 = new MovieTicket(movieScreening, false, 1, 1);
            MovieTicket premium3 = new MovieTicket(movieScreening, false, 1, 1);

            Order order = new Order(1, true, new StudentCustomer());
            order.AddSeatReservation(premium);
            order.AddSeatReservation(premium2);
            order.AddSeatReservation(premium3);
            double result = order.CalculatePrice();
            Assert.Equal(6, result);
        }

        [Fact]
        public void TestStudentNoFreeTicketAndDiscount()
        {

            DateTime monday = new DateTime(2024, 01, 29);

            Movie little_witch = new Movie("Little Witch Academia");

            MovieScreening movieScreening = new MovieScreening(little_witch, monday, 3.0);
            MovieTicket premium = new MovieTicket(movieScreening, false, 1, 1);
            Order order = new Order(1, true, new StudentCustomer());
            order.AddSeatReservation(premium);
            double FridayResult = order.CalculatePrice();
            Assert.Equal(3, FridayResult);
        }

        [Fact]
        public void TestRegularWeekendNoDiscount()
        {
            DateTime friday = new DateTime(2024, 2, 2);
            Order RegularFridayOrder = new Order(1, false, new RegularCustomer());
            Movie little_witch = new Movie("Little Witch Academia");
            MovieScreening movieScreening2 = new MovieScreening(little_witch, friday, 3.0);
            MovieTicket fridayPrem = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket fridayPrem2 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket fridayPrem3 = new MovieTicket(movieScreening2, false, 1, 1);
            RegularFridayOrder.AddSeatReservation(fridayPrem);
            RegularFridayOrder.AddSeatReservation(fridayPrem2);
            RegularFridayOrder.AddSeatReservation(fridayPrem3);

            double FridayResult = RegularFridayOrder.CalculatePrice();
            Assert.Equal(9, FridayResult);
        }

        [Fact]
        public void TestRegularWeekDayNoDiscount()
        {
            DateTime monday = new DateTime(2024, 1, 29);
            Order mondayOrder = new Order(1, false, new RegularCustomer());
            Movie little_witch = new Movie("Little Witch Academia");
            MovieScreening movieScreening2 = new MovieScreening(little_witch, monday, 3.0);
            MovieTicket mondayPrem = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem2 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem3 = new MovieTicket(movieScreening2, false, 1, 1);
            mondayOrder.AddSeatReservation(mondayPrem);
            mondayOrder.AddSeatReservation(mondayPrem2);
            mondayOrder.AddSeatReservation(mondayPrem3);

            double Result = mondayOrder.CalculatePrice();
            Assert.Equal(6, Result);
        }

        [Fact]
        public void TestRegularWeekDaySecondFreeDiscount()
        {
            DateTime monday = new DateTime(2024, 1, 29);
            Order mondayOrder = new Order(1, false, new RegularCustomer());
            Movie little_witch = new Movie("Little Witch Academia");
            MovieScreening movieScreening2 = new MovieScreening(little_witch, monday, 5.0);
            MovieTicket mondayPrem = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem2 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem3 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem4 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem5 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem6 = new MovieTicket(movieScreening2, false, 1, 1);
            
            mondayOrder.AddSeatReservation(mondayPrem);
            mondayOrder.AddSeatReservation(mondayPrem2);
            mondayOrder.AddSeatReservation(mondayPrem3);
            mondayOrder.AddSeatReservation(mondayPrem4);
            mondayOrder.AddSeatReservation(mondayPrem5);
            mondayOrder.AddSeatReservation(mondayPrem6);

            double Result = mondayOrder.CalculatePrice();
            Assert.Equal(13.5, Result);
        }

        [Fact]
        public void TestRegularWeekendDiscount()
        {
            DateTime friday = new DateTime(2024, 2, 2);
            Order mondayOrder = new Order(1, false, new RegularCustomer());
            Movie little_witch = new Movie("Little Witch Academia");
            MovieScreening movieScreening2 = new MovieScreening(little_witch, friday, 5.0);
            MovieTicket mondayPrem = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem2 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem3 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem4 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem5 = new MovieTicket(movieScreening2, false, 1, 1);
            MovieTicket mondayPrem6 = new MovieTicket(movieScreening2, false, 1, 1);

            mondayOrder.AddSeatReservation(mondayPrem);
            mondayOrder.AddSeatReservation(mondayPrem2);
            mondayOrder.AddSeatReservation(mondayPrem3);
            mondayOrder.AddSeatReservation(mondayPrem4);
            mondayOrder.AddSeatReservation(mondayPrem5);
            mondayOrder.AddSeatReservation(mondayPrem6);

            double Result = mondayOrder.CalculatePrice();
            Assert.Equal(27, Result);
        }


    }
}