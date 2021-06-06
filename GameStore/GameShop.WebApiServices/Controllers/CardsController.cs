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
    public class CardsController : ControllerBase
    {
        private readonly CardService service = new CardService();
        

        /// <summary>
        /// This service gets all cards.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllCards()
        {
            return JsonConvert.SerializeObject(service.GetAllCards(), Formatting.Indented);
        }

        /// <summary>
        /// This service gets all cards of a specific user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{userId}")]
        public string GetAllCardsForUser(int userId)
        {
            return JsonConvert.SerializeObject(service.GetAllCardsForUser(userId), Formatting.Indented);
        }

        /// <summary>
        /// This service creates card from a given JsonObject.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreateCard([FromBody] CreateCardDto card)
        {
            return service.CreateCard(card);
        }

        /// <summary>
        /// This service updates card in the database from a given JsonObject.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string UpdateCard([FromBody]UpdateCardDto card)
        {
            return service.UpdateCard(card);
        }

        /// <summary>
        /// This service deletes a card with given id.
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns>string</returns>
        [HttpDelete("{cardId}")]
        public string DeleteCard(int cardId)
        {
            return service.DeleteCard(cardId);
        }
    }
}
