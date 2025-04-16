using ProStudy_NET.Models.DTO.UserDTO;

namespace ProStudy_NET.Services.Interfaces
{
    public interface iUserServices
    {
        LoadUserDTO GetById(long id);
        LoadUserDTO GetByUserName(string username);
        void Create(UserRegisterDTO userDTO);
        string Login(UserLoginDTO userDTO);

    
    }
}