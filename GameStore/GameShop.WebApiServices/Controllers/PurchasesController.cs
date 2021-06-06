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
    public class PurchasesController : ControllerBase
    {
        private readonly PurchaseService service = new PurchaseService();

        /// <summary>
        /// This service gets all purchases.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllPurchases()
        {
            return JsonConvert.SerializeObject(service.GetAllPurchases(), Formatting.Indented);
        }


        /// <summary>
        /// This service gets all purchases for a specific card.
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{cardId}")]
        public string GetPurchasesByCard(int cardId)
        {
            return JsonConvert.SerializeObject(service.GetPurchasesByCard(cardId), Formatting.Indented);
        }

        /// <summary>
        /// This service creates purchase from a given JsonObject.
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreatePurchase([FromBody] CreatePurchaseDto purchase)
        {
            return service.CreatePurchase(purchase);
        }

        /// <summary>
        /// This service updates purchase in the database from a given JsonObject.
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string UpdatePurchase([FromBody] UpdatePurchaseDto purchase)
        {
            return service.UpdatePurchase(purchase);
        }

        /// <summary>
        /// This service deletes a purchase with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return service.DeletePurchase(id);
        }
    }
}
