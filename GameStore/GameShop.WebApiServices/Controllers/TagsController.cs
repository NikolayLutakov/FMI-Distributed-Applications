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
    public class TagsController : ControllerBase
    {
        private readonly TagService service = new TagService();

        /// <summary>
        /// This service gets all tags.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllTags()
        {
            return JsonConvert.SerializeObject(service.GetAllTags(), Formatting.Indented);
        }

        /// <summary>
        /// This service gets all tags for a specific game.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{gameId}")]
        public string GetTagsForGame(int gameId)
        {
            return JsonConvert.SerializeObject(service.GetTagsForGame(gameId), Formatting.Indented);
        }



        /// <summary>
        /// This service creates tag from a given JsonObject.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreateTag([FromBody] CreateTagDto tag)
        {
            return service.CreateTag(tag);
        }


        /// <summary>
        /// This service updates tag in the database from a given JsonObject.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string UpdateTag([FromBody] TagDto tag)
        {
            return service.UpdateTag(tag);
        }

        /// <summary>
        /// This service adds specific tag to a specific game.
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="gameId"></param>
        /// <returns>string</returns>
        [HttpPost("{tagId},{gameId}")]
        public string AddTagToGame(int tagId, int gameId)
        {
            return service.AddTagToGame(tagId, gameId);
        }

        /// <summary>
        /// This service removes specific tag from a specific game.
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="gameId"></param>
        /// <returns>string</returns>
        [HttpPost("{tagId},{gameId}")]
        public string RemoveTagFromGame(int tagId, int gameId)
        {
            return service.RemoveTagFromGame(tagId, gameId);
        }



        /// <summary>
        /// This service deletes a tag with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete("{id}")]
        public string DeleteTag(int id)
        {
            return service.DeleteTag(id);
        }
    }
}
