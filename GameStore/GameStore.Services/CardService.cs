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
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();


        public string CreateCard(CreateCardDto card)
        {
            var result = new StringBuilder();

            var user = dbContext.Users.Find(card.UserId);

            var cardType = dbContext.CardTypes.Find(card.TypeId);

            if (user == null)
            {
                return result.AppendLine("Invalid UserId - operation failed.").ToString().Trim();
            }

            if (cardType == null)
            {
                return result.AppendLine("Invalid CardType - operation failed.").ToString().Trim();
            }

            var cardToAdd = new Card
            {
                Number = card.Number,
                Cvc = card.Cvc,
                Type = cardType,
                User = user,   
            };

            try
            {
                dbContext.Add(cardToAdd);
                dbContext.SaveChanges();

                result.AppendLine($"Card #{cardToAdd.Number} added for User \"{user.Username}\"");
            }
            catch (Exception)
            {
                result.AppendLine($"Error updating database - operation failed.");
            }

           

            return result.ToString().Trim();
        }

        public string DeleteCard(int cardId)
        {
            var result = new StringBuilder();

            var cardToDelete = dbContext.Cards.Find(cardId);

            if (cardToDelete == null)
            {
                return result.AppendLine("Invalid CardId - operation failed.").ToString().Trim();
            }

            try
            {
                dbContext.Remove(cardToDelete);
                dbContext.SaveChanges();
                result.AppendLine($"Card #{cardToDelete.Number} deleted successfully.");
            }
            catch (Exception)
            {
                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<CardDto> GetAllCards()
        {
            return dbContext.Cards
                .Select(x => new CardDto 
                { 
                    Number = x.Number, 
                    Cvc = x.Cvc, Id = x.Id, 
                    CardType = x.Type.Type, 
                    User = x.User.Username 
                })
                .ToList();
        }

        public IEnumerable<CardDto> GetAllCardsForUser(int userId)
        {
            return dbContext.Cards
                .Where(x => x.UserId == userId)
                .Select(x => new CardDto 
                { 
                    Number = x.Number, 
                    Cvc = x.Cvc, Id = x.Id,
                    CardType = x.Type.Type,
                    User = x.User.Username
                })
                .ToList();
        }

        public string UpdateCard(UpdateCardDto card)
        {
            var result = new StringBuilder();

            var cardToUpdate = dbContext.Cards.Find(card.Id);

            var user = dbContext.Users.Find(card.UserId);

            var cardType = dbContext.CardTypes.Find(card.TypeId);

            if (cardToUpdate == null)
            {
                return "Invalid CardId - operation failed.";
            }

            if (user == null)
            {
                return "Invalid UserId - operation failed.";
            }

            if (cardType == null)
            {
                return "Invalid CardType - operation failed.";
            }

            cardToUpdate.Number = card.Number;
            cardToUpdate.Cvc = card.Cvc;
            cardToUpdate.Type = cardType;
            cardToUpdate.User = user;

            try
            {
                dbContext.Update(cardToUpdate);
                dbContext.SaveChanges();
                result.AppendLine("Card updated successfully.");
            }
            catch (Exception)
            {

                result.AppendLine("Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }
    }
}
