using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class CardDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Cvc { get; set; }

        public string CardType { get; set; }

        public string User { get; set; }

    }
}
