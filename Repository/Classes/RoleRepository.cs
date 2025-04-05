using HFA.DB.Model;
using ProStudy_NET.Component.DB;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;
namespace ProStudy_NET.Repository.Classes
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ProStudyDB context) : base(context)
        {
        }

        public Role? GetByRoleName(string roleName)
        {
            return context.Set<Role>().FirstOrDefault(r => r.Permission.Equals(roleName));
        }
    }
}