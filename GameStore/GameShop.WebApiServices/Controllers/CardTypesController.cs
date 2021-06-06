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
    public class CardTypesController : ControllerBase
    {
        private readonly CardTypeService service = new CardTypeService();

        /// <summary>
        /// This service gets all card types.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllCardTypes()
        {
            return JsonConvert.SerializeObject(service.GetAllCardTypes(), Formatting.Indented);
        }

        /// <summary>
        /// This service gets all cards for a specific type.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{typeId}")]
        public string GetAllCardsForType(int typeId)
        {
            return JsonConvert.SerializeObject(service.GetAllCardsForType(typeId), Formatting.Indented);
        }

        /// <summary>
        /// This service creates card type from a given JsonObject.
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreateCardType([FromBody] CreateCardTypeDto cardType)
        {
            return service.CreateCardType(cardType);
        }


        /// <summary>
        /// This service updates card type in the database from a given JsonObject.
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateCardType([FromBody] CardTypeDto cardType)
        {
            return service.UpdateCardType(cardType);
        }



        /// <summary>
        /// This service deletes a card type with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string DeleteCardType(int id)
        {
            return service.DeleteCardType(id);
        }
    }
}
