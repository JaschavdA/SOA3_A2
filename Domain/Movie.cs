using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Movie
    {
        public string Title { get; set; }
        public List<MovieScreening> Screens { get; set; }

        public Movie(string title)
        {
            Title = title;
        }

        public void AddScreening(MovieScreening MovieScreening)
        {
            Screens.Add(MovieScreening);
        }

        public string ToString()
        {
            return "Title: " + this.Title + "\n";
        }
    }
}
