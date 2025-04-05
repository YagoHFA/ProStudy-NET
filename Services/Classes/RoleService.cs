using ProStudy_NET.Models.DTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository){
            this.roleRepository = roleRepository;
        }

        public RoleInfoDTO FindById(string id)
        {   Role? role = roleRepository.FindById(id);
            if(role == null){
                throw new Exception("Role not found");
            }
            return new RoleInfoDTO{RoleName = role.RoleName, RoleId = role.Id};
        }

        public RoleInfoDTO FindByRoleName(string roleName)
        {
            Role? role = roleRepository.Find(r => r.RoleName.Equals(roleName));
            if(role == null){
                throw new Exception("Role not found");
            }
           return new RoleInfoDTO {RoleName = role.RoleName, RoleId = role.Id};
        }
    }
}