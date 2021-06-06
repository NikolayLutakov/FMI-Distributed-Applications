using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Models
{
    public class CardType
    {
        public CardType()
        {
            this.Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Type { get; set; }


        public virtual ICollection<Card> Cards { get; set; }

    }
}
