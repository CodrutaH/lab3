using Lab2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2B.ViewModel
{
    public class MovieGetModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Watched { get; set; }
        public int NumberOfComments { get; set; }

        public static MovieGetModel FromMovie(Movie movie)
        {
            return new MovieGetModel
            {
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                Year = movie.Year,
                Director = movie.Director,
                Date = movie.Date,
                Rating = movie.Rating,
                Watched = movie.Watched,
                NumberOfComments = movie.Comments.Count
            };
        }
    }
}
