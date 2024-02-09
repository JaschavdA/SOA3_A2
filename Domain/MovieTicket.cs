using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieTicket
    {
        public int RowNr { get; set; }
        public int SeatNr { get; set; }
        public bool IsPremium { get; set; }
        public MovieScreening MovieScreening { get; set; }
        public bool isAvailable { get; set; }

        public MovieTicket(MovieScreening MovieScreening, bool IsPremiumReservation, int SeatRow, int SeatNr)
        {
            this.RowNr = SeatRow;
            this.SeatNr = SeatNr;
            this.IsPremium = IsPremiumReservation;
            this.MovieScreening = MovieScreening;
            this.isAvailable = true;
        }

        public bool IsPremiumTicket()
        {
            return this.IsPremium;
        }

        public double GetPrice()
        {
            return MovieScreening.GetPricePerSeat();
        }

        public MovieScreening GetMovieScreening()
        {
            return MovieScreening;
        }

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("RowNr: " + this.RowNr + "\n");
            sb.Append("SeatNr: " + this.SeatNr + "\n");
            sb.Append("IsPremium: " + this.IsPremium + "\n");
            sb.Append("MovieScreening: " + this.MovieScreening.ToString() + "\n");
            return sb.ToString();
        }
    }
}
