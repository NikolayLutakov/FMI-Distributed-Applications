using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Models
{
    public class CreateUserDto
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
