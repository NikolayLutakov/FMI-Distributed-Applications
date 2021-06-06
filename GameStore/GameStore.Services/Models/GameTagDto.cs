using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class GameTagDto
    {
        public string GameName { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
