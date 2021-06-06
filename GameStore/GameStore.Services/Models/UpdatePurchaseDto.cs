using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class UpdatePurchaseDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }

        public string ProductKey { get; set; }

        public int CardId { get; set; }

        public int GameId { get; set; }
    }
}
