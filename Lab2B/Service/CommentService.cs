using Lab2B.Models;
using Lab2B.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2B.Service
{
    public interface ICommentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<CommentGetModel> GetAll(string filter = "");
    }

    public class CommentService : ICommentService
    {

        private MoviesDbContext context;
        public CommentService(MoviesDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<CommentGetModel> GetAll(string filter = "")
        {
            IQueryable<CommentGetModel> result = context.Comments.Select(x => new CommentGetModel
            {
                Id = x.Id,
                Text = x.Text,
                Important = x.Important,
                MovieId = (from ex in context.Movies
                           where ex.Comments.Contains(x)
                           select ex.Id).FirstOrDefault()
            });

            if (filter != "")
            {
                result = result.Where(c => c.Text.Contains(filter));
            }

            return result;
        }


        //    public IEnumerable<CommentGetModel> GetAll(string filter = "")
        //{
        //    IQueryable<Movie> result = context
        //        .Movies
        //        .Include(m => m.Comments);

        //    ICollection<CommentGetModel> comments = new List<CommentGetModel>();

        //    foreach (Movie movie in result)
        //    {
        //        foreach(Comment comment in movie.Comments)
        //        {
        //            if(comment.Text.Contains(filter))
        //                comments.Add(CommentGetModel.FromComment(comment, movie.Id));
        //        }
        //    }

        //    return comments;
        //}
    }
}
