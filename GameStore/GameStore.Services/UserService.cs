using GameStore.Data;
using GameStore.Models;
using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
 

        public string CreateUser(CreateUserDto user)
        {
            var result = new StringBuilder();

            var usernames = dbContext.Users.Select(x => x.Username).ToList();

            if (usernames.Any(x => user.Username == x))
            {
                return "Username already taken - opearation failed.";
            }

            var userToAdd = new User
            {
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Age = user.Age, 
            };

            try
            {
                dbContext.Add(userToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"User \"{userToAdd.Username}\" added successfully.");

            }
            catch (Exception)
            {
                result.AppendLine($"Error updating database - operation failed.");
            }
            
            return result.ToString().Trim();
        }

        public string DeleteUser(int id)
        {
            var result = new StringBuilder();

            var userToDelete = dbContext.Users.Find(id);

            if (userToDelete == null)
            {
                return "Invalid userId - operation failed.";
            }

            try
            {
                dbContext.Remove(userToDelete);
                dbContext.SaveChanges();
                result.AppendLine($"User \"{userToDelete.Username}\" deleted successfully");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = dbContext.Users.Select(x => new UserDto 
            {
                Id = x.Id,
                Username = x.Username,
                FullName = x.FullName,
                Age = x.Age,
                Email = x.Email
            })
            .ToList();

            return users;
        }

        public UserDto GetUserByUsername(string username)
        {
            var result = new StringBuilder();

            var user = dbContext.Users.FirstOrDefault(x => x.Username == username);


            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Age = user.Age,
                Email = user.Email,
                FullName = user.FullName
            };



            return userDto;
        }

        public IEnumerable<UserDto> GetUsersByAge(int age)
        {
            var users = dbContext.Users.Where(x => x.Age == age).Select(x => new UserDto
            {
                Id = x.Id,
                Username = x.Username,
                FullName = x.FullName,
                Age = x.Age,
                Email = x.Email
            })
            .ToList();

            return users;
        }

        public string UpdateUser(UserDto user)
        {
            var result = new StringBuilder();

            var userToUpdate = dbContext.Users.Find(user.Id);

            if (userToUpdate == null)
            {
                return "Invalid userId - operation failed.";
            }

            var usernames = dbContext.Users.Where(x => x.Username != userToUpdate.Username).Select(x => x.Username).ToList();

            if (usernames.Any(x => user.Username == x))
            {
                return "Username already taken - opearation failed.";
            }

            if (userToUpdate == null)
            {
                return "Invalid user ID - opearation failed.";
            }

            userToUpdate.Username = user.Username;
            userToUpdate.FullName = user.FullName;
            userToUpdate.Email = user.Email;
            userToUpdate.Age = user.Age;

            try
            {
                dbContext.Update(userToUpdate);
                dbContext.SaveChanges();
                result.AppendLine($"User \"{userToUpdate.Username}\" updated successfully");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }
    }
}
