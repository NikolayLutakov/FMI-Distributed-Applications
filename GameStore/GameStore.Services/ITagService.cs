using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface ITagService
    {
        string CreateTag(CreateTagDto tag);

        string UpdateTag(TagDto tag);

        string DeleteTag(int id);

        IEnumerable<TagDto> GetAllTags();

        string AddTagToGame(int tagId, int gameId);

        string RemoveTagFromGame(int tagId, int gameId);

        IEnumerable<GameTagDto> GetTagsForGame(int gameId);
    }
}
