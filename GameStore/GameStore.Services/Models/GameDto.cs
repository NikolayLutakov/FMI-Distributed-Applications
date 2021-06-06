using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
    }
}
