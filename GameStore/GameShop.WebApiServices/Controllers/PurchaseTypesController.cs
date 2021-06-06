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
    public class PurchaseTypesController : ControllerBase
    {
        private readonly PurchaseTypeService service = new PurchaseTypeService();

        /// <summary>
        /// This service gets all purchase types.
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllPurchaseTypes()
        {
            return JsonConvert.SerializeObject(service.GetAllPurchaseTypes(), Formatting.Indented);
        }

        /// <summary>
        /// This service gets all purchases for a specific type.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{typeId}")]
        public string GetAllPurchasesForType(int typeId)
        {
            return JsonConvert.SerializeObject(service.GetAllPurchasesForType(typeId), Formatting.Indented);
        }

        /// <summary>
        /// This service creates purchase type from a given JsonObject.
        /// </summary>
        /// <param name="purchaseType"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreatePurchaseType([FromBody] CreatePurchaseTypeDto purchaseType)
        {
            return service.CreatePurchaseType(purchaseType);
        }



        /// <summary>
        /// This service updates purchase type in the database from a given JsonObject.
        /// </summary>
        /// <param name="purchaseType"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string UpdatePurchaseType([FromBody] PurchaseTypeDto purchaseType)
        {
            return service.UpdatePurchaseType(purchaseType);
        }



        /// <summary>
        /// This service deletes a purchase type with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete("{id}")]
        public string DeletePurchaseType(int id)
        {
            return service.DeletePurchaseType(id);
        }
    }
}
