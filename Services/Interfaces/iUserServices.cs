using ProStudy_NET.Models.DTO;

namespace ProStudy_NET.Services.Interfaces
{
    public interface iUserServices
    {
        LoadUserDTO GetById(long id);
        LoadUserDTO GetByUserName(string username);

        void Create(UserRegisterDTO userDTO);
    }
}