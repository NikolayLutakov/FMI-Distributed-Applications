using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface IPurchaseTypeService
    {
        string CreatePurchaseType(CreatePurchaseTypeDto purchaseType);

        string DeletePurchaseType(int id);

        string UpdatePurchaseType(PurchaseTypeDto purchaseType);

        IEnumerable<PurchaseTypeDto> GetAllPurchaseTypes();

        IEnumerable<PurchaseDto> GetAllPurchasesForType(int typeId);
    }
}
