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
    public class DevelopersController : ControllerBase
    {
        private readonly DeveloperService service = new DeveloperService();


        /// <summary>
        /// This service gets all developers.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllDevelopers()
        {
            return JsonConvert.SerializeObject(service.GetAllDevelopers(), Formatting.Indented);
        }

        /// <summary>
        /// This service gets all games for a specific developer.
        /// </summary>
        /// <param name="devId"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{devId}")]
        public string GetAllGamesForDeveloper(int devId)
        {
            return JsonConvert.SerializeObject(service.GetAllGamesForDeveloper(devId), Formatting.Indented);
        }

        /// <summary>
        /// This service creates developer from a given JsonObject.
        /// </summary>
        /// <param name="developer"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreateDeveloper([FromBody] CreateDeveloperDto developer)
        {
            return service.CreateDeveloper(developer);
        }


        /// <summary>
        /// This service updates developer in the database from a given JsonObject.
        /// </summary>
        /// <param name="developer"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string UpdateDeveloper([FromBody] DeveloperDto developer)
        {
            return service.UpdateDeveloper(developer);
        }

        /// <summary>
        /// This service deletes a developer with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete("{id}")]
        public string DeleteDeveloper(int id)
        {
            return service.DeleteDeveloper(id);
        }
    }
}
