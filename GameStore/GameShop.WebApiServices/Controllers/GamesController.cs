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
    public class GamesController : ControllerBase
    {
        private readonly GameService service = new GameService();


        /// <summary>
        /// This service gets all games.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllGames()
        {
            return JsonConvert.SerializeObject(service.GetAllGames(), Formatting.Indented);
        }


        /// <summary>
        /// This service gets all games for a specific developer.
        /// </summary>
        /// <param name="devName"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{devName}")]
        public string GetGamesFromDeveloper(string devName)
        {
            return JsonConvert.SerializeObject(service.GetGamesFromDeveloper(devName), Formatting.Indented);
        }



        /// <summary>
        /// This service creates game from a given JsonObject.
        /// </summary>
        /// <param name="game"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreateGame([FromBody] CreateGameDto game)
        {
            return service.CreateGame(game);
        }

        /// <summary>
        /// This service updates game in the database from a given JsonObject.
        /// </summary>
        /// <param name="game"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string UpdateGame([FromBody] UpdateGameDto game)
        {
            return service.UpdateGame(game);
        }

        /// <summary>
        /// This service deletes a game with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete("{id}")]
        public string DeleteGame(int id)
        {
            return service.DeleteGame(id);
        }
    }
}
