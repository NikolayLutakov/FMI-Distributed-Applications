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
    public class DeveloperService : IDeveloperService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public string CreateDeveloper(CreateDeveloperDto developer)
        {
            var result = new StringBuilder();

            var existingDevs = dbContext.Developers.Select(x => x.Name.ToLower());

            if (existingDevs.Contains(developer.Name.ToLower()))
            {
                return $"Developer with name \"{developer.Name}\" already exists.";
            }


            var devToAdd = new Developer
            {
                Name = developer.Name
            };

            try
            {
                dbContext.Add(devToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"Developer \"{devToAdd.Name}\" added succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string DeleteDeveloper(int id)
        {
            var result = new StringBuilder();

            var devtoDelete = dbContext.Developers.Find(id);

            if (devtoDelete == null)
            {
                return "Invalid DeveloperId";
            }

            try
            {
                dbContext.Remove(devtoDelete);
                dbContext.SaveChanges();
                result.AppendLine($"Developer with id #{devtoDelete.Id} deleted succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<DeveloperDto> GetAllDevelopers()
        {
            return dbContext.Developers
                .Select(x => new DeveloperDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public IEnumerable<GameDto> GetAllGamesForDeveloper(int id)
        {
            return dbContext.Games
                .Where(x => x.Developer.Id == id)
                .Select(x => new GameDto
                {
                    Id = x.Id,
                    Genre = x.Genre.Name,
                    Name = x.Name,
                    Developer = x.Developer.Name,
                    Price = x.Price.ToString("F2"),
                    ReleaseDate = x.ReleaseDate.ToString("dd/MM/yyyy")
                })
                .ToList();
        }

        public string UpdateDeveloper(DeveloperDto developer)
        {
            var result = new StringBuilder();

            var devToUpdate = dbContext.Developers.Find(developer.Id);

            if (devToUpdate == null)
            {
                return "Invalid DeveloperId - opearation failed.";
            }

            var existingDevs = dbContext.Developers.Where(x => x.Name.ToLower() != devToUpdate.Name.ToLower()).Select(x => x.Name.ToLower());

            if (existingDevs.Contains(developer.Name.ToLower()))
            {
                return $"Developer with name \"{developer.Name}\" already exists - opearation failed.";
            }

            devToUpdate.Name = developer.Name;

            try
            {
                dbContext.Update(devToUpdate);
                dbContext.SaveChanges();
                result.AppendLine($"Developer with id #\"{devToUpdate.Id}\" updated succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }
    }
}
