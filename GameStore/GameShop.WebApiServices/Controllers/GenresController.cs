using GameStore.Services;
using GameStore.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.WebApiServices.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreService service = new GenreService();

        /// <summary>
        /// This service gets all genres.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllGenres()
        {
            return JsonConvert.SerializeObject(service.GetAllGenres(), Formatting.Indented);
        }


        /// <summary>
        /// This service gets all games for a specific genre.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{genreId}")]
        public string GetAllGamesForGenre(int genreId)
        {
            return JsonConvert.SerializeObject(service.GetAllGamesForGenre(genreId), Formatting.Indented);
        }

        /// <summary>
        /// This service creates genre from a given JsonObject.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreateGenre([FromBody] CreateGenreDto genre)
        {
            return service.CreateGenre(genre);
        }

        /// <summary>
        /// This service updates genre in the database from a given JsonObject.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string UpdateGenre([FromBody] GenreDto genre)
        {
            return service.UpdateGenre(genre);
        }

        /// <summary>
        /// This service deletes a genre with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete("{id}")]
        public string DeleteGenre(int id)
        {
            return service.DeleteGenre(id);
        }
    }
}
