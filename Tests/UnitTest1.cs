using Domain;
using Domain.CustomerTypes;
using Domain.OrderStates;

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

            Order order = new Order(1, new StudentCustomer());
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
            Order order = new Order(1, new StudentCustomer());
            order.AddSeatReservation(premium);
            double FridayResult = order.CalculatePrice();
            Assert.Equal(3, FridayResult);
        }

        [Fact]
        public void TestRegularWeekendNoDiscount()
        {
            DateTime friday = new DateTime(2024, 2, 2);
            Order RegularFridayOrder = new Order(1, new RegularCustomer());
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
            Order mondayOrder = new Order(1, new RegularCustomer());
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
            Order mondayOrder = new Order(1, new RegularCustomer());
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
            Assert.Equal(15, Result);
        }

        [Fact]
        public void TestRegularWeekendDiscount()
        {
            DateTime friday = new DateTime(2024, 2, 2);
            Order mondayOrder = new Order(1, new RegularCustomer());
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

        [Fact]
        public void TestCanceledStatePayOrderShouldThrowException()
        {
            Order order = new Order(1, new RegularCustomer());
            CanceledState canceledState = new CanceledState();
            order.state = canceledState;

            var exception = Assert.Throws<InvalidOperationException>(()=> order.payOrder());

            Assert.Equal("Cannot pay for canceled order", exception.Message);
        }

        [Fact]
        public void TestCanceledStateCancelOrder()
        {
            Order order = new Order(1, new RegularCustomer());
            CanceledState canceledState = new CanceledState();
            order.state = canceledState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.cancelOrder());

            Assert.Equal("Cannot cancel already canceled order", exception.Message);
        }

        [Fact]
        public void TestCanceledStateReserve()
        {
            Order order = new Order(1, new RegularCustomer());
            CanceledState canceledState = new CanceledState();
            order.state = canceledState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.reserveOrder());

            Assert.Equal("Canceled order cannot be reserved anymore", exception.Message);
        }

        [Fact]
        public void TestCanceledStateChangeOrder()
        {
            Order order = new Order(1, new RegularCustomer());
            CanceledState canceledState = new CanceledState();
            order.state = canceledState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.changeOrder(order));

            Assert.Equal("Cannot change canceled order", exception.Message);
        }

        [Fact]
        public void TestPaidStatePayOrderShouldThrowException()
        {
            Order order = new Order(1, new RegularCustomer());
            PaidState paidState = new PaidState();
            order.state = paidState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.payOrder());

            Assert.Equal("Paid orders is already paid.", exception.Message);
        }

        [Fact]
        public void TestPaidStateCancelOrder()
        {
            Order order = new Order(1, new RegularCustomer());
            PaidState paidState = new PaidState();
            order.state = paidState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.cancelOrder());

            Assert.Equal("Paid order cannot be canceled", exception.Message);
        }

        [Fact]
        public void TestPaidStateReserve()
        {
            Order order = new Order(1, new RegularCustomer());
            PaidState paidState = new PaidState();
            order.state = paidState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.reserveOrder());

            Assert.Equal("Paid order has already been reserved", exception.Message);
        }

        [Fact]
        public void TestPaidStateChangeOrder()
        {
            Order order = new Order(1, new RegularCustomer());
            PaidState paidState = new PaidState();
            order.state = paidState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.changeOrder(order));

            Assert.Equal("Paid order cannot be changed.", exception.Message);
        }

        [Fact]
        public void TestConceptStatePay()
        {
            Order order = new Order(1, new RegularCustomer());
            ConceptState conceptState = new ConceptState();
            order.state = conceptState;

            var exception = Assert.Throws<InvalidOperationException>(() => order.payOrder());

            Assert.Equal("Concept order cannot be paid, please reserve tickets first", exception.Message);
        }

        [Fact]
        public void TestConceptStateCancelOrder()
        {
            Order order = new Order(1, new RegularCustomer());
            ConceptState conceptState = new ConceptState();
            order.state = conceptState;

            var result = order.cancelOrder();

            Assert.Equal("Order canceled, canceled order can be seen in your order history", result);
        }

        [Fact]
        public void TestConceptStateReserve()
        {
            Order order = new Order(1, new RegularCustomer());
            ConceptState conceptState = new ConceptState();
            MovieScreening yourName = new MovieScreening(new Movie("Your name."), new DateTime(2026, 1, 1), 3.0);
            MovieTicket yourNameTicket = new MovieTicket(yourName, true, 1, 1);
            order.AddSeatReservation(yourNameTicket);

            order.state = conceptState;

            var result = order.reserveOrder();

            Assert.Equal("Tickets have been reserved", result);
            Assert.Equal(order.state.GetType().Name, "ReservedState");
        }

        [Fact]
        public void TestConceptStateChangeOrder()
        {
            Order order = new Order(1, new RegularCustomer());
            ConceptState conceptState = new ConceptState();
            MovieScreening yourName = new MovieScreening(new Movie("Your name."), new DateTime(2026, 1, 1), 3.0);
            MovieTicket yourNameTicket = new MovieTicket(yourName, true, 1, 1);
            order.AddSeatReservation(yourNameTicket);

            order.state = conceptState;

            var result = order.changeOrder(order);

            Assert.Equal("OrderNr: 1\nIs student order: False\nRowNr: 1\nSeatNr: 1\nIsPremium: True\nMovieScreening: DateTime: 1/1/2026\nPricePerSeat: 3\nMovie: Title: Your name.\n\n\n\n", result);
        }
    }
}