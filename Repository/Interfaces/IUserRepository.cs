using HFA;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetByUserName(string username);

        User? GetByEmail(string email);

    }
}