using Lab2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2B.ViewModel
{
    public class CommentGetModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public int MovieId { get; set; }

        public static CommentGetModel FromComment(Comment comment, int movieId)
        {
            return new CommentGetModel
            {
                Id = comment.Id,
                Text = comment.Text,
                Important = comment.Important,
                MovieId = movieId
            };
        }
    }
}
