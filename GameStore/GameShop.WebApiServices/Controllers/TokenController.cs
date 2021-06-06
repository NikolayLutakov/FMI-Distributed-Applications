using GameStore.Data;
using GameStore.Services;
using GameStore.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly TokenService service = new TokenService();

        /// <summary>
        /// This service generates token to access the other servicess by given username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost("{userName}")]
        public string GetToken(string userName)
        {
            return service.GetToken(userName);
        }
    }
}

