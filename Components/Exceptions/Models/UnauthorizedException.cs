using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProStudy_NET.Component.Exceptions.Models
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Unauthorized")
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}