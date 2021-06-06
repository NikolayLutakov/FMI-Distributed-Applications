using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class PurchaseDto
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string ProductKey { get; set; }

        public string Date { get; set; }

        public string User { get; set; }
        public string CardNumber { get; set; }

        public string GameName { get; set; }
    }
}
