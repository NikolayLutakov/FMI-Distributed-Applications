using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface IDeveloperService
    {
        string CreateDeveloper(CreateDeveloperDto developer);

        string UpdateDeveloper(DeveloperDto developer);

        string DeleteDeveloper(int id);

        IEnumerable<DeveloperDto> GetAllDevelopers();

        IEnumerable<GameDto> GetAllGamesForDeveloper(int id);
    }
}
