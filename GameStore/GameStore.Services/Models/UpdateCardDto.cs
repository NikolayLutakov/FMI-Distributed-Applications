using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class UpdateCardDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Cvc { get; set; }

        public int TypeId { get; set; }

        public int UserId { get; set; }
    }
}
