using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models
{
    public interface UserDetails
    {
        public long Id {get; set;}
        public string UserName {get; set;}
        public string PasswordHash {get; set;}
    }
}