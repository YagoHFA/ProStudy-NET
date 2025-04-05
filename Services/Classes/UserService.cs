using System.Collections.ObjectModel;
using ProStudy_NET.Models.DTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services
{
    public class UserService : iUserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository){
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public void Create(UserRegisterDTO userDTO)
        {
            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            User user = new User{
                UserName = userDTO.Username,
                Email = userDTO.Email,
                Password = encryptedPassword,
            };

            Role? role = roleRepository.GetByRoleName("User");

            if(role == null){
                throw new ArgumentNullException(nameof(role), "Role not found");
            }

            UserRoles userRole = new()
            {
                RoleId = role.Id,
                Role = role,
                User = user
            };

            user.UserRoles = new Collection<UserRoles>{userRole};

            userRepository.Add(user);

        }

        public LoadUserDTO GetById(long id)
        {
           User? userInfo = userRepository.FindById(id);
           
           if(userInfo == null){
                throw new ArgumentNullException(nameof(userInfo), "User not found");
            }

           return new LoadUserDTO{UserName = userInfo.UserName, Email = userInfo.Email};
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