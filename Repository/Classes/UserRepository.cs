using ProStudy_NET.Component.DB;
using ProStudy_NET.Component.DB.Abstract;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;


namespace ProStudy_NET.Repository.Classes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProStudyDB context) : base(context)
        {
        }

        public IQueryable<User> GetByUserName(string username){
            return context.Set<User>().Where(u => u.UserName != null && u.UserName.Equals(username));
        }
    }
}