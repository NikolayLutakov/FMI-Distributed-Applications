using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface IGameService
    {
        string CreateGame(CreateGameDto game);

        string UpdateGame(UpdateGameDto game);
        
        string DeleteGame(int id);

        IEnumerable<GameDto> GetAllGames();

        IEnumerable<GameDto> GetGamesFromDeveloper(string devName);
    }
}
