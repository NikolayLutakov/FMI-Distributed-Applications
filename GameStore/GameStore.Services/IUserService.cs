using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface IUserService
    {
        string CreateUser(CreateUserDto user);

        string UpdateUser(UserDto user);

        UserDto GetUserByUsername(string username);

        string DeleteUser(int id);

        IEnumerable<UserDto> GetUsersByAge(int age);

        IEnumerable<UserDto> GetAllUsers();

    }
}
