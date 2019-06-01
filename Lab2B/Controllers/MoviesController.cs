using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2B.Services;
using Lab2B.Models;
using Lab2B.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private IMovieService movieService;
        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <param name="from">Optional, filter by minimum Date.</param>
        /// <param name="to">Optional, filter by maximum Date</param>
        /// <param name="genre">A list of Movies objects.</param>
        /// <returns></returns>
        // GET: api/Flowers
        [HttpGet]
        public IEnumerable<MovieGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            return this.movieService.GetAll(from, to);
        }


        /// <summary>
        /// get movies by id
        /// </summary>
        /// <param name="id">get movies by id</param>
        /// <returns></returns>
        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = this.movieService.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        /// <summary>
        /// Add a Movie
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///  POST/Movie
        /// 
        /// {
        ///    "title": "MARA10",
        ///    "description": "a big boat",
        ///    "genre": "action",
        ///    "duration": 100,
        ///    "year": 2001,
        ///    "director": "Paul ",
        ///    "date": "2019-03-10T17:34:19.8376731",
        ///    "rating": 10,
        ///    "watched": "0",
        ///    "comments": [
        ///	   {    
        ///		"text": "Bad",
        ///		"important": false
        ///     }
        ///    ]
        ///   }
        ///    
        ///    
        /// </remarks>
        ///    <param name="movie">The movie to add</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] MoviePostModel movie)
        {
            this.movieService.Create(movie);
        }

        /// <summary>
        /// UPDATE MOVIE AND IF IT DOESN'T EXIST IT CREATES ONE
        /// </summary>
        /// <param name="id">UPDATE MOVIE BY ID</param>
        /// <param name="movie"></param>
        /// <returns></returns>
        // PUT: api/Flowers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var result = movieService.Upsert(id, movie);
            return Ok(result);
        }

        /// <summary>
        /// DELETE MOVIE BY ID
        /// </summary>
        /// <param name="id">DELETE MOVIE BY ID</param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = movieService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}