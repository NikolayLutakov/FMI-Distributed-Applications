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
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public string AddTagToGame(int tagId, int gameId)
        {
            var result = new StringBuilder();

            var game = dbContext.Games.Find(gameId);

            var tag = dbContext.Tags.Find(tagId);

            if (game == null)
            {
                return "Invalid GameId - opearation failed.";
            }

            if (tag == null)
            {
                return "Invalid TagId - opearation failed.";
            }

            var existingGameTags = dbContext.GameTags.ToList();



            var gameTag = new GameTag
            {
                Game = game,
                Tag = tag
            };

            foreach (var exTag in existingGameTags)
            {
                if (exTag.GameId == game.Id && exTag.TagId == tag.Id)
                {
                    return $"Tag \"{tag.Name}\" is already added to game \"{game.Name}\" - opearation failed.";
                }
            }

            try
            {
                dbContext.Add(gameTag);
                dbContext.SaveChanges();
                result.AppendLine($"Tag \"{tag.Name}\" succsessfuly added to game \"{game.Name}\".");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string CreateTag(CreateTagDto tag)
        {
            var result = new StringBuilder();

            var existingTags = dbContext.Tags.Select(x => x.Name);

            if (existingTags.Contains(tag.Name))
            {
                return $"Tag with name {tag.Name} already exists - operation failed.";
            }

            var tagToAdd = new Tag
            {
                Name = tag.Name
            };

            try
            {
                dbContext.Add(tagToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"Tag {tag.Name} created succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string DeleteTag(int id)
        {
            var result = new StringBuilder();

            var tagToBeDeleted = dbContext.Tags.Find(id);

            if (tagToBeDeleted == null)
            {
                return "Invalid TagId - opearation failed.";
            }

            try
            {
                dbContext.Remove(tagToBeDeleted);
                dbContext.SaveChanges();
                result.AppendLine($"Tag with id #{tagToBeDeleted.Id} deleted succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<TagDto> GetAllTags()
        {
            return dbContext.Tags
                .Select(x => new TagDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public IEnumerable<GameTagDto> GetTagsForGame(int gameId)
        {
            return dbContext.Games
                .Where(x => x.Id == gameId)
                .Select(x => new GameTagDto
                {
                    GameName = x.Name,
                    Tags = x.GameTags.Select(t => t.Tag.Name)
                })
                .ToList();
        }

        public string RemoveTagFromGame(int tagId, int gameId)
        {
            var result = new StringBuilder();

            var game = dbContext.Games.Find(gameId);

            var tag = dbContext.Tags.Find(tagId);

            if (game == null)
            {
                return "Invalid GameId - opearation failed.";
            }

            if (tag == null)
            {
                return "Invalid TagId - opearation failed.";
            }

            var tagToBeRemoved = dbContext.GameTags.FirstOrDefault(x => x.GameId == gameId && x.TagId == tagId);

            if (tagToBeRemoved == null)
            {
                return $"There is no tag \"{tag.Name}\" for game \"{game.Name}\"";
            }

            try
            {
                dbContext.Remove(tagToBeRemoved);
                dbContext.SaveChanges();
                result.AppendLine($"Tag \"{tag.Name}\" removed successfuly from game \"{game.Name}\"");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string UpdateTag(TagDto tag)
        {
            var result = new StringBuilder();

            var tagToUpdate = dbContext.Tags.Find(tag.Id);

            var existingTags = dbContext.Tags.Where(x => x.Name != tagToUpdate.Name).Select(x => x.Name.ToLower());

            if (tagToUpdate == null)
            {
                return "Invalid TagId - opearation failed.";
            }

            if (existingTags.Contains(tag.Name.ToLower()))
            {
                return $"Tag with name {tag.Name} already exists - operation failed.";
            }

            tagToUpdate.Name = tag.Name;

            try
            {
                dbContext.Update(tagToUpdate);
                dbContext.SaveChanges();
                result.AppendLine($"Tag with id #{tagToUpdate.Id} updated succsessfuly.");
            }
            catch (Exception)
            {
                result.AppendLine($"Error updating database - operation failed.");
            }


            return result.ToString().Trim();
        }
    }
}
