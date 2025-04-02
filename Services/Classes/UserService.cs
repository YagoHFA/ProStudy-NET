using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.DTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Classes;
using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services
{
    public class UserService : iUserServices
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository){
            this.userRepository = userRepository;
        }
        public LoadUserDTO GetByUserName(string username)
        {
            User? userInfo = userRepository.GetByUserName(username).FirstOrDefault();

            if(userInfo == null){
                throw new ArgumentNullException(nameof(userInfo), "User not found");
            }

            return new LoadUserDTO{UserName = userInfo.UserName, Email = userInfo.Email};

        }
    }
}