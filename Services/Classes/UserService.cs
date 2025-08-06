using System.Collections.ObjectModel;
using System.Linq.Expressions;
using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Component.Exceptions.Models;
using ProStudy_NET.Component.Security.Services;
using ProStudy_NET.Models.DTO.ProjectDTO;
using ProStudy_NET.Models.DTO.RoleDTO;
using ProStudy_NET.Models.DTO.TestDTO;
using ProStudy_NET.Models.DTO.UserDTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services
{
    public class UserService : iUserServices
    {
        private readonly UnitWork unitWork;
        private readonly JwtServices jwtServices;

        public UserService(UnitWork unitWork, JwtServices jwtServices){
            this.unitWork = unitWork;
            this.jwtServices = jwtServices;
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
           User? userInfo = unitWork.Users.FindById(new { id },
            (Expression<Func<User, object>>)(u => u.SkillTests),
            (Expression<Func<User, object>>)(u => u.UserProjects));
           
           if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo), "User not found");
            }

           return new LoadUserDTO{UserName = userInfo.UserName, Email = userInfo.Email};
        }

        public LoadUserDTO GetByUserName(string username)
        {
            User? userInfo = unitWork.Users.GetByUserName(username);

            if(userInfo == null){
                throw new ArgumentNullException(nameof(userInfo), "User not found");
            }

            return new LoadUserDTO
            {
                UserName = userInfo.UserName,
                Email = userInfo.Email,
                Id = userInfo.Id,
                RoleInfos = userInfo.UserRoles.Select(r => new RolePermissionDTO { id = r.RoleId }).ToList(),
                Skills = userInfo.SkillTests.Select(s => new TestInfoDTO { Id = s.TestId, Name = s.TestTitle }).ToList(),
                Projects = userInfo.UserProjects.Select(p => new ProjectMinViewDTO { projectName = p.ProjectName }).ToList()
            };
        }

        public string Login(UserLoginDTO userDTO)
        {
            User? user = unitWork.Users.GetByUserName(userDTO.login);
            if(user == null){
                user = unitWork.Users.GetByEmail(userDTO.login);
                if(user == null){
                    throw new NotFoundException("User not found");
                }
            }
            bool isValid = BCrypt.Net.BCrypt.Verify(userDTO.password, user.Password);
            
            if(!isValid){
                throw new UnauthorizedException("Invalid password");
            }
            LoadUserDTO userInfo = new LoadUserDTO{UserName = user.UserName, Email = user.Email, Id = user.Id, RoleInfos = user.UserRoles.Select(r => new RolePermissionDTO{id = r.RoleId}).ToList()};
            return jwtServices.GenerateToken(userInfo);
        }
    }
}