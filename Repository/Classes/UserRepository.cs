using HFA.DB.Model;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Component.DB;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProStudyDB context) : base(context)
        {
        }

        /// <summary>
        /// Get all user Info by the given user's email.
        /// </summary>
        /// <param name="email">The email used to perform the search</param>
        /// <returns>Returns a user entity with all information if found, or null if not.</returns>
        public User? GetByEmail(string email)
        {
            return dbSet.Include(u => u.UserRoles)
                            .Include(u => u.UserRoles)
                            .ThenInclude(r => r.Role)
                            .Include(u => u.SkillTests)
                            .Include(u => u.UserProjects)
                            .AsSplitQuery()
                            .Where(u => u.Email != null && u.Email.Equals(email)).FirstOrDefault();
        }

        /// <summary>
        /// Get all User Info by given UserName
        /// </summary>
        /// <param name="username">The username used to perform the search</param>
        /// <returns>Returns a user entity with all information if found, or null if not.</returns>
        public User? GetByUserName(string username)
        {
            return dbSet.AsNoTracking()
                            .Include(u => u.UserRoles)
                            .ThenInclude(r => r.Role)
                            .Include(u => u.SkillTests)
                            .Include(u => u.UserProjects)
                            .AsSplitQuery()
                            .Where(u => u.UserName != null && u.UserName.Equals(username)).FirstOrDefault();
        }
    }
}