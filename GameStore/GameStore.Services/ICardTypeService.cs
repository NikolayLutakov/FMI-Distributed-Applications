using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface ICardTypeService
    {
        string CreateCardType(CreateCardTypeDto cardType);

        string DeleteCardType(int id);

        string UpdateCardType(CardTypeDto cardType);

        IEnumerable<CardTypeDto> GetAllCardTypes();

        IEnumerable<CardDto> GetAllCardsForType(int typeId);


    }
}
