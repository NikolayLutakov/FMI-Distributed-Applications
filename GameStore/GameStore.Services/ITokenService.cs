using GameStore.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface ITokenService
    {
        string GetToken(string userName);

        UserDto GetUser(string username);
    }
}
