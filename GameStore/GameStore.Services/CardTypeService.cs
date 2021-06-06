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
    public class CardTypeService : ICardTypeService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public string CreateCardType(CreateCardTypeDto cardType)
        {
            var result = new StringBuilder();

            var existingTypes = dbContext.CardTypes.Select(x => x.Type.ToLower()).ToList();

            if (existingTypes.Contains(cardType.Type.ToLower()))
            {
                return "This type already exists - operation failed.";
            }

            var cardTypeToAdd = new CardType
            {
                Type = cardType.Type
            };

            try
            {
                dbContext.Add(cardTypeToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"Card type \"{cardType.Type}\" added successfuly.");
            }
            catch (Exception)
            {

                result.AppendLine("Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string DeleteCardType(int id)
        {
            var result = new StringBuilder();

            var cardTypeToDelete = dbContext.CardTypes.Find(id);

            if (cardTypeToDelete == null)
            {
                return "Invalid CardTypeId - operation failed.";
            }

            try
            {
                dbContext.Remove(cardTypeToDelete);
                dbContext.SaveChanges();
                result.AppendLine($"CardType with id #{cardTypeToDelete.Id} deleted successfuly.");
            }
            catch (Exception)
            {
                result.AppendLine("Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<CardDto> GetAllCardsForType(int typeId)
        {
            return dbContext.Cards.Where(x => x.TypeId == typeId)
                .Select(x => new CardDto
                {
                    Id = x.Id,
                    CardType = x.Type.Type,
                    Cvc = x.Cvc,
                    Number = x.Number,
                    User = x.User.Username

                })
                .ToList();
        }

        public IEnumerable<CardTypeDto> GetAllCardTypes()
        {
            return dbContext.CardTypes.Select(x => new CardTypeDto { Id = x.Id, Type = x.Type }).ToList();
        }

        public string UpdateCardType(CardTypeDto cardType)
        {
            var result = new StringBuilder();

            var cardTypeToBeUpdated = dbContext.CardTypes.Find(cardType.Id);

            if (cardTypeToBeUpdated == null)
            {
                return "Invalid CardTypeId - operation failed.";
            }

            var existingTypes = dbContext.CardTypes.Where(x => x.Type != cardTypeToBeUpdated.Type).Select(x => x.Type.ToLower()).ToList();

            if (existingTypes.Contains(cardType.Type.ToLower()))
            {
                return "This type already exists - operation failed.";
            }

            cardTypeToBeUpdated.Type = cardType.Type;

            try
            {
                dbContext.Update(cardTypeToBeUpdated);
                dbContext.SaveChanges();
                result.AppendLine($"CardType with id #{cardTypeToBeUpdated.Id} updated successfuly.");
            }
            catch (Exception)
            {
                result.AppendLine("Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }
    }
}
