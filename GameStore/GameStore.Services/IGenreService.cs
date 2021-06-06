using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface IGenreService
    {
        string CreateGenre(CreateGenreDto genre);

        string UpdateGenre(GenreDto genre);

        string DeleteGenre(int id);

        IEnumerable<GenreDto> GetAllGenres();

        IEnumerable<GameDto> GetAllGamesForGenre(int id);
    }
}
