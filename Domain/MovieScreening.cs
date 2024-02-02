using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieScreening
    {
        public DateTime DateAndTime { get; set; }
        public double PricePerSeat { get; set; }
        public Movie Movie { get; set; }

        public MovieScreening(Movie Movie, DateTime DateAndTime, double PricePerSeat)
        {
            this.Movie = Movie;
            this.DateAndTime = DateAndTime;
            this.PricePerSeat = PricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return PricePerSeat;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DateTime: " + DateAndTime.ToString() + "\n");
            sb.Append("PricePerSeat: " + PricePerSeat + "\n");
            sb.Append("Movie: " + this.Movie.ToString() + "\n");
            return sb.ToString();
        }
    }
}
