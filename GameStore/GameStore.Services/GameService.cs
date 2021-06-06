using GameStore.Data;
using GameStore.Models;
using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public string CreateGame(CreateGameDto game)
        {

            var result = new StringBuilder();

            DateTime releaseDate;
            var parseDate = DateTime.TryParse(game.ReleaseDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

            if (!parseDate)
            {
                return "Invalid date format.";
            }

            var dev = dbContext.Developers.Find(game.DeveloperId);

            var genre = dbContext.Genres.Find(game.GenreId);

            if (dev == null)
            {
                return "Invalid DeveloperId.";
            }

            if (dev == null)
            {
                return "Invalid GenreId.";
            }


            var gameToAdd = new Game
            {
                Name = game.Name,
                Developer = dev,
                Genre = genre,
                Price = game.Price,
                ReleaseDate = releaseDate
            };

            try
            {
                dbContext.Add(gameToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"Game {gameToAdd.Name} added successfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string DeleteGame(int id)
        {
            var result = new StringBuilder();

            var gameToDelete = dbContext.Games.Find(id);

            if (gameToDelete == null)
            {
                return "Invalid GameId - operation failed.";
            }

            try
            {
                dbContext.Remove(gameToDelete);
                dbContext.SaveChanges();
                result.AppendLine($"Game with id #{gameToDelete.Id} deleted successfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<GameDto> GetAllGames()
        {
            return dbContext.Games
                .Select(x => new GameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price.ToString("F2"),
                    Developer = x.Developer.Name,
                    Genre = x.Genre.Name,
                    ReleaseDate = x.ReleaseDate.ToString("dd/MM/yyyy")
                })
                .ToList();
        }

        public IEnumerable<GameDto> GetGamesFromDeveloper(string devName)
        {
            return dbContext.Games
                .Where(x => x.Developer.Name.ToLower() == devName.ToLower())
                .Select(x => new GameDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price.ToString("F2"),
                    Developer = x.Developer.Name,
                    Genre = x.Genre.Name,
                    ReleaseDate = x.ReleaseDate.ToString("dd/MM/yyyy")
                })
                .ToList();
        }

        public string UpdateGame(UpdateGameDto game)
        {
            var result = new StringBuilder();

            DateTime releaseDate;
            var parseDate = DateTime.TryParse(game.ReleaseDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

            if (!parseDate)
            {
                return "Invalid date format.";
            }

            var dev = dbContext.Developers.Find(game.DeveloperId);

            var genre = dbContext.Genres.Find(game.GenreId);

            if (dev == null)
            {
                return "Invalid DeveloperId - operation failed.";
            }

            if (dev == null)
            {
                return "Invalid GenreId - operation failed.";
            }

            var gameToUpdate = dbContext.Games.Find(game.Id);

            if (gameToUpdate == null)
            {
                return "Invalid GameId - operation failed.";
            }

            gameToUpdate.Name = game.Name;
            gameToUpdate.Price = game.Price;
            gameToUpdate.ReleaseDate = releaseDate;
            gameToUpdate.Developer = dev;
            gameToUpdate.Genre = genre;

            try
            {
                dbContext.Update(gameToUpdate);
                dbContext.SaveChanges();
                result.AppendLine($"Game with id #{gameToUpdate.Id} updated successfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }


            return result.ToString().Trim();
        }
    }
}

