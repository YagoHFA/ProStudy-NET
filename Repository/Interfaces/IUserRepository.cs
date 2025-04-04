using HFA;
using ProStudy_NET.Models.Entities;



namespace ProStudy_NET.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetByUserName(string username);
    }
}