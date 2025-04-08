using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProStudy_NET.Models.DTO.UserDTO
{
    public class UserRegisterDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}