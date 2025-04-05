using HFA.DB.Model;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;
namespace ProStudy_NET.Repository.Classes
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
}