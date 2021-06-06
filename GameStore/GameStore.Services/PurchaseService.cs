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
    public class PurchaseService : IPurchaseService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        public string CreatePurchase(CreatePurchaseDto purchase)
        {
            var result = new StringBuilder();

            var purchaseType = dbContext.PurchaseTypes.Find(purchase.TypeId);

            var game = dbContext.Games.Find(purchase.GameId);

            var card = dbContext.Cards.Find(purchase.CardId);



            if (purchaseType == null)
            {
                return "Invalid PurchaseTypeId - operation failed.";
            }

            if (game == null)
            {
                return "Invalid GameId - operation failed.";
            }

            if (card == null)
            {
                return "Invalid CardId - operation failed.";
            }

            var purchaseToAdd = new Purchase
            {
                Card = card,
                Date = DateTime.UtcNow,
                Game = game,
                ProductKey = purchase.ProductKey,
                Type = purchaseType

            };

            try
            {
                dbContext.Add(purchaseToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"Purchase with key \"{purchaseToAdd.ProductKey}\" added succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string DeletePurchase(int id)
        {
            var result = new StringBuilder();
            var purchaseToDelete = dbContext.Purchases.Find(id);

            if (purchaseToDelete == null)
            {
                return "Invalid PurchaseId";
            }

            try
            {
                dbContext.Remove(purchaseToDelete);
                dbContext.SaveChanges();
                result.AppendLine($"Purchase with Id #{purchaseToDelete.Id} deleted succsessfuly");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public string UpdatePurchase(UpdatePurchaseDto purchase)
        {
            var result = new StringBuilder();

            var purchaseToUpdate = dbContext.Purchases.Find(purchase.Id);

            if (purchaseToUpdate == null)
            {
                return "Invalid PurchaseId";
            }

            var purchaseType = dbContext.PurchaseTypes.Find(purchase.TypeId);

            var game = dbContext.Games.Find(purchase.GameId);

            var card = dbContext.Cards.Find(purchase.CardId);



            if (purchaseType == null)
            {
                return "Invalid PurchaseTypeId - operation failed.";
            }

            if (game == null)
            {
                return "Invalid GameId - operation failed.";
            }

            if (card == null)
            {
                return "Invalid CardId - operation failed.";
            }

            purchaseToUpdate.Card = card;
            purchaseToUpdate.Game = game;
            purchaseToUpdate.Type = purchaseType;
            purchaseToUpdate.ProductKey = purchase.ProductKey;

            try
            {
                dbContext.Update(purchaseToUpdate);
                dbContext.SaveChanges();
                result.AppendLine($"Purchase with id #{purchaseToUpdate.Id} updated succsessfuly.");
            }
            catch (Exception)
            {

                result.AppendLine($"Error updating database - operation failed.");
            }

            

            return result.ToString().Trim();
        }

        public IEnumerable<PurchaseDto> GetAllPurchases()
        {
            return dbContext.Purchases
                .Select(x => new PurchaseDto 
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    ProductKey = x.ProductKey,
                    Date = x.Date.ToString("dd/MM/yyyy HH:mm"),
                    CardNumber = x.Card.Number,
                    User = x.Card.User.Username,
                    GameName = x.Game.Name
                })
                .ToList();
        }

        public IEnumerable<PurchaseDto> GetPurchasesByCard(int cardId)
        {
            return dbContext.Purchases
                .Where(x => x.CardId == cardId)
                .Select(x => new PurchaseDto
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    ProductKey = x.ProductKey,
                    Date = x.Date.ToString("dd/MM/yyyy HH:mm"),
                    CardNumber = x.Card.Number,
                    User = x.Card.User.Username,
                    GameName = x.Game.Name
                })
                .ToList();
        }

       
    }
}
