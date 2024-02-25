using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Adapter;
using Domain.CustomerTypes;
using Domain.Observers;
using Domain.OrderStates;

namespace Tests
{
    public class ReservedStateTest
    {
        [Fact]
        public void CancelCancelsOrder()
        {
            var order = new Order(1, new RegularCustomer());
            order.state = new ReservedState();
            order.cancelOrder();
            Assert.IsType<CanceledState>(order.state);
        }

        [Fact]
        public void ChangeOrderShouldMakeAllMovieTicketsUnavailable()
        {
            var order = new Order(1, new RegularCustomer());
            order.state = new ReservedState();


            var updatedOrder = new Order(1, new RegularCustomer());
            var movie1 = new Movie("Steamboat Willie");
            var screening1 = new MovieScreening(movie1, DateTime.Now, 10);
            var ticket1 = new MovieTicket(screening1, false, 1, 1);
            var ticket2 = new MovieTicket(screening1, false, 1, 2);
            updatedOrder.MovieTickets.Add(ticket1);
            updatedOrder.MovieTickets.Add(ticket2);

            order.changeOrder(updatedOrder);
            foreach (var ticket in order.MovieTickets)
            {
             Assert.False(ticket.isAvailable);   
            }

        }

        [Fact]
        public void ThrowsInvalidOperationExceptionIfPaidLessThan12HoursBeforeScreening()
        {
            var order = new Order(1, new RegularCustomer());
            order.state = new ReservedState();

            var movie1 = new Movie("Steamboat Willie");
            var screening1 = new MovieScreening(movie1, DateTime.Now, 10);
            var screening2 = new MovieScreening(movie1, DateTime.Now.AddHours(13), 10);
            var ticket1 = new MovieTicket(screening1, false, 1, 1);
            var ticket2 = new MovieTicket(screening2, false, 1, 2);
            order.MovieTickets.Add(ticket1);
            order.MovieTickets.Add(ticket2);
            Assert.Throws<InvalidOperationException>(() => order.payOrder());
        }

        [Fact]
        public void ChangesStateToCancelledIfPaidLessThan12HoursBeforeScreening()
        {
            var order = new Order(1, new RegularCustomer());
            order.state = new ReservedState();

            var movie1 = new Movie("Steamboat Willie");
            var screening1 = new MovieScreening(movie1, DateTime.Now, 10);
            var screening2 = new MovieScreening(movie1, DateTime.Now.AddHours(13), 10);
            var ticket1 = new MovieTicket(screening1, false, 1, 1);
            var ticket2 = new MovieTicket(screening2, false, 1, 2);
            order.MovieTickets.Add(ticket1);
            order.MovieTickets.Add(ticket2);

            // Observer and adapter.
            EmailAdapter emailAdapter = new EmailAdapter();
            Subscribers sub1 = new Subscribers(emailAdapter);

            // Apply sub to order
            order.SubscribeTo(sub1);

            try
            {
                order.payOrder();
                Assert.IsType<CanceledState>(order.state);

            }
            catch (Exception e)
            {
                Assert.IsType<CanceledState>(order.state);
            }
        }

        [Fact]
        public void ReturnsPriceStringIfMoreThan12Hours()
        {
            var order = new Order(1, new RegularCustomer());
            order.state = new ReservedState();

            var movie = new Movie("Steamboat Willie");
            var screening = new MovieScreening(movie, DateTime.Now.AddHours(13), 10);
            var ticket = new MovieTicket(screening, false, 1, 2);
            order.MovieTickets.Add(ticket);

            // Observer and adapter.
            EmailAdapter emailAdapter = new EmailAdapter();
            Subscribers sub1 = new Subscribers(emailAdapter);

            // Apply sub to order
            order.SubscribeTo(sub1);

            var result = order.payOrder();
            Assert.Equal("$10 Has been paid", result);
        }

        [Fact]
        public void ReserveThrowsInvalidOperationException()
        {
            var order = new Order(1, new RegularCustomer());
            order.state = new ReservedState();

            Assert.Throws<InvalidOperationException>(() => order.reserveOrder());
        }
    }
}
