using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class CreateGameDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ReleaseDate { get; set; }
        public int DeveloperId { get; set; }
        public int GenreId { get; set; }
    }
}
