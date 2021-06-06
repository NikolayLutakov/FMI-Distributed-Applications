using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface IPurchaseService
    {
        string CreatePurchase(CreatePurchaseDto purchase);

        string UpdatePurchase(UpdatePurchaseDto purchase);

        string DeletePurchase(int id);

        IEnumerable<PurchaseDto> GetAllPurchases();

        IEnumerable<PurchaseDto> GetPurchasesByCard(int cardId);
    }
}
