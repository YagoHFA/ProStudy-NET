using ProStudy_NET.Models.Entities;
using ProStudy_NET.Models.Interfaces;


namespace ProStudy_NET.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetByUserName(string username);
    }
}