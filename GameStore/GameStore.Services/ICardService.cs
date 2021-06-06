using GameStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public interface ICardService
    {
        string CreateCard(CreateCardDto card);

        string UpdateCard(UpdateCardDto card);


        string DeleteCard(int cardId);

        IEnumerable<CardDto> GetAllCardsForUser(int userId);

        IEnumerable<CardDto> GetAllCards();
    }
}
