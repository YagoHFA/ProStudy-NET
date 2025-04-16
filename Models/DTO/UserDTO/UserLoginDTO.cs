using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProStudy_NET.Models.DTO.UserDTO
{
    public class UserLoginDTO
    {
        public required string login { get; set; }
        public required string password { get; set; }
    }
}