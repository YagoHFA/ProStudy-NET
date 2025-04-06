using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Models.DTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class RoleService : IRoleService
    {
        private readonly UnitWork unitWork;

        public RoleService(UnitWork unitWork){
            this.unitWork = unitWork;
        }

        public RoleInfoDTO FindById(string id)
        {   Role? role = unitWork.Roles.FindById(id);
            if(role == null){
                throw new Exception("Role not found");
            }
            return new RoleInfoDTO{RoleName = role.Permission, RoleId = role.Id};
        }

        public RoleInfoDTO FindByRoleName(string roleName)
        {
            Role? role = unitWork.Roles.Find(r => r.Permission.Equals(roleName));
            if(role == null){
                throw new Exception("Role not found");
            }
           return new RoleInfoDTO {RoleName = role.Permission, RoleId = role.Id};
        }
    }
}