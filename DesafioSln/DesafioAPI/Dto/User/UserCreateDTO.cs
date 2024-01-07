using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Dto.User
{
    public class UserCreateDTO
    {
        public string Name  { get; set; }

        public string Email  { get; set; }
        
        public string Telephone  { get; set; }

        public string Password  { get; set; }
    }
}