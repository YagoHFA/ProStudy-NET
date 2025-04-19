using HFA.DB.Model;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Component.DB;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(ProStudyDB context) : base(context)
        {
        }

        public User? GetByEmail(string email)
        {
            return dbSet.Include(u => u.UserRoles).Include(u => u.UserProjects).Where(u => u.Email != null && u.Email.Equals(email)).FirstOrDefault();
        }

        public User? GetByUserName(string username){
            return dbSet.Include(u => u.UserRoles).Include(u => u.UserProjects).Where(u => u.UserName != null && u.UserName.Equals(username)).FirstOrDefault();
        }
    }
}