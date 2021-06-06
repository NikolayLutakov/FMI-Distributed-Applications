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
    public class UsersController : ControllerBase
    {
        private readonly UserService service = new UserService();

        /// <summary>
        /// This service gets all users. 
        /// </summary>
        /// <returns>JsonString</returns>
        [HttpGet]
        public string GetAllUsers()
        {
            return JsonConvert.SerializeObject(service.GetAllUsers(), Formatting.Indented);
        }
        /// <summary>
        /// This service gets information about user by given username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>string</returns>
        [HttpGet("{username}")]
        public string GetUserByUsername(string username)
        {
            var result = service.GetUserByUsername(username);

            if (result == null)
            {
                return $"No user with username \"{username}\" found.";
            }
            else
            {
                return JsonConvert.SerializeObject(result, Formatting.Indented);
            }

            
        }


        /// <summary>
        /// This service gets all user with given age.
        /// </summary>
        /// <param name="age"></param>
        /// <returns>JsonString</returns>
        [HttpGet("{age}")]
        public string GetUsersByAge(int age)
        {
            return JsonConvert.SerializeObject(service.GetUsersByAge(age), Formatting.Indented);
        }

        /// <summary>
        /// This service creates user in the database from a given JsonObject.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string CreateUser([FromBody] CreateUserDto user)
        {
            return service.CreateUser(user);
        }

        /// <summary>
        /// This service updates user in the database from a given JsonObject.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateUser([FromBody] UserDto user)
        {
            return service.UpdateUser(user);
        }

        /// <summary>
        /// This service deletes a user with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string DeleteUser(int id)
        {
            return service.DeleteUser(id);
        }
    }
}
