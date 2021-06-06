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
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public string CreateGenre(CreateGenreDto genre)
        {
            var result = new StringBuilder();

            var existingGenres = dbContext.Genres.Select(x => x.Name.ToLower());

            if (existingGenres.Contains(genre.Name.ToLower()))
            {
                return $"Genre with name \"{genre.Name}\" already exists.";
            }


            var genreToAdd = new Genre
            {
                Name = genre.Name
            };

            try
            {
                dbContext.Add(genreToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"Genre \"{genreToAdd.Name}\" added succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string DeleteGenre(int id)
        {
            var result = new StringBuilder();

            var genreDelete = dbContext.Genres.Find(id);

            if (genreDelete == null)
            {
                return "Invalid GenreId";
            }

            try
            {
                dbContext.Remove(genreDelete);
                dbContext.SaveChanges();
                result.AppendLine($"Genre with id #{genreDelete.Id} deleted succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<GameDto> GetAllGamesForGenre(int id)
        {
            return dbContext.Games
               .Where(x => x.Genre.Id == id)
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

        public IEnumerable<GenreDto> GetAllGenres()
        {
            return dbContext.Genres
               .Select(x => new GenreDto
               {
                   Id = x.Id,
                   Name = x.Name
               })
               .ToList();
        }

        public string UpdateGenre(GenreDto genre)
        {
            var result = new StringBuilder();

            var genreToUpdate = dbContext.Genres.Find(genre.Id);

            if (genreToUpdate == null)
            {
                return "Invalid GenreId - operation failed.";
            }

            var existingGenres = dbContext.Genres.Where(x => x.Name.ToLower() != genreToUpdate.Name.ToLower()).Select(x => x.Name.ToLower());

            if (existingGenres.Contains(genre.Name.ToLower()))
            {
                return $"Genre with name \"{genre.Name}\" already exists - operation failed.";
            }

            genreToUpdate.Name = genre.Name;

            try
            {
                dbContext.Update(genreToUpdate);
                dbContext.SaveChanges();
                result.AppendLine($"Genre with id #\"{genreToUpdate.Id}\" updated succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }
    }
}
