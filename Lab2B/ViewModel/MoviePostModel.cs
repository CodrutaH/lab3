using Lab2B.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2B.ViewModel
{
    public class MoviePostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public DateTime Date { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        public string Watched { get; set; }
        public List<Comment> Comments { get; set; }

        public static Movie ToMovie(MoviePostModel movie)
        {
            Genre genre = Models.Genre.action;
            switch (movie.Genre)
            {
                case "action":
                    genre = Models.Genre.action;
                    break;
                case "comedy":
                    genre = Models.Genre.comedy;
                    break;
                case "horror":
                    genre = Models.Genre.horror;
                    break;
                case "thriller":
                    genre = Models.Genre.thriller;
                    break;
            }

            return new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                Year = movie.Year,
                Director = movie.Director,
                Date = movie.Date,
                Rating = movie.Rating,
                Watched = movie.Watched,
                Genre = genre,
                Comments = movie.Comments
            };
        }
    }
}
