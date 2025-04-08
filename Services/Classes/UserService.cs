using System.Collections.ObjectModel;
using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Component.Exceptions.Models;
using ProStudy_NET.Models.DTO.UserDTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services
{
    public class UserService : iUserServices
    {
        private readonly UnitWork unitWork;

        public UserService(UnitWork unitWork){
            this.unitWork = unitWork;
        }

        public void Create(UserRegisterDTO userDTO)
        {
            if(unitWork.Users.Any(u => u.UserName.Equals(userDTO.Username)))
            {
                throw new Exception($"Username {userDTO.Username} already exists");
            }
            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            User user = new User{
                UserName = userDTO.Username,
                Email = userDTO.Email,
                Password = encryptedPassword,
            };

            Role? role = unitWork.Roles.GetByRoleName("User");

            if(role == null){
                throw new NotFoundException("Role 'User' not found");
            }

            UserRoles userRole = new()
            {
                RoleId = role.Id,
                Role = role,
                User = user
            };

            user.UserRoles = new Collection<UserRoles>{userRole};

            unitWork.Users.Add(user);
            unitWork.Complete();
              
        }

        public LoadUserDTO GetById(long id)
        {
           User? userInfo = unitWork.Users.FindById(id);
           
           if(userInfo == null){
                throw new ArgumentNullException(nameof(userInfo), "User not found");
            }

           return new LoadUserDTO{UserName = userInfo.UserName, Email = userInfo.Email};
        }

        public LoadUserDTO GetByUserName(string username)
        {
            User? userInfo = unitWork.Users.GetByUserName(username).FirstOrDefault();

            if(userInfo == null){
                throw new ArgumentNullException(nameof(userInfo), "User not found");
            }

            return new LoadUserDTO{UserName = userInfo.UserName, Email = userInfo.Email};
        }
    }
}