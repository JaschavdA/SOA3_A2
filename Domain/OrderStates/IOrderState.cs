using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OrderStates
{
    public interface IOrderState
    {
        public string Submit();
        public void AddReservation(MovieTicket ticket);
        public int CalculatePrice(List<MovieTicket> tickets);
        public void Export();

    }
}
