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
    public class PurchaseTypeService : IPurchaseTypeService
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public string CreatePurchaseType(CreatePurchaseTypeDto purchaseType)
        {
            var result = new StringBuilder();

            var existingTypes = dbContext.PurchaseTypes.Select(x => x.Type.ToLower()).ToList();

            if (existingTypes.Contains(purchaseType.Type.ToLower()))
            {
                return "This type already exists - operation failed.";
            }

            var purchaseTypeToAdd = new PurchaseType
            {
                Type = purchaseType.Type
            };

            try
            {
                dbContext.Add(purchaseTypeToAdd);
                dbContext.SaveChanges();
                result.AppendLine($"Purchase type \"{purchaseTypeToAdd.Type}\" added successfuly.");
            }
            catch (Exception)
            {

                result.AppendLine("Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }
    

        public string DeletePurchaseType(int id)
        {
            var result = new StringBuilder();

            var purchaseTypeToDelete = dbContext.PurchaseTypes.Find(id);

            if (purchaseTypeToDelete == null)
            {
                return "Invalid PurchaseTypeId - operation failed.";
            }

            try
            {
                dbContext.Remove(purchaseTypeToDelete);
                dbContext.SaveChanges();
                result.AppendLine($"PurchaseType with id #{purchaseTypeToDelete.Id} deleted successfuly.");
            }
            catch (Exception)
            {
                result.AppendLine("Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }

        public IEnumerable<PurchaseDto> GetAllPurchasesForType(int typeId)
        {
            return dbContext.Purchases.Where(x => x.TypeId == typeId)
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

        public IEnumerable<PurchaseTypeDto> GetAllPurchaseTypes()
        {
            return dbContext.PurchaseTypes.Select(x => new PurchaseTypeDto { Id = x.Id, Type = x.Type }).ToList();
        }

        public string UpdatePurchaseType(PurchaseTypeDto purchaseType)
        {
            var result = new StringBuilder();

            var purchaseTypeToBeUpdated = dbContext.PurchaseTypes.Find(purchaseType.Id);

            if (purchaseTypeToBeUpdated == null)
            {
                return "Invalid PurchaseTypeId - operation failed.";
            }

            var existingTypes = dbContext.PurchaseTypes.Where(x => x.Type != purchaseTypeToBeUpdated.Type).Select(x => x.Type.ToLower()).ToList();

            if (existingTypes.Contains(purchaseType.Type.ToLower()))
            {
                return "This type already exists - operation failed.";
            }

            purchaseTypeToBeUpdated.Type = purchaseType.Type;

            try
            {
                dbContext.Update(purchaseTypeToBeUpdated);
                dbContext.SaveChanges();
                result.AppendLine($"PurchaseType with id #{purchaseTypeToBeUpdated.Id} updated successfuly.");
            }
            catch (Exception)
            {
                result.AppendLine("Error updating database - operation failed.");
            }

            return result.ToString().Trim();
        }
    }
}
