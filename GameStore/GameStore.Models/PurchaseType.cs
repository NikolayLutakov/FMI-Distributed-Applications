using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Models
{
    public class PurchaseType
    {
        public PurchaseType()
        {
            this.Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Type { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
