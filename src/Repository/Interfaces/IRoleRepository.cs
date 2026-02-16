using HFA;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Repository.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Role? GetByRoleName(string roleName);
    }
}