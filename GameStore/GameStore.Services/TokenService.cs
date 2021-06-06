using GameStore.Data;
using GameStore.Models;
using GameStore.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class TokenService : ITokenService
    {

        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        public string GetToken(string user)
        {

            if (user != null)
            {
                var getUser =  GetUser(user);



                if (getUser != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, "InventoryServiceAccessToken"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    //new Claim("Id", getUser.Id.ToString()),
                    //new Claim("FullName", getUser.FullName),
                    new Claim("Username", getUser.Username),
                    //new Claim("Email", getUser.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dfbsdfsdfbsdfhsd"));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    

                    var token = new JwtSecurityToken("InventoryAutenticationServer", "InventoryServicePostmanClient", claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token).ToString().Trim();
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    //return BadRequest("Invalid credentials");
                    return "Invalid credentials.";
                }
            }
            else
            {
                //return BadRequest();
                return "Bad Request.";
            }
        }

        public UserDto GetUser(string username)
            {
                return dbContext.Users.Where(u => u.Username == username).Select(x => new UserDto
                {
                    Id = x.Id,
                    Age = x.Age,
                    Email = x.Email,
                    FullName = x.FullName,
                    Username = x.Username
                })
                    .FirstOrDefault();

            }
        }
    }
