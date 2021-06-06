using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int TypeId { get; set; }
        public PurchaseType Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
