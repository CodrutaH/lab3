using Lab2B.Service;
using Lab2B.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentService commentsService;
        public CommentsController(ICommentService commentsService)
            {
                this.commentsService = commentsService;
            }
            /// <summary>
            /// Gets all the movies
            /// </summary>
            /// <returns></returns>
            // GET: api/Flowers
            [HttpGet]
            public IEnumerable<CommentGetModel> Get(string filter = "")
            {
                return this.commentsService.GetAll(filter);
            }
    }
    
}
