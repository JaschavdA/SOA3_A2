using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomerTypes
{
    public interface CustomerType
    {
        public double CalculatePrice(List<MovieTicket> tickets);
    }
}
